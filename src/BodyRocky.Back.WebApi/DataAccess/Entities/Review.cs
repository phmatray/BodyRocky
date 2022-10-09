﻿namespace BodyRocky.Back.WebApi.DataAccess.Entities;

public class Review
{
    public Guid ReviewID { get; set; } = default!;
    public int ReviewRating { get; set; } = default!;
    public string ReviewText { get; set; } = default!;
    
    // relation product
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = default!;
    
    // relation customer
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = default!;
    public bool ValidateEntity()
    {
        return true;
    }
}