using Hotel.Business.ViewModels.HotelDetailVM;
using Hotel.Core.Entities;
using Hotel.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel.UI.Areas.Admin.Controllers;
[Area("Admin")]

public class HotelDetailController : Controller
{

    private readonly AppDbContext _context;

    public HotelDetailController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Index(int id)
    {
        HotelDetail hotelDetail = _context.HotelDetails.FirstOrDefault(h => h.Id == id);
        List<HotelDetail> hotelDetails = _context.HotelDetails.ToList();
        return View(hotelDetails);
    }
    public async Task<IActionResult> Details(int id)
    {
        HotelDetail? hotelDetail = await _context.HotelDetails.AsNoTracking().FirstOrDefaultAsync(h => h.Id == id);
        if (hotelDetail == null) return NotFound();
        return View(hotelDetail);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(HotelDetailCreatViewModel hotel)
    {
        if (!ModelState.IsValid) return View(hotel);
        HotelDetail hotelDetails = new()
        {
            CityLandScare = hotel.CityLandScare,
            IndoorSwimmingPoor = hotel.IndoorSwimmingPoor,
            FreeParking = hotel.FreeParking,
            FreeWiFi = hotel.FreeWiFi,
            DailyHouseKeeping = hotel.DailyHouseKeeping,
            SafeBox = hotel.SafeBox,
        };
        await _context.HotelDetails.AddAsync(hotelDetails);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(int id)
    {
        HotelDetail? hotelDetail = await _context.HotelDetails.FindAsync(id);
        if (hotelDetail == null) return NotFound();
        return View(hotelDetail);
    }
    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeletePost(int id)
    {
        HotelDetail? hotelDetails = await _context.HotelDetails.FindAsync(id);
        if (hotelDetails == null) return NotFound();
        _context.HotelDetails.Remove(hotelDetails);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
