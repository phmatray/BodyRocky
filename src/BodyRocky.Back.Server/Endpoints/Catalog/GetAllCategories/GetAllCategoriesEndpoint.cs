using BodyRocky.Back.Server.DataAccess.Entities;
using BodyRocky.Back.Server.DataAccess.Repositories;
using BodyRocky.Shared.Contracts.Requests;
using BodyRocky.Shared.Contracts.Responses;
using FastEndpoints;

namespace BodyRocky.Back.Server.Endpoints.Catalog.GetAllCategories;

public class GetAllCategoriesEndpoint
    : Endpoint<GetAllCategoriesRequest, GetAllCategoriesResponse, GetAllCategoriesMapper>
{
    private readonly CategoryRepository _repository;

    public GetAllCategoriesEndpoint(CategoryRepository repository)
    {
        _repository = repository;
    }

    public override void Configure()
    {
        Get("catalog/categories");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetAllCategoriesRequest req, CancellationToken ct)
    {
        List<Category> categories = await _repository.GetAllAsync();
        GetAllCategoriesResponse response = Map.FromEntity(categories);
        await SendOkAsync(response, ct);
    }
}