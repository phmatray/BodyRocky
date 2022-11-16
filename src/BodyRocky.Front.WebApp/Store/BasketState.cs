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

public record BasketState(
    bool IsLoading,
    string? ErrorMessage,
    Guid BasketID,
    DateTime BasketDateAdded,
    BasketItem[] BasketItems)
{
    public string TotalPrice
        => BasketItems
            .Sum(x => x.ProductPrice * x.Quantity)
            .ToString("F2", CultureInfo.InvariantCulture)
            .Replace(".", ",");

    public int TotalQuantity
        => BasketItems
            .Sum(x => x.Quantity);
    
    public bool IsEmpty
        => TotalQuantity == 0;
    
    public bool IsNotEmpty
        => !IsEmpty;
    
    public bool HasError
        => ErrorMessage is not null;
}

public class BasketFeature : Feature<BasketState>
{
    public override string GetName()
        => "Basket";

    protected override BasketState GetInitialState()
        => new BasketState(
            false,
            null,
            Guid.Empty,
            DateTime.UtcNow,
            Array.Empty<BasketItem>());
}

#endregion

#region Actions

public record LoadBasketAction;
public record LoadBasketSuccessAction(Guid BasketID, DateTime BasketDateAdded, BasketItem[] BasketItems);
public record LoadBasketFailureAction(string ErrorMessage);

public record AddToBasketAction(BasketItem BasketProduct);
public record RemoveFromBasketAction(Guid ProductID, int Quantity);
public record ClearBasketAction;
public record PlaceOrderAction;

#endregion

#region Reducers

public static class BasketReducers
{
    [ReducerMethod]
    public static BasketState ReduceLoadBasketAction(
        BasketState state,
        LoadBasketAction action)
        => state with
        {
            IsLoading = true,
            ErrorMessage = null,
            BasketItems = Array.Empty<BasketItem>()
        };
    
    [ReducerMethod]
    public static BasketState ReduceLoadBasketSuccessAction(
        BasketState state,
        LoadBasketSuccessAction action)
        => state with
        {
            IsLoading = false,
            ErrorMessage = null,
            BasketID = action.BasketID,
            BasketDateAdded = action.BasketDateAdded,
            BasketItems = action.BasketItems
        };
    
    [ReducerMethod]
    public static BasketState ReduceLoadBasketFailureAction(
        BasketState state,
        LoadBasketFailureAction action)
        => state with
        {
            IsLoading = false,
            ErrorMessage = action.ErrorMessage,
            BasketItems = state.BasketItems
        };
    
    [ReducerMethod]
    public static BasketState ReduceAddToBasketAction(BasketState state, AddToBasketAction action)
    {
        // check if the product is already in the basket
        bool isAlreadyInBasket = state.BasketItems
            .Any(x => x.ProductID == action.BasketProduct.ProductID);

        // create new basket items list
        BasketItem[] basketItems;
        if (isAlreadyInBasket)
        {
            // if the product is already in the basket, we create a new basket item list
            // where we update the quantity of the product that is already in the basket
            // and leave the other products as they are.
            basketItems = state.BasketItems
                .Select(x => x.ProductID == action.BasketProduct.ProductID
                    ? new BasketItem
                    {
                        ProductID = x.ProductID,
                        ProductName = x.ProductName,
                        ProductPrice = x.ProductPrice,
                        Quantity = x.Quantity + action.BasketProduct.Quantity
                    }
                    : x)
                .ToArray();
        }
        else
        {
            // if the product is not already in the basket, we create a new basket item list
            // where we add the new product to the basket.
            basketItems = state.BasketItems
                .Append(action.BasketProduct)
                .ToArray();
        }

        // return the new state
        return state with
        {
            BasketID = state.BasketID,
            BasketDateAdded = state.BasketDateAdded,
            BasketItems = basketItems
        };
    }

    [ReducerMethod]
    public static BasketState ReduceRemoveFromBasketAction(BasketState state, RemoveFromBasketAction action)
    {
        // check if the product is already in the basket
        bool isAlreadyInBasket = state.BasketItems
            .Any(x => x.ProductID == action.ProductID);

        // if the product is not in the basket, just return the state (no changes)  
        if (!isAlreadyInBasket)
            return state;

        // create new basket items list
        BasketItem[] basketItems = state.BasketItems
            .Select(x => x.ProductID == action.ProductID
                ? new BasketItem
                {
                    ProductID = x.ProductID,
                    ProductName = x.ProductName,
                    ProductPrice = x.ProductPrice,
                    Quantity = x.Quantity - action.Quantity
                }
                : x)
            .Where(x => x.Quantity > 0)
            .ToArray();

        return state with
        {
            BasketID = state.BasketID,
            BasketDateAdded = state.BasketDateAdded,
            BasketItems = basketItems
        };
    }

