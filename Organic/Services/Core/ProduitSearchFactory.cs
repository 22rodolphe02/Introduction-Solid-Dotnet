using Organic.Models;
using Organic.Services.Produit;

namespace Organic.Services.Core;

public class ProduitSearchFactory<T> : IProduitSearchFactory<T> where T : class
{
    private readonly IServiceProvider _serviceProvider;

    public ProduitSearchFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public T Create(ProduitSearchOption type)
    {
        var service = type switch
        {
            ProduitSearchOption.Simple => _serviceProvider.GetService(typeof(ProduitViewService)) as T,
            ProduitSearchOption.Advanced => _serviceProvider.GetService(typeof(ProduitAdvancedSearchService)) as T,
            _ => throw new Exception("type de recherche n'existe pas")
        };

        return service;
    }
}