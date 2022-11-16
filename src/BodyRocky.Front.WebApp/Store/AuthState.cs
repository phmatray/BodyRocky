using System.Security.Claims;
using Blazored.Toast.Services;
using BodyRocky.Front.WebApp.Shared;
using BodyRocky.Front.WebApp.Shared.Services;
using BodyRocky.Front.WebApp.Store.Models;
using BodyRocky.Shared;
using BodyRocky.Shared.Contracts.Requests;
using BodyRocky.Shared.Contracts.Responses;
using BodyRocky.Shared.Forms;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace BodyRocky.Front.WebApp.Store;

#region State

public record AuthState(
    bool IsLoading,
    string? ErrorMessage,
    UserInfo? UserInfo,
    CustomerDetailsResponse? CustomerDetails)
{
    public bool IsAuthenticated
        => UserInfo?.IsAuthenticated ?? false;
    
    public bool HasError
        => ErrorMessage is not null;
}

public class AuthFeature : Feature<AuthState>
{
    public override string GetName()
        => "Auth";

    protected override AuthState GetInitialState() =>
        new AuthState(false, null, null, null);
}

#endregion

#region Actions

public record LoginAction(LoginParameters? LoginParameters);
public record LoginSuccessAction(UserInfo UserInfo, CustomerDetailsResponse CustomerDetailsResponse);
public record LoginFailureAction(string Error);

public record RegisterAction(RegisterParameters RegisterParameters);
public record RegisterSuccessAction;
public record RegisterFailureAction(string Error);

public record LogoutAction;
public record LogoutSuccessAction;
public record LogoutFailureAction(string Error);

#endregion

#region Reducers

public static class AuthReducer
{
    [ReducerMethod]
    public static AuthState ReduceLoginAction(AuthState state, LoginAction action)
        => state with
        {
            IsLoading = true,
            ErrorMessage = null
        };
    
    [ReducerMethod]
    public static AuthState ReduceLoginSuccessAction(AuthState state, LoginSuccessAction action)
        => state with
        {
            IsLoading = false,
            ErrorMessage = null,
            UserInfo = action.UserInfo,
            CustomerDetails = action.CustomerDetailsResponse
        };
    
    [ReducerMethod]
    public static AuthState ReduceLoginFailureAction(AuthState state, LoginFailureAction action)
        => state with
        {
            IsLoading = false,
            ErrorMessage = action.Error,
            UserInfo = null,
            CustomerDetails = null
        };
    
    [ReducerMethod]
    public static AuthState ReduceRegisterAction(AuthState state, RegisterAction action)
        => state with
        {
            IsLoading = true,
            ErrorMessage = null
        };
    
    [ReducerMethod]
    public static AuthState ReduceRegisterSuccessAction(AuthState state, RegisterSuccessAction action)
        => state with
        {
            IsLoading = false,
            ErrorMessage = null
        };
    
    [ReducerMethod]
    public static AuthState ReduceRegisterFailureAction(AuthState state, RegisterFailureAction action)
        => state with
        {
            IsLoading = false,
            ErrorMessage = action.Error
        };
    
    [ReducerMethod]
    public static AuthState ReduceLogoutAction(AuthState state, LogoutAction action)
        => state with
        {
            IsLoading = false,
            ErrorMessage = null,
            UserInfo = null,
            CustomerDetails = null
        };
    
    [ReducerMethod]
    public static AuthState ReduceLogoutSuccessAction(AuthState state, LogoutSuccessAction action)
        => state with
        {
            IsLoading = false,
            ErrorMessage = null,
            UserInfo = null,
            CustomerDetails = null
        };
    
    [ReducerMethod]
    public static AuthState ReduceLogoutFailureAction(AuthState state, LogoutFailureAction action)
        => state with
        {
            IsLoading = false,
            ErrorMessage = action.Error
        };
}

#endregion

#region Effects

public class AuthEffects
{
    private readonly NavigationManager _navigationManager;
    private readonly IToastService _toastService;
    private readonly ILogger<AuthEffects> _logger;
    private readonly IBodyRockyApi _bodyRockyApi;
    private readonly IdentityAuthenticationStateProvider _authStateProvider;
    private readonly BasketDispatcher _basketDispatcher;

