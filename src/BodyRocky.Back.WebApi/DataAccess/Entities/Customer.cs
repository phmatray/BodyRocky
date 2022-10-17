using Microsoft.AspNetCore.Identity;

namespace BodyRocky.Back.WebApi.DataAccess.Entities;

public class Customer : IdentityUser<Guid>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public DateTime BirthDate { get; set; }

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