﻿namespace BodyRocky.Core.Contracts.Responses.ProductResponses;

public class ProductResponse
{
    public Guid ProductID { get; init; } = default!;
    public string ProductName { get; init; } = default!;
    public string ProductDescription { get; init; } = default!;
    public decimal ProductPrice { get; init; } = default!;
    public string ProductURL { get; init; } = default!;
    public bool IsFeatured { get; init; } = default!;
}