namespace BodyRocky.Core.Contracts.Responses.AddressResponses.CustomerResponses;

public class GetAllCustomersResponse
{
    public IEnumerable<CustomerResponse> Customers { get; init; } = Enumerable.Empty<CustomerResponse>();
}