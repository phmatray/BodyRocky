using System;
using BodyRocky.Front.AdminApp.Models;
using BodyRocky.Front.AdminApp.Presenters;
using Gtk;
using Application = Gtk.Application;
using UI = Gtk.Builder.ObjectAttribute;
#pragma warning disable CS4014

namespace BodyRocky.Front.AdminApp.Views;

class MainWindow : Window
{
    [UI] private readonly Label _titleProductCatalog = null;
    [UI] private readonly Button _buttonReload = null;
    [UI] private readonly Button _buttonDeleteProduct = null;
    [UI] private readonly TreeView _productTree = null;
    [UI] private readonly TextView _inputProductName = null;
    [UI] private readonly TextView _inputProductDescription = null;
    [UI] private readonly TextView _inputProductPrice = null;
    [UI] private readonly TextView _inputProductStock = null;
    [UI] private readonly TextView _inputProductCategory = null;

    private readonly MainPresenter _mainPresenter;
    private Product _selectedProduct;

    public MainWindow()
        : this(new Builder("MainWindow.glade"))
    {
    }

    private MainWindow(Builder builder)
        : base(builder.GetRawOwnedObject("MainWindow"))
    {
        builder.Autoconnect(this);

        DeleteEvent += Window_DeleteEvent;
        
        // Set up the buttons
        _buttonReload.Clicked += ButtonReloadClicked;
        _buttonDeleteProduct.Clicked += ButtonDeleteProductClicked;
        
        // Set up the tree view
        _productTree.EnableSearch = true;
        _productTree.EnableGridLines = TreeViewGridLines.Both;

        _productTree.AppendColumn("Name", new CellRendererText(), "text", 0);
        _productTree.AppendColumn("Price", new CellRendererText(), "text", 1);
        _productTree.AppendColumn("Stock", new CellRendererText(), "text", 2);
        _productTree.AppendColumn("Description", new CellRendererText(), "text", 3);
        _productTree.AppendColumn("Category", new CellRendererText(), "text", 4);
        
        // add the id column to the tree view as invisible
        var idColumn = new TreeViewColumn();
        var idCell = new CellRendererText();
        idColumn.PackStart(idCell, false);
        idColumn.AddAttribute(idCell, "text", 5);
        idColumn.Visible = false;
        _productTree.AppendColumn(idColumn);
        
        _productTree.RowActivated += ProductTree_RowActivated;
        
        // Set up the presenter
        _mainPresenter = DiContainer.GetMainPresenter();
        _mainPresenter.OnPropertyChanged += OnPropertyChanged;
    }

    private void ButtonDeleteProductClicked(object sender, EventArgs e)
    {
        // get the selected product id
        var selectedProductId = _selectedProduct.ID;

        // delete the product
        _mainPresenter.DeleteProduct(selectedProductId);
    }

    private void ProductTree_RowActivated(object o, RowActivatedArgs args)
    {
        // get the selected product
        _selectedProduct = _mainPresenter.Products[args.Path.Indices[0]];
        
        // fill the input fields
        _inputProductName.Buffer.Text = _selectedProduct.Name;
        _inputProductDescription.Buffer.Text = _selectedProduct.Description;
        _inputProductPrice.Buffer.Text = _selectedProduct.Price;
        _inputProductStock.Buffer.Text = _selectedProduct.Stock.ToString();
        _inputProductCategory.Buffer.Text = _selectedProduct.Category;
    }

    private void DeleteButton_Clicked(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void EditButton_Clicked(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void OnPropertyChanged(MainPresenter sender, EventArgs e)
    {
        // refresh the title
        _titleProductCatalog.Text = $"CATALOG PRODUCT ({_mainPresenter.Products.Count})";
        
        // redraw the tree view
        var listStore = new ListStore(
            typeof(string),
            typeof(string),
            typeof(string),
            typeof(string),
            typeof(string));
        
        foreach (var product in _mainPresenter.Products)
        {
            listStore.AppendValues(
                product.Name,
                product.Price,
                product.Stock.ToString(),
                product.ShortDescription,
                product.Category);
        }
        
        _productTree.Model = listStore;
    }

    private void ButtonReloadClicked(object sender, EventArgs a)
    {
        _mainPresenter.LoadDataAsync();
    }

    private void Window_DeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
    }
}