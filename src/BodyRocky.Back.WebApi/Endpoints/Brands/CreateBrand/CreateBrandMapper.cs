using BodyRocky.Back.WebApi.DataAccess.Entities;
using BodyRocky.Core.Contracts.Requests.BrandRequests;
using BodyRocky.Core.Contracts.Responses.BrandResponses;
using FastEndpoints;

namespace BodyRocky.Back.WebApi.Endpoints.Brands;

public class CreateBrandMapper
    : Mapper<CreateBrandRequest, BrandResponse, Brand>
{
    public override Brand ToEntity(CreateBrandRequest r)
    {
        return new Brand
        {
            BrandID = default,
            BrandName = r.BrandName,
            BrandLogo = r.BrandLogo
        };
    }

    public override BrandResponse FromEntity(Brand brand)
    {
        return new BrandResponse
        {
            BrandID = brand.BrandID,
            BrandName = brand.BrandName,
            BrandLogo = brand.BrandLogo
        };
    }
}