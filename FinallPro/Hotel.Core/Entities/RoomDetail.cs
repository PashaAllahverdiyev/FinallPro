namespace Hotel.Core.Entities;

public class RoomDetail:BaseEntity
{
    public string Description { get; set; }
    public bool Service { get; set; }
    public bool MiniBar { get; set; }
    public bool Tv { get; set; }
    public bool AirController { get; set; }
}
