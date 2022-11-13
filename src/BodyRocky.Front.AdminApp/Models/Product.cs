using System;
using BodyRocky.Core.Contracts.Responses;

namespace BodyRocky.Front.AdminApp.Models;

// TODO: Add a product to the catolog
// TODO: Delete a product from the catalog
// TODO: Update stock levels for a product
// TODO: List all products by category
// TODO: Update an order status (e.g. from "In Progress" to "Shipped")
// TODO: List all products for a given order
// TODO: List all orders for a given customer
// TODO: Display the total amount of sales for a given customer

public class Product
{
    public static Product From(ProductResponse response)
    {
        return new Product
        {
            ID = response.ProductID,
            Name = response.ProductName,
            Description = response.ProductDescription,
            ShortDescription = FormatDescription(response),
            Price = FormatPrice(response),
            URL = response.ProductURL,
            IsFeatured = response.IsFeatured,
            Stock = response.Stock,
            Category = response.ProductCategory
        };
    }

    private static string FormatDescription(ProductResponse response)
    {
        var description = response.ProductDescription;
        
        // take the first 50 characters
        // and add an ellipsis if the description is longer than 50 characters
        return description.Length > 50
            ? description.Substring(0, 50) + "..."
            : description;
    }

    private static string FormatPrice(ProductResponse response)
    {
        return response.ProductPrice.ToString("C");
    }

    public Guid ID { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string ShortDescription { get; private set; }
    public string Price { get; private set; }
    public string URL { get; private set; }
    public bool IsFeatured { get; private set; }
    public int Stock { get; private set; }
    public string Category { get; private set; }
}