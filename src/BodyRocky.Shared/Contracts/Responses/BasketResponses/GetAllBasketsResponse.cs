﻿namespace BodyRocky.Shared.Contracts.Responses;

public class GetAllBasketsResponse
{
    public IEnumerable<BasketResponse> Baskets { get; init; } = Enumerable.Empty<BasketResponse>();
}