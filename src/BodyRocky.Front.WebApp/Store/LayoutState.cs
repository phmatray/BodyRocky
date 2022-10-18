using BodyRocky.Front.WebApp.Store.Models;
using Fluxor;

namespace BodyRocky.Front.WebApp.Store;

#region State

public record LayoutState(
    ViewMode ViewMode)
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
        => new(ViewMode.Grid);
}

#endregion

#region Actions

public record ChangeViewModeAction(ViewMode ViewMode);

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
}

#endregion