    [ReducerMethod]
    public static BasketState ReduceClearBasketAction(BasketState state, ClearBasketAction action)
    {
        return state with
        {
            BasketID = state.BasketID,
            BasketDateAdded = state.BasketDateAdded,
            BasketItems = Array.Empty<BasketItem>()
        };
    }

    [ReducerMethod]
    public static BasketState ReducePlaceOrderAction(BasketState state, PlaceOrderAction action)
    {
        return state;
    }
}

#endregion

#region Effects

public class BasketEffects
{
    private readonly IBodyRockyApi _bodyRockyClient;
    private readonly IToastService _toastService;
    private readonly IState<AuthState> _authState;
    private readonly ILogger<BasketEffects> _logger;

    public BasketEffects(
        IBodyRockyApi bodyRockyClient,
        IToastService toastService,
        IState<AuthState> authState,
        ILogger<BasketEffects> logger)
    {
        _bodyRockyClient = bodyRockyClient;
        _toastService = toastService;
        _authState = authState;
        _logger = logger;
    }
    
    [EffectMethod]
    public async Task HandleAddToBasketAction(AddToBasketAction action, IDispatcher dispatcher)
    {
        // 1. send the request
        var customerID = _authState.Value.UserInfo?.UserId;
        
        if (customerID is not null)
        {
            var addProductToBasketRequest = new AddProductToBasketRequest
            {
                CustomerId = customerID.Value,
                ProductId = action.BasketProduct.ProductID,
                Quantity = action.BasketProduct.Quantity
            };
        
            await _bodyRockyClient.AddProductToBasketAsync(addProductToBasketRequest);
        }
        
        // 2. show the toast   
        ToastParameters parameters = new();
        parameters.Add(nameof(AddedToBasketToast.ProductID), action.BasketProduct.ProductID);
        parameters.Add(nameof(AddedToBasketToast.ProductName), action.BasketProduct.ProductName);
        parameters.Add(nameof(AddedToBasketToast.ProductPrice), action.BasketProduct.ProductPrice);
        parameters.Add(nameof(AddedToBasketToast.Quantity), action.BasketProduct.Quantity);
        
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
    
    [EffectMethod]
    public async Task HandleLoadBasketAction(LoadBasketAction action, IDispatcher dispatcher)
    {
        // 1. send the request
        var customerID = _authState.Value.UserInfo?.UserId;
        
        _logger.LogWarning("Loading basket for customer {CustomerID}", customerID);
        
        if (customerID is not null)
        {
            GetBasketRequest request = new() { CustomerID = customerID.Value };
            GetOneBasketResponse? response = await _bodyRockyClient.GetBasketAsync(request);
            
            // log basket properties
            _logger.LogWarning("Basket ID: {BasketID}", response?.BasketID);
            _logger.LogWarning("Basket Date Added: {BasketDateAdded}", response?.BasketDateAdded);
            _logger.LogWarning("Basket Items: {BasketItems}", response?.Products);
            _logger.LogWarning("Basket Count: {BasketTotal}", response?.Products.Count);
            
            // 2a. dispatch the success action
            var successAction = new LoadBasketSuccessAction(
                response.BasketID,
                response.BasketDateAdded,
                response.Products.ToArray());
            
            dispatcher.Dispatch(successAction);
        }
        else
        {
            // 2b. dispatch the failure action
            var failureAction = new LoadBasketFailureAction("You are not logged in.");
            dispatcher.Dispatch(failureAction);
        }
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
        BasketItem basketItem = new()
        {
            ProductID = product.ProductID,
            ProductName = product.ProductName,
            ProductPrice = product.ProductPrice,
            Quantity = quantity
        };
        
        _dispatcher.Dispatch(new AddToBasketAction(basketItem));
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
    
    public void LoadBasket()
    {
        _dispatcher.Dispatch(new LoadBasketAction());
    }
}

#endregion