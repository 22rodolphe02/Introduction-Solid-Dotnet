using Microsoft.AspNetCore.Mvc;
using Organic.Models;
using Organic.Models.Product;
using Organic.Repository;
using Organic.Services.Core;
using Organic.Services.Produit.Interface;
using Organic.ViewModels.Search;

namespace Organic.Controllers;

public class ProduitController : Controller
{
    private readonly IProduitViewService _produitViewService;
    
    private readonly IProduitSearchService _produitSearchService;

    public ProduitController(IProduitSearchFactory<IProduitSearchService> factory, IProduitViewService produitViewService)
    {
        _produitViewService = produitViewService;
        _produitSearchService = factory.Create(ProduitSearchOption.Simple);
    }

    public async Task<IActionResult> Index(
        [Bind("Nom", "QuantityMin", "QuantityMax", "Category")]ProduitSimpleSearchModel? produitSearch, int number = 1, int size = 10)
    {
        // if (ModelState.IsValid)
        // {
        //     Console.WriteLine("valid");
        // }
        var data = _produitSearchService.Search(produitSearch, new Page(number, size));
        ViewData["request"] = produitSearch;
        return View(await data);
    }
}