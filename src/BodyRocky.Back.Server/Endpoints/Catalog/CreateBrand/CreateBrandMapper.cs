using BodyRocky.Back.Server.DataAccess.Entities;
using BodyRocky.Shared.Contracts.Requests;
using BodyRocky.Shared.Contracts.Responses;
using FastEndpoints;

namespace BodyRocky.Back.Server.Endpoints.Catalog.CreateBrand;

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