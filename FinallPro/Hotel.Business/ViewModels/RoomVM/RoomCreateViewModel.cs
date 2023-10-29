using Hotel.Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Hotel.Business.ViewModels.RoomVM;

public class RoomCreateViewModel
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public IFormFile MainImage { get; set; }
    public List<int> SizeIds { get; set; }
    public List<IFormFile> Images { get; set; }
    public int RoomLandScapeId { get; set; }
    public int BathRoomId { get; set; }
    public int RoomDetailId { get; set; }
    public int HotelId { get; set; }
}
