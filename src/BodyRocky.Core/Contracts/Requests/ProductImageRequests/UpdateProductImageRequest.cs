﻿namespace BodyRocky.Core.Contracts.Requests.ProductImageRequests;

public class UpdateProductImageRequest
{
    public Guid ProductImageID { get; init; } = default!;
    public string Image { get; init; } = default!;
    public bool IsFeatured { get; init; } = default!;
}