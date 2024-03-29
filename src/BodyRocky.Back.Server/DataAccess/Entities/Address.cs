﻿namespace BodyRocky.Back.Server.DataAccess.Entities;

public class Address
{
    public Guid AddressID { get; set; } = default!;
    public DateTime AddressFromDate { get; set; } = default!;
    public DateTime AddressToDate { get; set; } = default!;
    public string Street { get; set; } = default!;
    
    // relation customer
    public Guid CustomerID { get; set; }
    public Customer Customer { get; set; } = default!;
    
    // relation zipCode
    public Guid ZipCodeID { get; set; }
    public ZipCode ZipCode { get; set; } = default!;
    
    // relation orders
    public IList<Order> BilledOrders { get; set; }
    public IList<Order> DeliveredOrders { get; set; }
    
    public bool ValidateEntity()
    {
        return true;
    }
}