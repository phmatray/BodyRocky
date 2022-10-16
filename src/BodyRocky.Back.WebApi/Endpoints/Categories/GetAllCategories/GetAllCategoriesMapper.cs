using BodyRocky.Back.WebApi.DataAccess.Entities;
using BodyRocky.Core.Contracts.Responses.CategoryResponses;
using FastEndpoints;

namespace BodyRocky.Back.WebApi.Endpoints.Categories.GetAllCategories;

public class GetAllCategoriesMapper
    : ResponseMapper<GetAllCategoriesResponse, List<Category>>
{
    public override GetAllCategoriesResponse FromEntity(List<Category> categories)
    {
        List<CategoryResponse> categoryResponses = categories
            .Select(category => new CategoryResponse
            {
                CategoryID = category.CategoryID,
                CategoryName = category.CategoryName,
                CategoryImage = category.CategoryImage,
                CategoryIcon = category.CategoryIcon,
                IsFeatured = category.IsFeatured,
            })
            .ToList();

        return new GetAllCategoriesResponse()
        {
            Categories = categoryResponses
        };
    }
}