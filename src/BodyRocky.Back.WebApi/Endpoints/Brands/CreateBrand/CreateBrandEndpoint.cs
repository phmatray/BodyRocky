using System.ComponentModel;
using BodyRocky.Back.WebApi.DataAccess.Entities;
using BodyRocky.Back.WebApi.DataAccess.Repositories;
using BodyRocky.Core.Contracts.Requests.BrandRequests;
using BodyRocky.Core.Contracts.Responses.BrandResponses;
using FastEndpoints;

namespace BodyRocky.Back.WebApi.Endpoints.Brands.CreateBrand;

public class CreateBrandEndpoint
    : Endpoint<CreateBrandRequest, BrandResponse, CreateBrandMapper>
{
    private readonly BrandRepository _repository;

    public CreateBrandEndpoint(BrandRepository repository)
    {
        _repository = repository;
    }

    public override void Configure()
    {
        Post("/brands");
        AllowAnonymous();
    }

    public override async Task HandleAsync(
        CreateBrandRequest req,
        CancellationToken ct)
    {
        Brand brand = Map.ToEntity(req);
        await _repository.InsertAsync(brand);

        BrandResponse response = Map.FromEntity(brand);

        await SendOkAsync(
            response, ct);
    }
}