using BodyRocky.Back.WebApi.Services;
using BodyRocky.Core.Contracts.Requests;
using FastEndpoints;

// 4.1.	Application fenêtrée
//
//     ☐ Ajout d’un produit
//     ☒ Suppression d’un produit
//     ☐ Modification du stock
//     ☐ Afficher la liste des produits par catégorie
//     ☐ Modification des statuts des commandes (jusqu’à la livraison)
//     ☐ Afficher les produits faisant partie d’une commande spécifique
//     ☐ Afficher les commandes d’un client et le montant total de celles-ci
//
// 4.2.	Application web
//
//     ☒ Enregistrement d’un client
//     ☒ Connexion et déconnexion d’un client (adresse mail + mot de passe)
//     ☐ Afficher les produits selon certains critères
//     -	Catégorie
//     -	Marque
//     -	Mot-clé
//     ☐ Ajout d’un produit dans un panier
//     ☒ Afficher le contenu d’un panier ainsi que son sous-total
//     ☐ Passer une commande
//     ☐ Afficher les commandes d’un client
//     ☐ Afficher les produits d’une commande passée


namespace BodyRocky.Back.WebApi.Endpoints.Catalog.DeleteProduct;

public class DeleteProductEndpoint
    : Endpoint<DeleteProductRequest>
{
    private readonly CatalogService _catalogService;
    
    public DeleteProductEndpoint(CatalogService catalogService)
    {
        _catalogService = catalogService;
    }
    
    public override void Configure()
    {
        Delete("/catalog/products/{id}");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(DeleteProductRequest request, CancellationToken ct)
    {
        await _catalogService.DeleteProductAsync(request.ProductID);
        await SendOkAsync(request.ProductID.ToString(), ct);
    }
}