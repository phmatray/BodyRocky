using BodyRocky.Back.Server.DataAccess.Entities;
using BodyRocky.Back.Server.DataAccess.Repositories;
using BodyRocky.Shared.Contracts.Requests;
using BodyRocky.Shared.Contracts.Responses;
using FastEndpoints;

namespace BodyRocky.Back.Server.Endpoints.Catalog.CreateBrand;

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
        Post("catalog/brands");
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