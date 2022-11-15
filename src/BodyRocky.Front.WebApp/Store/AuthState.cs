using System.Security.Claims;
using Blazored.Toast.Services;
using BodyRocky.Front.WebApp.Shared;
using BodyRocky.Front.WebApp.Shared.Services;
using BodyRocky.Shared;
using BodyRocky.Shared.Forms;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace BodyRocky.Front.WebApp.Store;

#region State

public record AuthState(
    bool IsLoading,
    ClaimsPrincipal? UserPrincipal,
    string? Token,
    string? ErrorMessage)
{
    public bool IsAuthenticated
        => Token is not null && UserPrincipal is not null;
    
    public bool HasError
        => ErrorMessage is not null;
}

public class AuthFeature : Feature<AuthState>
{
    public override string GetName()
        => "Auth";

    protected override AuthState GetInitialState() =>
        new AuthState(
            false,
            null,
            null,
            null);
}

#endregion

#region Actions

public record LoginAction(LoginParameters LoginParameters);
public record LoginSuccessAction(bool IsSuccessfulLogin, ClaimsPrincipal UserPrincipal, string Token);
public record LoginFailureAction(string Error);

public record RegisterAction(RegisterParameters RegisterParameters);
public record RegisterSuccessAction();
public record RegisterFailureAction(string Error);

public record LogoutAction();

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
            UserPrincipal = action.UserPrincipal,
            Token = action.Token
        };
    
    [ReducerMethod]
    public static AuthState ReduceLoginFailureAction(AuthState state, LoginFailureAction action)
        => state with
        {
            IsLoading = false,
            ErrorMessage = action.Error,
            UserPrincipal = null,
            Token = null
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
            UserPrincipal = null,
            Token = null
        };
}

#endregion

#region Effects

public class AuthEffects
{
    private readonly IBodyRockyApi _bodyRockyClient;
    private readonly NavigationManager _navigationManager;
    private readonly IToastService _toastService;
    private readonly ILogger<AuthEffects> _logger;
    private readonly IdentityAuthenticationStateProvider _authStateProvider;

    public AuthEffects(
        IBodyRockyApi bodyRockyClient,
        NavigationManager navigationManager,
        IToastService toastService,
        ILogger<AuthEffects> logger,
        IdentityAuthenticationStateProvider authStateProvider)
    {
        _bodyRockyClient = bodyRockyClient;
        _navigationManager = navigationManager;
        _toastService = toastService;
        _logger = logger;
        _authStateProvider = authStateProvider;
    }

    [EffectMethod]
    public async Task HandleLoginAction(LoginAction action, IDispatcher dispatcher)
    {
        try
        {
            await _authStateProvider.Login(action.LoginParameters);
            var auth = await _authStateProvider.GetAuthenticationStateAsync();
            dispatcher.Dispatch(new LoginSuccessAction(true, auth.User, "FAKE_TOKEN"));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            string exceptionMessage = e.InnerException?.Message ?? e.Message;
            dispatcher.Dispatch(new LoginFailureAction(exceptionMessage));
        }
        
        // try
        // {
        //     LoginResponse response = await _bodyRockyClient.LoginAsync(action.LoginRequest);
        //     
        //     LoginSuccessAction successAction = new(
        //         response.IsSuccessfulLogin,
        //         response.Customer,
        //         response.Token);
        //     
        //     dispatcher.Dispatch(successAction);
        //     
        //     if (response.IsSuccessfulLogin)
        //     {
        //         _navigationManager.NavigateTo("/");
        //     }
        // }
        // catch (Exception e)
        // {
        //     string exceptionMessage = e.InnerException?.Message ?? e.Message;
        //     dispatcher.Dispatch(new LoginFailureAction(exceptionMessage));
        // }
    }
    
    [EffectMethod]
    public async Task HandleRegisterAction(RegisterAction action, IDispatcher dispatcher)
    {
        try
        {
            await _authStateProvider.Register(action.RegisterParameters);
            dispatcher.Dispatch(new RegisterSuccessAction());
        }
        catch (Exception e)
        {
            string exceptionMessage = e.InnerException?.Message ?? e.Message;
            dispatcher.Dispatch(new RegisterFailureAction(exceptionMessage));
        }
        
        // try
        // {
        //     // get the response from the API using the Refit client
        //     var signupResponse = await _bodyRockyClient.RegisterAsync(action.SignupRequest);
        //
        //     if (signupResponse.IsSuccessfulRegistration)
        //     {
        //         // if the registration was successful, dispatch a success action
        //         dispatcher.Dispatch(new RegisterSuccessAction());
        //     }
        // }
        // catch (ApiException exception)
        // {
        //     // other exception handling
        //     _logger.LogError(exception, "ApiException occurred while registering a new user");
        //     dispatcher.Dispatch(new RegisterFailureAction("ApiException occurred while registering a new user"));
        //
        //     var contentAsAsync = await exception.GetContentAsAsync<ErrorResponse>();
        //
        //     // deserialize the error response
        //     var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(exception.Content);
        //     if (errorResponse is not null)
        //     {
        //         var serialize = JsonSerializer.Serialize(errorResponse);
        //
        //         // if the error response is not null, dispatch a failure action
        //         dispatcher.Dispatch(new RegisterFailureAction(errorResponse.Message));
        //         dispatcher.Dispatch(new RegisterFailureAction(serialize));
        //     }
        // }
    }
    
    [EffectMethod]
    public Task HandleRegisterSuccessAction(RegisterSuccessAction action, IDispatcher dispatcher)
    {
        _navigationManager.NavigateTo(Routes.LOGIN_ROUTE);
        _toastService.ShowSuccess("Registration successful, you can now login", "Registration");
        return Task.CompletedTask;
    }

    [EffectMethod]
    public Task HandleLoginFailureAction(LoginFailureAction action, IDispatcher dispatcher)
    {
        string message = action.Error;
        _toastService.ShowError(message);
        return Task.CompletedTask;
    }
    
    [EffectMethod]
    public Task HandleRegisterFailureAction(RegisterFailureAction action, IDispatcher dispatcher)
    {
        string message = action.Error;
        _toastService.ShowError(message);
        return Task.CompletedTask;
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

    public void Login(LoginParameters loginParameters)
        => _dispatcher.Dispatch(new LoginAction(loginParameters));
    
    public void Register(RegisterParameters registerParameters)
        => _dispatcher.Dispatch(new RegisterAction(registerParameters));
    
    public void Logout()
        => _dispatcher.Dispatch(new LogoutAction());
}

#endregion