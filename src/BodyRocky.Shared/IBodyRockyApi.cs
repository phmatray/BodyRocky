using BodyRocky.Shared.Contracts.Requests;
using BodyRocky.Shared.Contracts.Responses;
using Refit;

namespace BodyRocky.Shared;

public interface IBodyRockyApi
{
    #region Account
    
    [Post("/accounts/register")]
    Task<SignupResponse> RegisterAsync([Body] SignupRequest request);
    
    [Post("/accounts/login")]
    Task<LoginResponse> LoginAsync([Body] LoginRequest request);

    [Get("/accounts/customers")]
    Task<GetAllCustomersResponse> GetCustomersAsync();
    
    [Get("/accounts/customers/{request.CustomerID}")]
    Task<CustomerDetailsResponse> GetCustomerAsync(GetCustomerRequest request);
    
    [Post("/accounts/customers")]
    Task<CustomerDetailsResponse> CreateCustomerAsync([Body] CreateCustomerRequest request);
    
    [Put("/accounts/customers")]
    Task<CustomerDetailsResponse> UpdateCustomerAsync([Body] UpdateCustomerRequest request);
    
    [Delete("/accounts/customers/{request.CustomerID}")]
    Task DeleteCustomerAsync(DeleteCustomerRequest request);
    
    #endregion
    
    #region Baskets
    
    [Post("/baskets/products")]
    Task AddProductToBasketAsync([Body] AddProductToBasketRequest request);
    
    #endregion
    
    #region Catalog
    
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
}