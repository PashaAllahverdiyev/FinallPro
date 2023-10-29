using Hotel.Business.Services.Interfaces;
using Hotel.Business.Utilities;
using Hotel.Business.ViewModels.RoomVM;
using Hotel.Core.Entities;
using Hotel.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoomController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webEnv;
        private readonly IFileService _fileservice;
        public RoomController(AppDbContext context,
                                IWebHostEnvironment webEnv,
                                IFileService fileservice)
        {
            _context = context;
            _webEnv = webEnv;
            _fileservice = fileservice;
        }
        public IActionResult Index()
        {
            List<RoomListViewModel> product = _context.Rooms.Select(p => new RoomListViewModel()
            {
                Name = p.Name,
                Images = p.Images.FirstOrDefault(i => i.IsMain.Equals(true)).Url,
            }).ToList();


            return View(product);
        }
        public IActionResult Create()
        {
            ViewBag.Sizes = _context.Sizes.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomCreateViewModel model)
        {
            ViewBag.Sizes = _context.Sizes.ToList();

            string filename = string.Empty;
            Room newRoom = new()
            {
                Name = model.Name,
                Price = model.Price,
                BathRoomId = model.BathRoomId,
                RoomDetailId = model.RoomDetailId,
                HotellId = model.HotelId,
            };
            filename = await _fileservice.UploadFile(model.MainImage, _webEnv.WebRootPath, 300, "assets", "images", "slider");
            Image MainImage = new()
            {
                IsMain = true,
                Url = filename
            };
            newRoom.Images.Add(MainImage);
            foreach (IFormFile image in model.Images)
            {
                if (!image.CheckFileSize(1000))
                {
                    return View(nameof(Create));
                };
                if (!image.CheckFileType("image/"))
                {
                    return View(nameof(Create));
                }
                Image NotMainImage = new()
                {
                    IsMain = false,
                    Url = filename
                };
                newRoom.Images.Add(NotMainImage);

            }
         
            foreach (int id in model.SizeIds)
            {
                RoomSize roomSize = new()
                {
                    SizeId = id,
                };
                newRoom.Sizes.Add(roomSize);
            }
            _context.Rooms.Add(newRoom);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
