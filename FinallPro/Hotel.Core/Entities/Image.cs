namespace Hotel.Core.Entities;

public class Image:BaseEntity
{
    public string? Url { get; set; }
    public bool? IsMain { get; set; } = false;
    public int? HotellId { get; set; }
    public Hotell Hotells { get; set; }
    public int? RoomId { get; set; }
    public Room Rooms { get; set; }
}

