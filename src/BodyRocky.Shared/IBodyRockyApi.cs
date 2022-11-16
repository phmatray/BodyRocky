using BodyRocky.Shared.Contracts.Requests;
using BodyRocky.Shared.Contracts.Responses;
using Refit;

namespace BodyRocky.Shared;

public interface IBodyRockyApi
{
    #region Baskets (with fastendpoints)
    
    [Post("/baskets/products")]
    Task AddProductToBasketAsync([Body] AddProductToBasketRequest request);
    
    [Get("/baskets/customer/{request.CustomerID}")]
    Task<GetOneBasketResponse> GetBasketAsync(GetBasketRequest request);
    
    #endregion
    
    #region Catalog (with fastendpoints)
    
    [Get("/catalog/overview")]
    Task<GetCatalogOverviewResponse> GetCatalogOverviewAsync();
    
    [Get("/catalog/full")]
    Task<GetCatalogFullResponse> GetCatalogFullAsync();
    
    [Get("/catalog/products")]
    Task<GetAllProductsResponse> GetAllProductsAsync();
    
    [Delete("/catalog/products/{request.ProductID}")]
    Task DeleteProductAsync([Body] DeleteProductRequest request);
    
    [Get("/catalog/categories")]
    Task<GetAllCategoriesResponse> GetAllCategoriesAsync();
    
    [Post("/catalog/brands")]
    Task<BrandResponse> CreateBrandAsync([Body] CreateBrandRequest request);
    
    #endregion
    
    #region CrudCustomer (with fastendpoints)
    
    [Get("/crud/customers")]
    Task<GetAllCustomersResponse> GetCustomersAsync();
    
    [Get("/crud/customers/{request.CustomerID}")]
    Task<CustomerDetailsResponse> GetCustomerAsync(GetCustomerRequest request);
    
    [Post("/crud/customers")]
    Task<CustomerDetailsResponse> CreateCustomerAsync([Body] CreateCustomerRequest request);
    
    [Put("/crud/customers")]
    Task<CustomerDetailsResponse> UpdateCustomerAsync([Body] UpdateCustomerRequest request);
    
    [Delete("/crud/customers/{request.CustomerID}")]
    Task DeleteCustomerAsync(DeleteCustomerRequest request);
    
    #endregion
}
