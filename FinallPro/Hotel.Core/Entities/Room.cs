namespace Hotel.Core.Entities;

public class Room : BaseEntity
{
    public string Name { get; set; }
    public List<Image> Images { get; set; }
    public ICollection<RoomSize> Sizes { get; set; }
    public int Rating { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Price { get; set; }
    public string Status { get; set; }
    public int RoomLandScapeId { get; set; }
    public RoomLandScape RoomLandScape { get; set; }
    public int BathRoomId { get; set; }
    public Bathroom Bathroom { get; set; }
    public int RoomDetailId { get; set; }
    public RoomDetail RoomDetail { get; set; }
    public int HotellId { get; set; }
    public Hotell Hotells { get; set; }
    public Room()
    {
        Images = new();
    }
}
