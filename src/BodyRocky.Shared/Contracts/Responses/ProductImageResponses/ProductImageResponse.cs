﻿namespace BodyRocky.Shared.Contracts.Responses;

public class ProductImageResponse
{
    public Guid ProductImageID { get; init; } = default!;
    public string Image { get; init; } = default!;
    public bool IsFeatured { get; init; } = default!;
}