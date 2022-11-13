namespace BodyRocky.Core.Contracts.Responses;

public class AddressResponse
{
    public Guid AddressID { get; init; } = default!;
    public DateTime AddressFromDate { get; init; } = default!;
    public DateTime AddressToDate { get; init; } = default!;
    public string Street { get; init; } = default!;
}