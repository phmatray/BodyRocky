using Fluxor;

namespace BodyRocky.Front.WebApp.Store;

#region State

[FeatureState(Name = "Products")]
public record ProductState(
    List<ProductResponse> Products,
    bool IsLoading,
    string? ErrorMessage)
{
    private ProductState()
        : this(new(), false, null)
    {
    }
}

#endregion

#region Actions

public record GetProductsAction;
public record GetProductsSuccessAction(List<ProductResponse> Products);
public record GetProductsFailureAction(string ErrorMessage);

#endregion

#region Reducers

public static class ProductReducers
{
    [ReducerMethod]
    public static ProductState ReduceGetProductsAction(ProductState state, GetProductsAction action)
    {
        return state with { IsLoading = true, ErrorMessage = null };
    }

    [ReducerMethod]
    public static ProductState ReduceGetProductsSuccessAction(ProductState state, GetProductsSuccessAction action)
    {
        return state with { IsLoading = false, Products = action.Products };
    }

    [ReducerMethod]
    public static ProductState ReduceGetProductsFailureAction(ProductState state, GetProductsFailureAction action)
    {
        return state with { IsLoading = false, ErrorMessage = action.ErrorMessage };
    }
}

#endregion

#region Effects

public class ProductEffects
{
    private readonly IBodyRockyApi _bodyRockyClient;

    public ProductEffects(IBodyRockyApi bodyRockyClient)
    {
        _bodyRockyClient = bodyRockyClient;
    }
    
    [EffectMethod]
    public async Task HandleGetProductsAction(GetProductsAction action, IDispatcher dispatcher)
    {
        try
        {
            GetAllProductsResponse response = await _bodyRockyClient.GetAllProductsAsync();
            dispatcher.Dispatch(new GetProductsSuccessAction(response.Products.ToList()));
        }
        catch (Exception e)
        {
            dispatcher.Dispatch(new GetProductsFailureAction(e.Message));
        }
    }
}

#endregion

#region Strongly-typed dispatcher

public class ProductDispatcher
{
    private readonly IDispatcher _dispatcher;
    
    public ProductDispatcher(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }
    
    public void GetProducts()
    {
        _dispatcher.Dispatch(new GetProductsAction());
    }
}

#endregion