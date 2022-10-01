using BodyRocky.Back.WebApi.DataAccess.Entities;
using BodyRocky.Core.Contracts.Responses.BasketResponses;
using FastEndpoints;

namespace BodyRocky.Back.WebApi.Endpoints.Baskets.GetAll;

public class GetAllBasketsMapper 
    : ResponseMapper<GetAllBasketsResponse, List<Basket>>
{
    public override GetAllBasketsResponse FromEntity(List<Basket> baskets)
    {
        List<BasketResponse> basketResponses = baskets
            .Select(basket => new BasketResponse
            {
                BasketID = basket.BasketID,
                BasketDateAdded = basket.BasketDateAdded
            })
            .ToList();

        return new GetAllBasketsResponse()
        {
            Baskets = basketResponses
        };
    }
}