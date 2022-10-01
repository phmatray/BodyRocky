﻿namespace BodyRocky.Core.Contracts.Responses.CategoryResponses;

public class CategoryResponse
{
    public Guid CategoryID { get; init; } = default!;
    public string CategoryName { get; init; } = default!;
    public bool IsFeatured { get; init; } = default!;
}