using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BodyRocky.Front.AdminApp.Models;
using BodyRocky.Shared;
using BodyRocky.Shared.Contracts.Requests;

namespace BodyRocky.Front.AdminApp.Presenters;

public class MainPresenter
{
    private readonly IBodyRockyApi _bodyRockyApi;
    
    public MainPresenter()
    {
        _bodyRockyApi = DiContainer.GetBodyRockyApi();

        InitializeAsync();
    }

    public int TotalProducts { get; private set; }

    public int TotalCategories { get; private set; }
    
    public List<Product> Products { get; private set; }
    
    public Action<MainPresenter, EventArgs> OnPropertyChanged { get; set; }
    
    public async Task InitializeAsync()
    {
        await LoadDataAsync();
    }
    
    public async Task LoadDataAsync()
    {
        var catalog = await _bodyRockyApi.GetCatalogFullAsync();
        
        TotalProducts = catalog.TotalProducts;
        TotalCategories = catalog.TotalCategories;
        Products = catalog.Products.Select(Product.From).ToList();
        
        OnPropertyChanged?.Invoke(this, EventArgs.Empty);
    }

    public async Task DeleteProduct(Guid productId)
    {
        DeleteProductRequest request = new DeleteProductRequest
        {
            ProductID = productId
        };
        
        await _bodyRockyApi.DeleteProductAsync(request);
        await LoadDataAsync();
    }
}