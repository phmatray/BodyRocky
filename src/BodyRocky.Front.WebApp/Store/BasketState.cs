using System.Globalization;
using BodyRocky.Core.Contracts.Responses.ProductResponses;
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
public record ClearBasketAction();

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
    public static BasketState ReduceRemoveFromBasketAction(BasketState state, ClearBasketAction action)
    {
        return state with { ProductQuantities = new() };
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
    
    // public void RemoveFromBasket(Guid productId, int quantity = 1)
    // {
    //     _dispatcher.Dispatch(new RemoveFromBasketAction(productId, quantity));
    // }
    
    public void ClearBasket()
    {
        _dispatcher.Dispatch(new ClearBasketAction());
    }
}

#endregion