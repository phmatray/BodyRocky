﻿namespace BodyRocky.Shared.Contracts.Requests;

public class UpdateZipCodeRequest
{
    public int ZipCode { get; init; } = default!;
    public string Commune { get; init; } = default!;
}