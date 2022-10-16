using BodyRocky.Core.Contracts.Responses.CategoryResponses;
using Fluxor;

namespace BodyRocky.Front.WebApp.Store;

#region State

[FeatureState(Name = "Layout")]
public record LayoutState(
    List<CategoryResponse> Categories,
    bool IsLoading,
    string? ErrorMessage)
{
    private LayoutState()
        : this(new(), false, null)
    {
        
    }
}

#endregion

#region Actions

public class LoadCategoriesAction { }

public class LoadCategoriesSuccessAction
{
    public List<CategoryResponse> Categories { get; }
    
    public LoadCategoriesSuccessAction(List<CategoryResponse> categories)
    {
        Categories = categories;
    }
}

public class LoadCategoriesFailureAction
{
    public Exception Exception { get; }
    
    public LoadCategoriesFailureAction(Exception exception)
    {
        Exception = exception;
    }
}

#endregion

#region Reducers

public static class Reducers
{
    [ReducerMethod]
    public static LayoutState ReduceLoadCategoriesAction(LayoutState state, LoadCategoriesAction action)
    {
        return state with
        {
            IsLoading = true
        };
    }
    
    [ReducerMethod]
    public static LayoutState ReduceLoadCategoriesSuccessAction(LayoutState state, LoadCategoriesSuccessAction action)
    {
        return state with
        {
            Categories = action.Categories,
            IsLoading = false,
            ErrorMessage = null
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
}

#endregion

#region Effects

public class Effects
{
    private readonly IBodyRockyApi _bodyRockyClient;
    
    public Effects(IBodyRockyApi bodyRockyClient)
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
}

#endregion
