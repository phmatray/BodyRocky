namespace BodyRocky.Core.Contracts.Requests;

public class UpdateCustomerRequest
{
    public Guid CustomerID { get; init; } = default!;
    public string FirstName { get; init; } = default!;
    public string LastName { get; init; } = default!;
    public DateTime BirthDate { get; init; }
    public string PhoneNumber { get; init; } = default!;
    public string EmailAddress { get; init; } = default!;
}