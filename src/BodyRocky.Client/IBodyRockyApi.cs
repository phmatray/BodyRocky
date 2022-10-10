using BodyRocky.Core.Contracts.Requests.CustomerRequests;
using BodyRocky.Core.Contracts.Responses.CustomerResponses;
using Refit;

namespace BodyRocky.Client;

public interface IBodyRockyApi
{
    #region Customers

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

    #endregion
}