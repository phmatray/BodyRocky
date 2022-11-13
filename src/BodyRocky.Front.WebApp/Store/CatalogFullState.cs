using BodyRocky.Core.Contracts.Responses;
using Fluxor;

namespace BodyRocky.Front.WebApp.Store;

#region State

public record CatalogFullState(
    bool IsLoading,
    string? ErrorMessage,
    IEnumerable<ProductResponse> Products,
    IEnumerable<CategoryResponse> Categories,
    IEnumerable<BrandResponse> Brands)
{
    public bool HasError
        => ErrorMessage is not null;
}

public class CatalogFullFeature : Feature<CatalogFullState>
{
    public override string GetName()
        => "CatalogFull";

    protected override CatalogFullState GetInitialState()
        => new CatalogFullState(
            IsLoading: false,
            ErrorMessage: null,
            Products: Array.Empty<ProductResponse>(),
            Categories: Array.Empty<CategoryResponse>(),
            Brands: Array.Empty<BrandResponse>());
}

#endregion

#region Actions

public record LoadCatalogFullAction;

public record LoadCatalogFullSuccessAction(
    IEnumerable<ProductResponse> Products,
    IEnumerable<CategoryResponse> Categories,
    IEnumerable<BrandResponse> Brands);

public record LoadCatalogFullFailureAction(string ErrorMessage);

#endregion

#region Reducers

public static class CatalogFullReducers
{
    [ReducerMethod]
    public static CatalogFullState ReduceLoadCatalogFullAction(
        CatalogFullState state,
        LoadCatalogFullAction action)
        => state with
        {
            IsLoading = true,
            ErrorMessage = null
        };

    [ReducerMethod]
    public static CatalogFullState ReduceLoadCatalogFullSuccessAction(
        CatalogFullState state,
        LoadCatalogFullSuccessAction action)
        => state with
        {
            IsLoading = false,
            ErrorMessage = null,
            Products = action.Products,
            Categories = action.Categories,
            Brands = action.Brands
        };

    [ReducerMethod]
    public static CatalogFullState ReduceLoadCatalogFullFailureAction(
        CatalogFullState state,
        LoadCatalogFullFailureAction action)
        => state with
        {
            IsLoading = false,
            ErrorMessage = action.ErrorMessage
        };
}

#endregion

#region Effects

public class CatalogFullEffects
{
    private readonly IBodyRockyApi _bodyRockyClient;
    
    public CatalogFullEffects(IBodyRockyApi bodyRockyClient)
    {
        _bodyRockyClient = bodyRockyClient;
    }
    
    [EffectMethod]
    public async Task HandleLoadCatalogFullAction(
        LoadCatalogFullAction action,
        IDispatcher dispatcher)
    {
        try
        {
            GetCatalogFullResponse catalogFull = await _bodyRockyClient.GetCatalogFullAsync();
            
            LoadCatalogFullSuccessAction successAction = new(
                catalogFull.Products,
                catalogFull.Categories,
                catalogFull.Brands);
            
            dispatcher.Dispatch(successAction);
        }
        catch (Exception e)
        {
            string exceptionMessage = e.InnerException?.Message ?? e.Message;
            dispatcher.Dispatch(new LoadCatalogFullFailureAction(exceptionMessage));
        }
    }
}

#endregion

#region Strongly-typed dispatcher

public class CatalogFullDispatcher
{
    private readonly IDispatcher _dispatcher;

    public CatalogFullDispatcher(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    public void LoadCatalogFull()
        => _dispatcher.Dispatch(new LoadCatalogFullAction());
}

#endregion


