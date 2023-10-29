namespace Hotel.Core.Entities;

public class Bathroom : BaseEntity
{
    public bool Shower { get; set; }
    public bool Toileet { get; set; }
    public bool BathroomSupplies { get; set; }
    public bool Dressing { get; set; }
}
