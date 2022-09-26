namespace BodyRocky.Core.Contracts.Responses.AddressResponses;

public class GetAllAddressResponse
{
    public IEnumerable<AddressResponse> Addresses { get; init; } = Enumerable.Empty<AddressResponse>();
}