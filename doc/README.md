# BodyRocky - eShop d'articles de sport

## Introduction

BodyRocky est un site e-commerce d'articles de sport. Il est développé en .NET 6 avec le framework ASP.NET Core 6.0. Il utilise Entity Framework Core 6.0 pour la gestion de la base de données, fast-endpoints pour la génération des API, et Blazor WebAssembly pour le front-end.

## Architecture de la solution

La solution est composée de 5 projets :

- **BodyRocky.Front.WebApp** : contient l'application web (interface utilisateur)
- **BodyRocky.Front.Desktop** : contient l'application desktop (interface d'administration)
- **BodyRocky.Back.WebApi** : contient les API REST
- **BodyRocky.Client** : contient le client de l'API
- **BodyRocky.Core** : contient les contrats et les modèles exposés par l'API

## Diagramme de gantt du développement des projets (mermaid)

```mermaid
gantt
    title A Gantt Diagram
    dateFormat  DD-MM-YYYY
    
    section Analyse
    Modele entite relationnel    :done,   a1, 15-09-2022, 5d
    Modele conceptuel de donnees :done,   a2, 15-09-2022, 5d
    Cas d'utilisation            :done,   a3, 22-09-2022, 2d
    Diagramme de sequence        :done,   a4, 05-10-2022, 6d
    Diagramme de classe          :active, a5, after a4,   11d
    Diagramme de packages        :active, a6, after a4,   11d
    
    section Suivi
    Suivi du projet 1  :crit, done,   24-09-2022, 1d
    Suivi du projet 2  :crit, done,   08-10-2022, 1d
    Suivi du projet 3  :crit, active, 22-10-2022, 1d
    Suivi du projet 4  :crit,         16-11-2022, 1d
    
    section WebApi
    Creation des modeles EF            :done, b1, 24-09-2022, 3d
    Configuration des entites          :done, b2, after b1, 2d
    Configuration des relations        :done, b3, after b1, 5d
    Creation des donnees fake          :done, b4, after b2, 3d
    Creation des donnees referentielles:done, b5, after b2, 3d
    DbContext                          :done, b6, after b5, 1d
    Repositories                       :done, b7, after b5, 2d
    Endpoint Categories GetAll         :done, b8, after b7, 5d
    Endpoint Catalog GetFull           :done, b9, after b8, 7d
    Endpoint Catalog GetOverview       :done, b10, after b8, 7d
    Endpoint Account Login             :done, b11, after b10, 7d
    Endpoint Account Signup            :done, b12, after b10, 7d
    Tests unitaires                    :      b13, after b12, 21d
    Developpement agile                :active, b14, after b12, 21d
    Debuggage                          :crit,   b15, after b14, 3d
    
    section Core
    Creation des contrats    :done, c1, after b7, 5d
    
    section Client
    Creation du client       :done, d1, after c1, 2d
    
    section WebApp
    Initialisation du projet :done, e1, after d1, 2d
    Integration de l'UI Kit  :done, e2, after e1, 4d
    Creation des composants  :active, e3, after e2, 4d
    Creation des pages       :active, e4, after e2, 6d
    Tests unitaires          :e5, after e4, 21d
    Developpement agile      :active, e6, after e4, 21d
    Debuggage                :crit, e6, after b14, 3d

    section Desktop
    Initialisation du projet :f1, after e4, 2d
    Creation des composants  :f2, after f1, 5d
    Creation des pages       :f3, after f2, 7d
    Developpement agile      :f4, after f3, 7d
    Tests unitaires          :f5, after f3, 7d
    Debuggage                :crit, f6, after f4, 3d
```

## Diagramme de packages (mermaid)

