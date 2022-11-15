using BodyRocky.Shared.Contracts.Requests;
using BodyRocky.Shared.Contracts.Responses;
using BodyRocky.Shared.Forms;
using Refit;

namespace BodyRocky.Shared;

public interface IBodyRockyApi
{
    #region Authorize
    
    [Get("/authorize/user-info")]
    Task<UserInfo> GetUserInfoAsync();
    
    [Post("/authorize/login")]
    Task LoginAsync([Body] LoginParameters parameters);
    
    [Post("/authorize/logout")]
    Task LogoutAsync();
    
    [Post("/authorize/register")]
    Task RegisterAsync([Body] RegisterParameters parameters);
    
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
    
    #region CrudCustomer
    
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








// Il m’est donc impossible de continuer a assurer mes cours. 


// Je vous prie de bien vouloir m’excuser pour ce qui s’est passe et de croire, Madame, a l’assurance de ma plus haute consideration.

// Cordialement,



// Dans ces circonstances, je ne peux que vous presenter mes excuses et remettre ma demission.

// necessite un arret complet de mes activites pour une periode indeterminee.