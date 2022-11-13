namespace BodyRocky.Core.Contracts.Responses;

public class CustomerDetailsResponse
{
    public Guid CustomerID { get; init; } = default!;
    public string FirstName { get; init; } = default!;
    public string LastName { get; init; } = default!;
    public DateTime BirthDate { get; init; }
    public string PhoneNumber { get; init; } = default!;
    public string EmailAddress { get; init; } = default!;
    public BasketResponse CurrentBasket { get; init; } = default!;
}