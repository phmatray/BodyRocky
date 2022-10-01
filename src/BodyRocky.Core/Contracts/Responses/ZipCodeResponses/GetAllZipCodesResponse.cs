namespace BodyRocky.Core.Contracts.Responses.ZipCodeResponses;

public class GetAllZipCodesResponse
{
    public IEnumerable<ZipCodeResponse> ZipCodes { get; init; } = Enumerable.Empty<ZipCodeResponse>();
}