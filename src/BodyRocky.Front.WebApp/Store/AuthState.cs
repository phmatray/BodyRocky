using System.Text.Json;
using Blazored.Toast.Services;
using BodyRocky.Core.Contracts.Requests;
using BodyRocky.Core.Contracts.Responses;
using BodyRocky.Front.WebApp.Store.Models;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Refit;

namespace BodyRocky.Front.WebApp.Store;

#region State

public record AuthState(
    bool IsLoading,
    CustomerDetailsResponse? Customer,
    string? Token,
    string? ErrorMessage)
{
    public bool IsAuthenticated
        => Token is not null && Customer is not null;
    
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

public record LoginAction(LoginRequest LoginRequest);
public record LoginSuccessAction(bool IsSuccessfulLogin, CustomerDetailsResponse Customer, string Token);
public record LoginFailureAction(string Error);

public record RegisterAction(SignupRequest SignupRequest);
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
            Customer = action.Customer,
            Token = action.Token
        };
    
    [ReducerMethod]
    public static AuthState ReduceLoginFailureAction(AuthState state, LoginFailureAction action)
        => state with
        {
            IsLoading = false,
            ErrorMessage = action.Error,
            Customer = null,
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
            Customer = null,
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

    public AuthEffects(
        IBodyRockyApi bodyRockyClient,
        NavigationManager navigationManager,
        IToastService toastService,
        ILogger<AuthEffects> logger)
    {
        _bodyRockyClient = bodyRockyClient;
        _navigationManager = navigationManager;
        _toastService = toastService;
        _logger = logger;
    }

    [EffectMethod]
    public async Task HandleLoginAction(LoginAction action, IDispatcher dispatcher)
    {
        try
        {
            LoginResponse response = await _bodyRockyClient.LoginAsync(action.LoginRequest);
            
            LoginSuccessAction successAction = new(
                response.IsSuccessfulLogin,
                response.Customer,
                response.Token);
            
            dispatcher.Dispatch(successAction);
            
            if (response.IsSuccessfulLogin)
            {
                _navigationManager.NavigateTo("/");
            }
        }
        catch (Exception e)
        {
            string exceptionMessage = e.InnerException?.Message ?? e.Message;
            dispatcher.Dispatch(new LoginFailureAction(exceptionMessage));
        }
    }
    
    [EffectMethod]
    public async Task HandleRegisterAction(RegisterAction action, IDispatcher dispatcher)
    {
        try
        {
            // get the response from the API using the Refit client
            var signupResponse = await _bodyRockyClient.RegisterAsync(action.SignupRequest);

            if (signupResponse.IsSuccessfulRegistration)
            {
                // if the registration was successful, dispatch a success action
                dispatcher.Dispatch(new RegisterSuccessAction());
            }
        }
        catch (ApiException exception)
        {
            // other exception handling
            _logger.LogError(exception, "ApiException occurred while registering a new user");
            dispatcher.Dispatch(new RegisterFailureAction("ApiException occurred while registering a new user"));
            
            // deserialize the error response
            var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(exception.Content);
            if (errorResponse is not null)
            {
                var serialize = JsonSerializer.Serialize(errorResponse);

                // if the error response is not null, dispatch a failure action
                dispatcher.Dispatch(new RegisterFailureAction(errorResponse.Message));
                dispatcher.Dispatch(new RegisterFailureAction(serialize));
            }
            
            // // get the json node that contains the errors
            // var errors = signupResponse.Errors.ToList();
            // foreach (var error in errors)
            // {
            //     // dispatch a failure action for each error
            //     dispatcher.Dispatch(new RegisterFailureAction(error));
            // }
        }
    }
    
    [EffectMethod]
    public Task HandleRegisterSuccessAction(RegisterSuccessAction action, IDispatcher dispatcher)
    {
        _navigationManager.NavigateTo("/login");
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

    public void Login(LoginRequest loginRequest)
        => _dispatcher.Dispatch(new LoginAction(loginRequest));
    
    public void Register(SignupRequest signupRequest)
        => _dispatcher.Dispatch(new RegisterAction(signupRequest));
    
    public void Logout()
        => _dispatcher.Dispatch(new LogoutAction());
}

#endregion