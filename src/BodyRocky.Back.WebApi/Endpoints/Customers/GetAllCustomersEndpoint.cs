using BodyRocky.Core.Contracts.Responses.CustomerResponses;
using FastEndpoints;

namespace BodyRocky.Back.WebApi.Endpoints.Customers;

public class GetAllCustomersEndpoint
    : EndpointWithoutRequest<GetAllCustomersResponse>
{
    public override void Configure()
    {
        Get("/customers");
        AllowAnonymous();
    }

    public override async Task<GetAllCustomersResponse> ExecuteAsync(CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}