    public AuthEffects(
        NavigationManager navigationManager,
        IToastService toastService,
        ILogger<AuthEffects> logger,
        IBodyRockyApi bodyRockyApi,
        IdentityAuthenticationStateProvider authStateProvider,
        BasketDispatcher basketDispatcher)
    {
        _navigationManager = navigationManager;
        _toastService = toastService;
        _logger = logger;
        _bodyRockyApi = bodyRockyApi;
        _authStateProvider = authStateProvider;
        _basketDispatcher = basketDispatcher;
    }

    [EffectMethod]
    public async Task HandleLoginAction(LoginAction action, IDispatcher dispatcher)
    {
        try
        {
            if (action.LoginParameters is not null)
            {
                // if the user is already logged in, we don't need to call the login endpoint
                await _authStateProvider.Login(action.LoginParameters);
            }
            
            // but we need to get the user info anyway
            var auth = await _authStateProvider.GetAuthenticationStateAsync();
            
            // if the user is already authenticated (via cookie), auth.User.Identity will be not null
            if (auth.User.Identity?.IsAuthenticated ?? false)
            {
                // select guid id from claim
                var userId = Guid.Parse(auth.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
                
                // get user info from auth.User.Identity           
                var userInfo = new UserInfo(
                    auth.User.Identity?.Name ?? string.Empty,
                    auth.User.Identity?.AuthenticationType ?? string.Empty,
                    auth.User.Identity?.IsAuthenticated ?? false,
                    userId);
                
                // call the web api to get the complete customer info
                var getCustomerRequest = new GetCustomerRequest { CustomerID = userId.ToString() };
                var customerDetailsResponse = await _bodyRockyApi.GetCustomerAsync(getCustomerRequest);

                dispatcher.Dispatch(new LoginSuccessAction(userInfo, customerDetailsResponse));
                
                // display a toast
                _toastService.ShowSuccess("Vous êtes maintenant connecté.", $"Bienvenue {userInfo.Name}");
                
                // and redirect to the home page
                _navigationManager.NavigateTo(Routes.HOME_ROUTE);
            }
            else
            {
                dispatcher.Dispatch(new LoginSuccessAction(null, null));
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while logging in");
            string exceptionMessage = e.InnerException?.Message ?? e.Message;
            dispatcher.Dispatch(new LoginFailureAction(exceptionMessage));
            _toastService.ShowError(exceptionMessage);
        }
    }
    
    [EffectMethod]
    public async Task HandleLoginSuccessAction(LoginSuccessAction action, IDispatcher dispatcher)
    {
        // we need to dispatch a new action (from the BasketState) to load the user's basket
        _basketDispatcher.LoadBasket();
    }

    [EffectMethod]
    public async Task HandleRegisterAction(RegisterAction action, IDispatcher dispatcher)
    {
        try
        {
            await _authStateProvider.Register(action.RegisterParameters);
            dispatcher.Dispatch(new RegisterSuccessAction());
            _navigationManager.NavigateTo(Routes.LOGIN_ROUTE);
            _toastService.ShowSuccess("La création de votre compte a été effectuée avec succès. Vous pouvez maintenant vous connecter.", "Création de compte");
        }
        catch (Exception e)
        {
            string exceptionMessage = e.InnerException?.Message ?? e.Message;
            dispatcher.Dispatch(new RegisterFailureAction(exceptionMessage));
            _toastService.ShowError(exceptionMessage);
        }
    }
    
    [EffectMethod]
    public async Task HandleLogoutAction(LogoutAction action, IDispatcher dispatcher)
    {
        try
        {
            await _authStateProvider.Logout();
            dispatcher.Dispatch(new LogoutSuccessAction());
            _navigationManager.NavigateTo(Routes.LOGIN_ROUTE);
            _toastService.ShowSuccess("Vous êtes maintenant déconnecté.", "Déconnexion");
        }
        catch (Exception e)
        {
            string exceptionMessage = e.InnerException?.Message ?? e.Message;
            dispatcher.Dispatch(new LogoutFailureAction(exceptionMessage));
            _toastService.ShowError(exceptionMessage);
        }
    }
}

#endregion

#region Strongly-typed dispatcher

public class AuthDispatcher
{
    private readonly IDispatcher _dispatcher;

    public AuthDispatcher(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    public void Login(LoginParameters? loginParameters = null)
        => _dispatcher.Dispatch(new LoginAction(loginParameters));
    
    public void Register(RegisterParameters registerParameters)
        => _dispatcher.Dispatch(new RegisterAction(registerParameters));
    
    public void Logout()
        => _dispatcher.Dispatch(new LogoutAction());
}

#endregion