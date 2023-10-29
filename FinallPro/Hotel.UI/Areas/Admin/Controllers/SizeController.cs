using Hotel.Business.ViewModels.SizeVM;
using Hotel.Core.Entities;
using Hotel.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.UI.Areas.Admin.Controllers
{
  [Area("Admin")]
public class SizeController : Controller
{
    private readonly AppDbContext _context;
    public SizeController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        List<Size> sizes = _context.Sizes.ToList();
        return View(sizes);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SizeListViewModel size)
    {
        if (!ModelState.IsValid) return View(size);
        Size size1 = new()
        {
            SizeName = size.Name
        };
        await _context.Sizes.AddAsync(size1);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(int id)
    {
        Size? size = await _context.Sizes.FindAsync(id);
        if (size == null) return NotFound();
        return View(size);
    }
    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeletePost(int id)
    {
        Size? size = await _context.Sizes.FindAsync(id);
        if (size == null) return NotFound();
        _context.Sizes.Remove(size);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));

    }
}
}
