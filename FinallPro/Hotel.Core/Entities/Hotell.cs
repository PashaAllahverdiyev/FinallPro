namespace Hotel.Core.Entities;

public class Hotell : BaseEntity
{
        public string Name { get; set; }
        public List<Image> Images { get; set; }
    public Hotell()
    {
        Images = new();
    }
    public string Location { get; set; }
        public int Rating { get; set; }
        public int HotelDetailId { get; set; }
        public HotelDetail HotelDetail { get; set; }
        public ICollection<Room> Rooms { get; set; }
}
