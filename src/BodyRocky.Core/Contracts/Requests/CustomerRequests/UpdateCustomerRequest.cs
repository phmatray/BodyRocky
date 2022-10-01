namespace BodyRocky.Core.Contracts.Requests.CustomerRequests;

public class UpdateCustomerRequest
{
    public Guid CustomerID { get; init; } = default!;
    public string FirstName { get; init; } = default!;
    public string LastName { get; init; } = default!;
    public DateTime BirthDame { get; init; }
    public string Password { get; init; } = default!;
    public string PhoneNumber { get; init; } = default!;
    public string EmailAddress { get; init; } = default!;
}