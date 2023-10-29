namespace Hotel.Core.Entities;

public class OrderItem : BaseEntity
{
  public int OrderId { get; set; }
    public Order Order { get; set; }
    public int RoomId { get; set; }
    public Room Room { get; set; }

    public int Count { get; set; }
    public int Size { get; set; }
    public decimal Price { get; set; }
}
