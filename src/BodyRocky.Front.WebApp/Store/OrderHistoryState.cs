using BodyRocky.Shared;
using BodyRocky.Shared.Contracts.Requests;
using BodyRocky.Shared.Contracts.Responses;
using Fluxor;

namespace BodyRocky.Front.WebApp.Store;

#region State

public record OrderHistoryState(
    bool IsLoading,
    string? ErrorMessage,
    OrderResponse[] Orders)
{
    public bool HasError
        => ErrorMessage is not null;
}

public class OrderHistoryFeature : Feature<OrderHistoryState>
{
    public override string GetName()
        => "OrderHistory";

    protected override OrderHistoryState GetInitialState()
        => new(false, null, Array.Empty<OrderResponse>());
}

#endregion

#region Actions

public record LoadOrderHistoryAction(Guid CustomerID);
public record LoadOrderHistorySuccessAction(OrderResponse[] Orders);
public record LoadOrderHistoryFailureAction(string ErrorMessage);

#endregion

#region Reducers

public static class OrderHistoryReducers
{
    [ReducerMethod]
    public static OrderHistoryState ReduceLoadOrderHistoryAction(
        OrderHistoryState state,
        LoadOrderHistoryAction action)
        => state with { IsLoading = true, ErrorMessage = null };

    [ReducerMethod]
    public static OrderHistoryState ReduceLoadOrderHistorySuccessAction(
        OrderHistoryState state,
        LoadOrderHistorySuccessAction action)
        => state with { IsLoading = false, Orders = action.Orders };

    [ReducerMethod]
    public static OrderHistoryState ReduceLoadOrderHistoryFailureAction(
        OrderHistoryState state,
        LoadOrderHistoryFailureAction action)
        => state with { IsLoading = false, ErrorMessage = action.ErrorMessage };
}

#endregion

#region Effects

public class OrderHistoryEffects
{
    private readonly IBodyRockyApi _bodyRockyApi;
    
    public OrderHistoryEffects(IBodyRockyApi bodyRockyApi)
    {
        _bodyRockyApi = bodyRockyApi;
    }

    [EffectMethod]
    public async Task HandleLoadOrderHistoryAction(
        LoadOrderHistoryAction action,
        IDispatcher dispatcher)
    {
        try
        {
            var request = new GetAllOrdersByCustomerRequest
            {
                CustomerId = action.CustomerID
            };
            
            var response = await _bodyRockyApi.GetAllOrdersByCustomerAsync(request);
            var orders = response.Orders.ToArray();
            dispatcher.Dispatch(new LoadOrderHistorySuccessAction(orders));
        }
        catch (Exception ex)
        {
            dispatcher.Dispatch(new LoadOrderHistoryFailureAction(ex.Message));
        }
    }
}

#endregion

#region Strongly-typed dispatcher

public class OrderHistoryDispatcher
{
    private readonly IDispatcher _dispatcher;
    
    public OrderHistoryDispatcher(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }
    
    public void LoadOrderHistory(Guid customerID)
        => _dispatcher.Dispatch(new LoadOrderHistoryAction(customerID));
}

#endregion