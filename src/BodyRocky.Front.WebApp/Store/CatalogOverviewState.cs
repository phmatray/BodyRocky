using BodyRocky.Shared;
using BodyRocky.Shared.Contracts.Responses;
using Fluxor;

namespace BodyRocky.Front.WebApp.Store;

#region State

public record CatalogOverviewState(
    bool IsLoading,
    string? ErrorMessage,
    IEnumerable<CategoryResponse> FeaturedCategories,
    IEnumerable<ProductResponse> FeaturedProducts,
    IEnumerable<ProductResponse> RecommendedProducts)
{
    public bool HasError
        => ErrorMessage is not null;
}

public class CatalogOverviewFeature : Feature<CatalogOverviewState>
{
    public override string GetName()
        => "CatalogOverview";

    protected override CatalogOverviewState GetInitialState()
        => new CatalogOverviewState(
            IsLoading: false,
            ErrorMessage: null,
            FeaturedCategories: Array.Empty<CategoryResponse>(),
            FeaturedProducts: Array.Empty<ProductResponse>(),
            RecommendedProducts: Array.Empty<ProductResponse>());
}

#endregion

#region Actions

public record LoadCatalogOverviewAction;


public record LoadCatalogOverviewSuccessAction(
    List<CategoryResponse> FeaturedCategories,
    List<ProductResponse> FeaturedProducts,
    List<ProductResponse> RecommendedProducts);

public record LoadCatalogOverviewFailureAction(string ErrorMessage);

#endregion

#region Reducers

public static class CatalogOverviewReducers
{
    [ReducerMethod]
    public static CatalogOverviewState ReduceLoadCatalogOverviewAction(
        CatalogOverviewState state,
        LoadCatalogOverviewAction action)
        => state with
        {
            IsLoading = true,
            ErrorMessage = null
        };

    [ReducerMethod]
    public static CatalogOverviewState ReduceLoadCatalogOverviewSuccessAction(
        CatalogOverviewState state,
        LoadCatalogOverviewSuccessAction action)
        => state with
        {
            IsLoading = false,
            ErrorMessage = null,
            FeaturedCategories = action.FeaturedCategories,
            FeaturedProducts = action.FeaturedProducts,
            RecommendedProducts = action.RecommendedProducts
        };

    [ReducerMethod]
    public static CatalogOverviewState ReduceLoadCatalogOverviewFailureAction(
        CatalogOverviewState state,
        LoadCatalogOverviewFailureAction action)
        => state with
        {
            IsLoading = false,
            ErrorMessage = action.ErrorMessage
        };
}

#endregion

#region Effects

public class CatalogOverviewEffects
{
    private readonly IBodyRockyApi _bodyRockyClient;
    
    public CatalogOverviewEffects(IBodyRockyApi bodyRockyClient)
    {
        _bodyRockyClient = bodyRockyClient;
    }

    [EffectMethod]
    public async Task HandleLoadCatalogOverviewAction(
        LoadCatalogOverviewAction action,
        IDispatcher dispatcher)
    {
        try
        {
            GetCatalogOverviewResponse catalogOverview = await _bodyRockyClient.GetCatalogOverviewAsync();

            var successAction = new LoadCatalogOverviewSuccessAction(
                catalogOverview.FeaturedCategories,
                catalogOverview.FeaturedProducts,
                catalogOverview.RecommendedProducts);
            
            dispatcher.Dispatch(successAction);
        }
        catch (Exception e)
        {
            string exceptionMessage = e.InnerException?.Message ?? e.Message;
            dispatcher.Dispatch(new LoadCatalogOverviewFailureAction(exceptionMessage));
        }
    }
}

#endregion

#region Strongly-typed dispatcher

public class CatalogOverviewDispatcher
{
    private readonly IDispatcher _dispatcher;

    public CatalogOverviewDispatcher(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    public void LoadCatalogOverview()
        => _dispatcher.Dispatch(new LoadCatalogOverviewAction());
}

#endregion


