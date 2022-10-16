using Microsoft.AspNetCore.Components;

namespace BodyRocky.Front.WebApp.Shared;

public enum PageType
{
    Account,
    Checkout,
    Home,
    Login,
    Product,
    Profile,
    Register,
    Shop,
    Wishlist
}

public class Routes
{
    public const string ACCOUNT_ROUTE = "/account";
    public const string CHECKOUT_ROUTE = "/checkout";
    public const string HOME_ROUTE = "/";
    public const string LOGIN_ROUTE = "/login";
    public const string PRODUCT_ROUTE = "/product";
    public const string PROFILE_ROUTE = "/profile";
    public const string REGISTER_ROUTE = "/register";
    public const string SHOP_ROUTE = "/shop";
    public const string WISHLIST_ROUTE = "/wishlist";
    
    private Dictionary<PageType, string> _routes = new()
    {
        {PageType.Account, ACCOUNT_ROUTE},
        {PageType.Checkout, CHECKOUT_ROUTE},
        {PageType.Home, HOME_ROUTE},
        {PageType.Login, LOGIN_ROUTE},
        {PageType.Product, PRODUCT_ROUTE},
        {PageType.Profile, PROFILE_ROUTE},
        {PageType.Register, REGISTER_ROUTE},
        {PageType.Shop, SHOP_ROUTE},
        {PageType.Wishlist, WISHLIST_ROUTE}
    };

    private readonly NavigationManager _navigationManager;

    public Routes(NavigationManager navigationManager)
    {
        _navigationManager = navigationManager;
    }

    public void NavigateTo(
        PageType pageType,
        string? query = null,
        bool forceLoad = false)
    {

        string route = _routes[pageType];
        if (query != null)
        {
            route += $"?{query}";
        }

        _navigationManager.NavigateTo(route, forceLoad);
    }
    
    public string GetRoute(PageType pageType)
    {
        return _routes[pageType];
    }
}
