using FastEndpoints;

namespace BodyRocky.Back.Server.Endpoints.Catalog.GetAllProducts;

public class GetAllProductsMapper
    : ResponseMapper<GetAllProductsResponse, List<Product>>
{
    public override GetAllProductsResponse FromEntity(List<Product> products)
    {
        List<ProductResponse> productResponses = products
            .Select(product => new ProductResponse
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                ProductPrice = product.ProductPrice,
                ProductURL = product.ProductURL,
                IsFeatured = product.IsFeatured,
                Stock = product.Stock,
            })
            .ToList();

        return new GetAllProductsResponse()
        {
            Products = productResponses
        };
    }
}