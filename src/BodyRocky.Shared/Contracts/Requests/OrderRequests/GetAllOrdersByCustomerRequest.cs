namespace BodyRocky.Shared.Contracts.Requests;

public class GetAllOrdersByCustomerRequest
{
    public Guid CustomerId { get; set; }
}