﻿namespace BodyRocky.Shared.Contracts.Responses;

public class ZipCodeResponse
{
    public int ZipCode { get; init; } = default!;
    public string Commune { get; init; } = default!;
}