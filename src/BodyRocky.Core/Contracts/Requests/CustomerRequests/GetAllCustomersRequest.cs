namespace BodyRocky.Core.Contracts.Requests.CustomerRequests;

public class GetAllCustomersRequest
{
    public int Skip { get; init; }
    public int Take { get; init; }
}