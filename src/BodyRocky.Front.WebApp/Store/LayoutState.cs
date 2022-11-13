using System.Web;
using BodyRocky.Front.WebApp.Shared;
using BodyRocky.Front.WebApp.Store.Models;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace BodyRocky.Front.WebApp.Store;

#region State

public record LayoutState(
    ViewMode ViewMode,
    string SearchTerm)
{
    public bool IsGridViewMode
        => ViewMode == ViewMode.Grid;
    
    public bool IsListViewMode
        => ViewMode == ViewMode.List;
}

public class LayoutFeature : Feature<LayoutState>
{
    public override string GetName()
        => "Layout";
    
    protected override LayoutState GetInitialState()
        => new(ViewMode.Grid, String.Empty);
}

#endregion

#region Actions

public record ChangeViewModeAction(ViewMode ViewMode);

public record SetSearchTermAction(string SearchTerm);

#endregion

#region Reducers

public static class LayoutReducers
{
    [ReducerMethod]
    public static LayoutState ReduceChangeViewModeAction(LayoutState state, ChangeViewModeAction action)
    {
        return state with
        {
            ViewMode = action.ViewMode
        };
    }
    
    [ReducerMethod]
    public static LayoutState ReduceSetSearchTermAction(LayoutState state, SetSearchTermAction action)
    {
        return state with
        {
            SearchTerm = action.SearchTerm
        };
    }
}

#endregion

#region Effects

public class LayoutEffects
{
    private readonly NavigationManager _navigationManager;
    
    public LayoutEffects(NavigationManager navigationManager)
    {
        _navigationManager = navigationManager;
    }
    
    [EffectMethod]
    public Task HandleSetSearchTermAction(SetSearchTermAction action, IDispatcher dispatcher)
    {
        string pageUrl = _navigationManager.Uri;
        
        if (pageUrl.ToLower().Contains(Routes.SHOP_ROUTE))
        {
            _navigationManager.NavigateTo(Routes.SHOP_ROUTE);
        }
        
        return Task.CompletedTask;
    }
}

#endregion

#region Strongly-typed dispatcher

public class LayoutDispatcher
{
    private readonly IDispatcher _dispatcher;
    
    public LayoutDispatcher(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }
    
    public void ChangeViewMode(ViewMode viewMode)
    {
        _dispatcher.Dispatch(new ChangeViewModeAction(viewMode));
    }
    
    public void SetSearchTerm(string searchTerm)
    {
        _dispatcher.Dispatch(new SetSearchTermAction(searchTerm));
    }
}

#endregion
