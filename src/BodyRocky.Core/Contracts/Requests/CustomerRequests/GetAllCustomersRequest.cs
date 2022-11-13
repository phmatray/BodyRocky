namespace BodyRocky.Core.Contracts.Requests;

public class GetAllCustomersRequest
{
    public int Skip { get; init; }
    public int Take { get; init; }
}