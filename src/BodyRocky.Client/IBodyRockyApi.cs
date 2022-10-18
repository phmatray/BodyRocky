using BodyRocky.Core.Contracts.Requests.AccountRequests;
using BodyRocky.Core.Contracts.Requests.CustomerRequests;
using BodyRocky.Core.Contracts.Responses.AccountResponses;
using BodyRocky.Core.Contracts.Responses.CatalogResponses;
using BodyRocky.Core.Contracts.Responses.CategoryResponses;
using BodyRocky.Core.Contracts.Responses.CustomerResponses;
using BodyRocky.Core.Contracts.Responses.ProductResponses;
using Refit;

namespace BodyRocky.Client;

public interface IBodyRockyApi
{
    #region Account
    
    [Post("/accounts/register")]
    Task<SignupResponse> RegisterAsync([Body] SignupRequest request);
    
    [Post("/accounts/login")]
    Task<LoginResponse> LoginAsync([Body] LoginRequest request);
    
    #endregion
    
    #region Catalog
    
    [Get("/catalog/overview")]
    Task<GetCatalogOverviewResponse> GetCatalogOverviewAsync();
    
    [Get("/catalog/full")]
    Task<GetCatalogFullResponse> GetCatalogFullAsync();
    
    [Get("/catalog/products")]
    Task<GetAllProductsResponse> GetAllProductsAsync();
    
    #endregion
    
    [Get("/categories")]
    Task<GetAllCategoriesResponse> GetAllCategoriesAsync();

    [Get("/customers")]
    Task<GetAllCustomersResponse> GetCustomersAsync();
    
    [Get("/customers/{request.CustomerID}")]
    Task<CustomerResponse> GetCustomerAsync(GetCustomerRequest request);
    
    [Post("/customers")]
    Task<CustomerResponse> CreateCustomerAsync([Body] CreateCustomerRequest request);
    
    [Put("/customers")]
    Task<CustomerResponse> UpdateCustomerAsync([Body] UpdateCustomerRequest request);
    
    [Delete("/customers/{request.CustomerID}")]
    Task DeleteCustomerAsync(DeleteCustomerRequest request);
}