https://chrissainty.com/adding-tailwind-css-v3-to-a-blazor-app/


1. Creer le fichier BasketFactory.cs

BodyRocky.Back.Server > DataAccess > Factories > BasketFactory.cs

```csharp
using BodyRocky.Back.Server.DataAccess.Entities;
using BodyRocky.Back.Server.DataAccess.Enumerations;

namespace BodyRocky.Back.Server.DataAccess.Factories;

public class BasketFactory
{
    public Basket CreateEmptyBasket(Guid customerId)
    {
        return new Basket
        {
            BasketID = Guid.Empty,
            BasketDateAdded = DateTime.UtcNow,
            BasketStatusCode = (int)BasketStatusEnum.Empty,
            CustomerID = customerId,
            BasketProducts = new List<BasketProduct>()
        };
    }
    
    public Basket CreateBasketWithProducts(Guid customerId, IList<Product> products)
    {
        var basket = CreateEmptyBasket(customerId);
        basket.CustomerID = customerId;
        basket.BasketProducts = products.Select(p => new BasketProduct
        {
            BasketID = basket.BasketID,
            ProductID = p.ProductID,
            Quantity = 1
        }).ToList();
        return basket;
    }
}
```

2. Ajouter une methode dans la classe PersistenceExtensions.cs

BodyRocky.Back.Server > DataAccess > PersistenceExtensions.cs

```csharp
public static class PersistenceExtensions
{
    public static void AddFactories(this IServiceCollection services)
    {
        services.AddSingleton<BasketFactory>();
    }

    ...
}
```

3. Enregistrer les factories dans le Program.cs

BodyRocky.Back.Server > Program.cs

```csharp
services.AddFactories(); // Ajouter cette ligne
services.AddCrudRepositories();
services.AddBusinessServices();
```

4. Modifier le service BasketService.cs pour injecter le BasketFactory

BodyRocky.Back.Server > Services > BasketService.cs

```csharp
public class BasketService
{
    private readonly BasketRepository _basketRepository;
    private readonly BasketFactory _basketFactory;
    
    public BasketService(
        BasketRepository basketRepository,
        BasketFactory basketFactory)
    {
        _basketRepository = basketRepository;
        _basketFactory = basketFactory;
    }
    
    public async Task<Basket> CreateEmptyBasketAsync(Guid customerId)
    {
        var basket = _basketFactory.CreateEmptyBasket(customerId);
        
        await _basketRepository.InsertAsync(basket);
        
        return basket;
    }

    // ... autres methodes
}
```
