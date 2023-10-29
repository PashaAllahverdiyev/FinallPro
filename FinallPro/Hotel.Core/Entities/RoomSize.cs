namespace Hotel.Core.Entities;

public class RoomSize : BaseEntity
{
    public int RoomId { get; set; }
    public Room Room { get; set; }
    public int SizeId { get; set; }
    public Size Size { get; set; }
}
