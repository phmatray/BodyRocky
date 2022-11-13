﻿namespace BodyRocky.Core.Contracts.Requests;

public class CreateZipCodeRequest
{
    public int ZipCode { get; init; } = default!;
    public string Commune { get; init; } = default!;
}