using Hotel.Business.ViewModels.RoomDetailVM;
using Hotel.Core.Entities;
using Hotel.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel.UI.Areas.Admin.Controllers;
[Area("Admin")]
[Route("admin/roomdetail")]
public class RoomDetailController : Controller
{

    private readonly AppDbContext _context;

    public RoomDetailController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet("list")]
    public IActionResult Index(int id)
    {
        RoomDetail roomDetail = _context.RoomDetails.FirstOrDefault(r => r.Id == id);
        List<RoomDetail> roomDetails = _context.RoomDetails.ToList();
        return View(roomDetails);
    }
    public async Task<IActionResult> Details(int id)
    {
        RoomDetail? roomDetail = await _context.RoomDetails.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
        if (roomDetail == null) return NotFound();
        return View(roomDetail);
    }
    [HttpGet("create")]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost("add")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(RoomDetailCreateViewModel room)
    {
        if (!ModelState.IsValid) return View(room);
        RoomDetail roomDetails = new()
        {
            Description = room.Description,
            Service = room.Service,
            MiniBar = room.MiniBar,
            Tv = room.Tv,
            AirController = room.AirController,
           
        };
        await _context.RoomDetails.AddAsync(roomDetails);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    [HttpGet("delete/{id}",Name = "room-delete")]
    public async Task<IActionResult> Deletes(int id)
    {
        RoomDetail? roomDetail = await _context.RoomDetails.FindAsync(id);
        if (roomDetail == null) return NotFound();
        return View(roomDetail);
    }
    [HttpPost("delete/{id}",Name ="room-delete")]
    //[ActionName("Deletes")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeletePost(int id)
    {
        RoomDetail? roomDetails = await _context.RoomDetails.FindAsync(id);
        if (roomDetails == null) return NotFound();
        _context.RoomDetails.Remove(roomDetails);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
