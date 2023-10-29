namespace Hotel.Core.Entities;

public class Order : BaseEntity
{
    public decimal TotalPrice { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set;}
}
