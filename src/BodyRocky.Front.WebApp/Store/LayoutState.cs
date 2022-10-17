using BodyRocky.Core.Contracts.Responses.CategoryResponses;
using BodyRocky.Front.WebApp.Store.Models;
using Fluxor;

namespace BodyRocky.Front.WebApp.Store;

#region State

public record LayoutState(
    List<CategoryResponse> Categories,
    bool IsLoading,
    string? ErrorMessage,
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
        => new(new(), false, null, ViewMode.Grid);
}

#endregion

#region Actions

public record LoadCategoriesAction;
public record LoadCategoriesSuccessAction(List<CategoryResponse> Categories);
public record LoadCategoriesFailureAction(Exception Exception);
public record ChangeViewModeAction(ViewMode ViewMode);

#endregion

#region Reducers

public static class LayoutReducers
{
    [ReducerMethod]
    public static LayoutState ReduceLoadCategoriesAction(LayoutState state, LoadCategoriesAction action)
    {
        return state with
        {
            IsLoading = true,
            ErrorMessage = null
        };
    }
    
    [ReducerMethod]
    public static LayoutState ReduceLoadCategoriesSuccessAction(LayoutState state, LoadCategoriesSuccessAction action)
    {
        return state with
        {
            Categories = action.Categories,
            IsLoading = false,
        };
    }
    
    [ReducerMethod]
    public static LayoutState ReduceLoadCategoriesFailureAction(LayoutState state, LoadCategoriesFailureAction action)
    {
        return state with
        {
            ErrorMessage = action.Exception.Message,
            IsLoading = false
        };
    }
    
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

#region Effects

public class LayoutEffects
{
    private readonly IBodyRockyApi _bodyRockyClient;
    
    public LayoutEffects(IBodyRockyApi bodyRockyClient)
    {
        _bodyRockyClient = bodyRockyClient;
    }
    
    [EffectMethod]
    public async Task HandleLoadCategoriesAction(LoadCategoriesAction action, IDispatcher dispatcher)
    {
        try
        {
            GetAllCategoriesResponse response = await _bodyRockyClient.GetAllCategoriesAsync();
            List<CategoryResponse> categories = response.Categories.ToList();
            var successAction = new LoadCategoriesSuccessAction(categories);
        
            dispatcher.Dispatch(successAction);
        }
        catch (Exception e)
        {
            var failureAction = new LoadCategoriesFailureAction(e);
            dispatcher.Dispatch(failureAction);
        }
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
    
    public void LoadCategories()
    {
        _dispatcher.Dispatch(new LoadCategoriesAction());
    }
    
    public void ChangeViewMode(ViewMode viewMode)
    {
        _dispatcher.Dispatch(new ChangeViewModeAction(viewMode));
    }
}

#endregion
