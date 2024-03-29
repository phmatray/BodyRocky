﻿namespace BodyRocky.Back.Server.DataAccess.Entities;

public class Product
{
    public Guid ProductID { get; set; } = default!;
    public string ProductName { get; set; } = default!;
    public string ProductDescription { get; set; } = default!;
    public decimal ProductPrice { get; set; } = default!;
    public string ProductURL { get; set; } = default!;
    public bool IsFeatured { get; set; } = default!;
    public int Stock { get; set; }

    // relation brand
    public Guid BrandID { get; set; } = default!;
    public Brand Brand { get; set; } = default!;
    
    // relation product images
    public IList<ProductImage> ProductImages { get; set; }
    
    // relation reviews
    public IList<Review> Reviews { get; set; }
    // relation categories
    public IList<ProductCategory> ProductCategories { get; set; }
    
    // relation baskets
    public IList<BasketProduct> BasketProducts { get; set; }
    
    // relation orderedProducts
    public IList<OrderedProduct> OrderedProducts { get; set; }

    public bool ValidateEntity()
    {
        return true;
    }
}