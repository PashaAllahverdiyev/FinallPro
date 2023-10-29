using Microsoft.AspNetCore.Http;

namespace Hotel.Business.ViewModels.RoomVM;

public class RoomListViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IFormFile MainImage { get; set; }
    public int Rating { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Price { get; set; }
    public string Status { get; set; }
    public string Images { get; set; }
}
