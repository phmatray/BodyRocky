using System.Globalization;
using Blazored.Toast;
using Blazored.Toast.Services;
using BodyRocky.Front.WebApp.Shared.Toasts;
using BodyRocky.Shared;
using BodyRocky.Shared.Contracts.Requests;
using BodyRocky.Shared.Contracts.Responses;
using Fluxor;

namespace BodyRocky.Front.WebApp.Store;

#region State

public record ProductQuantity(
    ProductResponse Product,
    int Quantity);

[FeatureState(Name = "Basket")]
public record BasketState(
    List<ProductQuantity> ProductQuantities)
{
    private BasketState()
        : this(new List<ProductQuantity>())
    {
        
    }
    
    public string TotalPrice => ProductQuantities
        .Sum(x => x.Product.ProductPrice * x.Quantity)
        .ToString("F2", CultureInfo.InvariantCulture)
        .Replace(".", ",");
    
    public int TotalQuantity => ProductQuantities.Sum(x => x.Quantity);
}

#endregion

#region Actions

public record AddToBasketAction(ProductResponse Product, int Quantity);
public record RemoveFromBasketAction(Guid ProductId, int Quantity);
public record ClearBasketAction;
public record PlaceOrderAction;

#endregion

#region Reducers

public static class BasketReducers
{
    [ReducerMethod]
    public static BasketState ReduceAddToBasketAction(BasketState state, AddToBasketAction action)
    {
        bool isAlreadyInBasket = state
            .ProductQuantities
            .Any(x => x.Product.ProductID == action.Product.ProductID);

        List<ProductQuantity> productQuantities;
        if (isAlreadyInBasket)
        {
            productQuantities = state.ProductQuantities
                .Select(x => x.Product.ProductID == action.Product.ProductID
                    ? x with { Quantity = x.Quantity + action.Quantity }
                    : x)
                .ToList();
        }
        else
        {
            productQuantities = state.ProductQuantities
                .Append(new(action.Product, action.Quantity))
                .ToList();
        }

        return new(productQuantities);
    }
    
    [ReducerMethod]
    public static BasketState ReduceRemoveFromBasketAction(BasketState state, RemoveFromBasketAction action)
    {
        ProductQuantity productQuantity = state
            .ProductQuantities
            .Single(x => x.Product.ProductID == action.ProductId);

        List<ProductQuantity> productQuantities;
        if (productQuantity.Quantity - action.Quantity > 0)
        {
            productQuantities = state.ProductQuantities
                .Select(x => x.Product.ProductID == action.ProductId
                    ? x with { Quantity = x.Quantity - action.Quantity }
                    : x)
                .ToList();
        }
        else
        {
            productQuantities = state.ProductQuantities
                .Where(x => x.Product.ProductID != action.ProductId)
                .ToList();
        }

        return new(productQuantities);
    }
    
    [ReducerMethod]
    public static BasketState ReduceClearBasketAction(BasketState state, ClearBasketAction action)
    {
        return state with { ProductQuantities = new() };
    }
    
    [ReducerMethod]
    public static BasketState ReducePlaceOrderAction(BasketState state, PlaceOrderAction action)
    {
        return state with { ProductQuantities = new() };
    }
}

#endregion

#region Effects

public class BasketEffects
{
    private readonly IBodyRockyApi _bodyRockyClient;
    private readonly IToastService _toastService;
    private readonly AuthState _authState;
    
    public BasketEffects(
        IBodyRockyApi bodyRockyClient,
        IToastService toastService,
        IState<AuthState> authState)
    {
        _bodyRockyClient = bodyRockyClient;
        _toastService = toastService;
        _authState = authState.Value;
    }
    
    [EffectMethod]
    public async Task HandleAddToBasketAction(AddToBasketAction action, IDispatcher dispatcher)
    {
        // 1. send the request
        var customerId = _authState.UserInfo?.UserId;
        
        if (customerId is not null)
        {
            var addProductToBasketRequest = new AddProductToBasketRequest
            {
                CustomerId = customerId.Value,
                ProductId = action.Product.ProductID,
                Quantity = action.Quantity
            };
        
            await _bodyRockyClient.AddProductToBasketAsync(addProductToBasketRequest);
        }
        
        // 2. show the toast   
        ToastParameters parameters = new();
        parameters.Add(nameof(AddedToBasketToast.Product), action.Product);
        parameters.Add(nameof(AddedToBasketToast.Quantity), action.Quantity);
        
        ToastInstanceSettings settings = new(5, true);
        
        _toastService.ShowToast<AddedToBasketToast>(parameters, settings);

    }
    
    [EffectMethod]
    public Task HandlePlaceOrderAction(PlaceOrderAction action, IDispatcher dispatcher)
    {
        ToastInstanceSettings settings = new(5, true);
        
        _toastService.ShowToast<PaiementSuccessToast>(settings);
        
        return Task.CompletedTask;
    }
}

#endregion

#region Strongly-typed dispatcher

public class BasketDispatcher
{
    private readonly IDispatcher _dispatcher;
    
    public BasketDispatcher(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }
    
    public void AddToBasket(ProductResponse product, int quantity = 1)
    {
        _dispatcher.Dispatch(new AddToBasketAction(product, quantity));
    }
    
    public void RemoveFromBasket(Guid productId, int quantity = 1)
    {
        _dispatcher.Dispatch(new RemoveFromBasketAction(productId, quantity));
    }
    
    public void ClearBasket()
    {
        _dispatcher.Dispatch(new ClearBasketAction());
    }

    public void PlaceOrder()
    {
        _dispatcher.Dispatch(new PlaceOrderAction());
    }
}

#endregion