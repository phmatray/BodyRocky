using BodyRocky.Core.Contracts.Requests.AccountRequests;
using BodyRocky.Core.Contracts.Responses.AccountResponses;
using BodyRocky.Core.Contracts.Responses.CustomerResponses;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace BodyRocky.Front.WebApp.Store;

#region State

public record AuthState(
    bool IsLoading,
    string? ErrorMessage,
    CustomerResponse? User)
{
    public bool IsAuthenticated
        => User is not null;
    
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
            null);
}

#endregion

#region Actions

public record LoginAction(string Email, string Password);
public record LoginSuccessAction(CustomerResponse User);
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
        => state with { IsLoading = true };
    
    [ReducerMethod]
    public static AuthState ReduceLoginSuccessAction(AuthState state, LoginSuccessAction action)
        => state with { IsLoading = false, ErrorMessage = null, User = action.User };
    
    [ReducerMethod]
    public static AuthState ReduceLoginFailureAction(AuthState state, LoginFailureAction action)
        => state with { IsLoading = false, ErrorMessage = action.Error, User = null };
    
    [ReducerMethod]
    public static AuthState ReduceRegisterAction(AuthState state, RegisterAction action)
        => state with { IsLoading = true, ErrorMessage = null };
    
    [ReducerMethod]
    public static AuthState ReduceRegisterSuccessAction(AuthState state, RegisterSuccessAction action)
        => state with { IsLoading = false, ErrorMessage = null };
    
    [ReducerMethod]
    public static AuthState ReduceRegisterFailureAction(AuthState state, RegisterFailureAction action)
        => state with { IsLoading = false, ErrorMessage = action.Error, User = null };
    
    [ReducerMethod]
    public static AuthState ReduceLogoutAction(AuthState state, LogoutAction action)
        => state with { IsLoading = false, ErrorMessage = null, User = null };
}

#endregion

#region Effects

public class AuthEffects
{
    private readonly IBodyRockyApi _bodyRockyClient;
    private readonly NavigationManager _navigationManager;

    public AuthEffects(
        IBodyRockyApi bodyRockyClient,
        NavigationManager navigationManager)
    {
        _bodyRockyClient = bodyRockyClient;
        _navigationManager = navigationManager;
    }

    [EffectMethod]
    public async Task HandleLoginAction(LoginAction action, IDispatcher dispatcher)
    {
        // try
        // {
        //     var response = await _bodyRockyClient.LoginAsync(new LoginRequest(action.Email, action.Password));
        //     dispatcher.Dispatch(new LoginSuccessAction(response));
        // }
        // catch (Exception e)
        // {
        //     dispatcher.Dispatch(new LoginFailureAction(e.Message));
        // }
        
        throw new NotImplementedException();
    }
    
    [EffectMethod]
    public async Task HandleRegisterAction(RegisterAction action, IDispatcher dispatcher)
    {
        try
        {
            SignupResponse response = await _bodyRockyClient.RegisterAsync(action.SignupRequest);
            dispatcher.Dispatch(new RegisterSuccessAction());
        }
        catch (Exception e)
        {
            dispatcher.Dispatch(new RegisterFailureAction(e.Message));
        }
    }
    
    [EffectMethod]
    public async Task HandleRegisterSuccessAction(RegisterSuccessAction action, IDispatcher dispatcher)
    {
        _navigationManager.NavigateTo("/login");
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

    public void Login(string email, string password)
        => _dispatcher.Dispatch(new LoginAction(email, password));
    
    public void Register(SignupRequest signupRequest)
        => _dispatcher.Dispatch(new RegisterAction(signupRequest));
    
    public void Logout()
        => _dispatcher.Dispatch(new LogoutAction());
}

#endregion