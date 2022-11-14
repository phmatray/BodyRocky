namespace BodyRocky.Shared.Contracts.Responses;

public class GetAllZipCodesResponse
{
    public IEnumerable<ZipCodeResponse> ZipCodes { get; init; } = Enumerable.Empty<ZipCodeResponse>();
}