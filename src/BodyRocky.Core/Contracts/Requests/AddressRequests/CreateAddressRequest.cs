namespace BodyRocky.Core.Contracts.Requests;

public class CreateAddressRequest
{
    public Guid AddressID { get; init; } = default!;
    public DateTime AddressFromDate { get; init; } = default!;
    public DateTime AddressToDate { get; init; } = default!;
    public string Street { get; init; } = default!;
}