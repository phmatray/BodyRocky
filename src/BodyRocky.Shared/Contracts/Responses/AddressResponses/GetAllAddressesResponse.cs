﻿namespace BodyRocky.Shared.Contracts.Responses;

public class GetAllAddressResponse
{
    public IEnumerable<AddressResponse> Addresses { get; init; } = Enumerable.Empty<AddressResponse>();
}