namespace BodyRocky.Core.Contracts.Responses.CustomerResponses;

public class CustomerResponse
{
    public Guid CustomerID { get; init; } = default!;
    public string FirstName { get; init; } = default!;
    public string LastName { get; init; } = default!;
    public DateTime BirthDate { get; init; }
    public string PhoneNumber { get; init; } = default!;
    public string EmailAddress { get; init; } = default!;
}