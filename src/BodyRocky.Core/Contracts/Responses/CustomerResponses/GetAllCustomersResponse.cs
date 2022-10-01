namespace BodyRocky.Core.Contracts.Responses.CustomerResponses;

public class GetAllCustomersResponse
{
    public IEnumerable<CustomerResponse> Customers { get; init; } = Enumerable.Empty<CustomerResponse>();
}