using FastEndpoints;

namespace BodyRocky.Back.Server.Endpoints.Catalog.GetAllCategories;

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
                ProductCount = category.ProductCategories.Count
            })
            .ToList();

        return new GetAllCategoriesResponse
        {
            Categories = categoryResponses
        };
    }
}