Les diagrammes de packages sont générés avec [Mermaid](https://mermaid-js.github.io/mermaid/#/).

```mermaid
graph LR
    subgraph Core
        BodyRocky.Core
    end
    subgraph Back
        BodyRocky.Back.WebApi --> BodyRocky.Core
    end
    subgraph Front
        subgraph Client
            BodyRocky.Client --> BodyRocky.Core
            BodyRocky.Client -. via http .- BodyRocky.Back.WebApi
        end
        subgraph WebApp
            BodyRocky.Front.WebApp --> BodyRocky.Client
            BodyRocky.Front.WebApp --> BodyRocky.Core
        end
        subgraph Desktop
            BodyRocky.Front.Desktop --> BodyRocky.Client
            BodyRocky.Front.Desktop --> BodyRocky.Core
        end
    end
```

* Ici, on peut voir que le projet **BodyRocky.Core** est référencé par les projets **BodyRocky.Back.WebApi**, **BodyRocky.Client**, **BodyRocky.Front.WebApp** et **BodyRocky.Front.Desktop**.
* Le projet **BodyRocky.Back.WebApi** n'est pas référencé par le projet **BodyRocky.Client**. C'est le projet **BodyRocky.Client** qui fait appel au projet **BodyRocky.Back.WebApi** via une requête HTTP.
* Le projet **BodyRocky.Client** est référencé par les projets **BodyRocky.Front.WebApp** et **BodyRocky.Front.Desktop**.


## Diagramme de classe BodyRocky.Core (mermaid)

```mermaid
classDiagram
class CategoryResponse {
    +CategoryID: Guid
    +CategoryName: string
    +CategoryImage: string
    +CategoryIcon: string
    +IsFeatured: bool
    +ProductCount: int
}

class ProductResponse {
    +ProductID: Guid
    +ProductName: string
    +ProductDescription: string
    +ProductPrice: decimal
    +ProductURL: string
    +IsFeatured: bool
    +Stock: int
}

class BrandResponse {
    +BrandID: Guid
    +BrandName: string
    +BrandLogo: string
    +ProductCount: int
}

class GetCatalogFullResponse {
    +Categories : List~CategoryResponse~
    +Products : List~ProductResponse~
    +Brands : List~BrandResponse~
    +TotalProducts : int
    +TotalCategories : int
    +TotalBrands : int
}

class GetCatalogOverviewResponse {
    +FeaturedCategories : List~CategoryResponse~
    +FeaturedProducts : List~ProductResponse~
    +RecommendedProducts : List~ProductResponse~
    +TotalProducts : int
    +TotalCategories : int
    +TotalBrands : int
}

GetCatalogFullResponse "1" *-- "0..n" BrandResponse : has
GetCatalogFullResponse "1" *-- "0..n" CategoryResponse : has
GetCatalogFullResponse "1" *-- "0..n" ProductResponse : has

GetCatalogOverviewResponse "1" *-- "0..n" CategoryResponse : has
GetCatalogOverviewResponse "1" *-- "0..n" ProductResponse : has
GetCatalogOverviewResponse "1" *-- "0..n" ProductResponse : has

```

Exemple de diagramme de classe pour les responses de l'API.

Ici, on a une classe `GetCatalogFullResponse` qui contient une liste de `CategoryResponse`, une liste de `ProductResponse` et une liste de `BrandResponse`. On peut voir que la classe `GetCatalogFullResponse` a une relation d'association avec les classes `CategoryResponse`, `ProductResponse` et `BrandResponse`. La relation est de type `1` à `0..n` (un `GetCatalogFullResponse` peut avoir 0 ou plusieurs `CategoryResponse`, `ProductResponse` et `BrandResponse`).

Nous avons aussi une classe `GetCatalogOverviewResponse` qui contient une liste de `CategoryResponse`, une liste de `ProductResponse` et une seconde liste de `ProductResponse`. On peut voir que la classe `GetCatalogOverviewResponse` a une relation d'association avec les classes `CategoryResponse`, `ProductResponse` et `ProductResponse`. La relation est de type `1` à `0..n` (un `GetCatalogOverviewResponse` peut avoir 0 ou plusieurs `CategoryResponse`, `ProductResponse` et `ProductResponse`).


### GetCatalogFullEndpoint

```mermaid
classDiagram
    class CategoryRepository {
        +GetAllAsync() List~Category~
    }
    
    class ProductRepository {
        +GetAllAsync() List~Product~
    }
    
    class BrandRepository {
        +GetAllAsync() List~Brand~
    }

    class GetCatalogFullResponse {
        +Categories : List~CategoryResponse~
        +Products : List~ProductResponse~
        +Brands : List~BrandResponse~
        +TotalProducts : int
        +TotalCategories : int
        +TotalBrands : int
    }
    
    class GetCatalogFullMapper {
        +FromEntity(CatalogFull) GetCatalogFullResponse
    }
    
    class CatalogService {
        +GetCatalogFullAsync() GetCatalogFullResponse
    }

    class EndpointWithoutRequest~TRequest, TMapper~ {
        +Configure()List~Category~
        +HandleAsync~CancellationToken~
    
    }
    
    class GetCatalogFullEndpoint~GetCatalogFullResponse, GetCatalogFullMapper~ {
        +GetCatalogFullEndpoint(CatalogService catalogService)
        +Configure()
        +HandleAsync(CancellationToken ct)
    }
    
    EndpointWithoutRequest~TRequest, TMapper~ <|-- GetCatalogFullEndpoint
    GetCatalogFullEndpoint~GetCatalogFullResponse, GetCatalogFullMapper~ *-- "1" GetCatalogFullMapper : uses
    GetCatalogFullEndpoint~GetCatalogFullResponse, GetCatalogFullMapper~ <.. "1" CatalogService
    GetCatalogFullEndpoint~GetCatalogFullResponse, GetCatalogFullMapper~ *-- "1" GetCatalogFullResponse : uses
    GetCatalogFullMapper *-- "1" GetCatalogFullResponse : uses
    CatalogService <.. CategoryRepository
    CatalogService <.. ProductRepository
    CatalogService <.. BrandRepository
    
```

## Analyse du Back-end (API)

### Architecture

Le projet est divisé en 3 couches :

- **DataAccess** : contient les classes de modèles et de contexte de base de données
- **Services** : contient les services de gestion des données
- **Endpoints** : contient les endpoints de l'API




## Analyse du besoin

### Fonctionnalités

- Gestion des utilisateurs
- Gestion des produits
- Gestion des commandes
- Gestion des catégories
- Gestion des marques
- Gestion des avis
- Gestion des promotions
- Gestion des stocks
- Gestion des images
- Gestion des favoris
- Gestion des paniers
- Gestion des adresses
- Gestion des paiements
- Gestion des livraisons
- Gestion des factures
- Gestion des statistiques
- Gestion des notifications

## Services


