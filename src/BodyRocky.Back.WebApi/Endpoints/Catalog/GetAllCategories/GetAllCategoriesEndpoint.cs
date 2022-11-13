using BodyRocky.Back.WebApi.DataAccess.Entities;
using BodyRocky.Back.WebApi.DataAccess.Repositories;
using BodyRocky.Core.Contracts.Requests;
using BodyRocky.Core.Contracts.Responses;
using FastEndpoints;

namespace BodyRocky.Back.WebApi.Endpoints.Catalog.GetAllCategories;

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