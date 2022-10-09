namespace BodyRocky.Back.WebApi.DataAccess.Entities;

public class Customer
{
    public Guid CustomerID { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public DateTime BirthDate { get; set; }
    public string Password { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string EmailAddress { get; set; } = default!;

    // relation addresses
    public IList<Address> Addresses { get; set; }
    
    // relation baskets
    public IList<Basket> Baskets { get; set; }
    
    // relation reviews
    public IList<Review> Reviews { get; set; }
    
    // relation orders
    public IList<Order> Orders { get; set; }
    public bool ValidateEntity()
    {
        return true;
    }
}