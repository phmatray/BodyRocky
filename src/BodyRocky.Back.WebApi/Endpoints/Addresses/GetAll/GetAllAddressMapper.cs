using BodyRocky.Back.WebApi.DataAccess.Entities;
using BodyRocky.Core.Contracts.Responses.AddressResponses;
using FastEndpoints;

namespace BodyRocky.Back.WebApi.Endpoints.Addresses.GetAll;

public class GetAllAddressMapper
    : ResponseMapper<GetAllAddressResponse, List<Address>>
{
    public override GetAllAddressResponse FromEntity(List<Address> addresses)
    {
        List<AddressResponse> addressResponses = addresses
            .Select(address => new AddressResponse
            {
                AddressID = address.AddressID,
                AddressFromDate = address.AddressFromDate,
                AddressToDate = address.AddressToDate,
                Street = address.Street
            })
            .ToList();
        
        return new GetAllAddressResponse()
        {
            Addresses = addressResponses
        };
    }
}