﻿using BodyRocky.Back.WebApi.DataAccess.Repositories;
using BodyRocky.Core.Contracts.Requests.CustomerRequests;
using FastEndpoints;

namespace BodyRocky.Back.WebApi.Endpoints.Customers.DeleteCustomer;

public class DeleteCustomerEndpoint
    : Endpoint<DeleteCustomerRequest>
{
    private readonly CustomerRepository _repository;

    public DeleteCustomerEndpoint(CustomerRepository repository)
    {
        _repository = repository;
    }

    public override void Configure()
    {
        Delete("/customers/{CustomerID}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(
        DeleteCustomerRequest req,
        CancellationToken ct)
    {
        bool isIDGuid = Guid.TryParse(req.CustomerID, out Guid customerID);

        if (!isIDGuid)
        {
            throw new Exception("customerID is not a valid GUID");
        }
        
        await _repository.DeleteAsync(customerID);
        await SendOkAsync(ct);
    }
}