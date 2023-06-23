using Organic.Models.Product;
using Organic.Repository;
using Organic.Services.Produit.Interface;
using Organic.ViewModels.Search;

namespace Organic.Services.Produit;

public class ProduitAdvancedSearchService : IProduitSearchService
{
    public async Task<PageResult<ProduitView>> Search(ProduitSearchViewModel? model, Page page)
    {
        IList<ProduitView> produitViews = new List<ProduitView>()
        {
            new("produit 1", 500, "bierre"),
            new("produit 2", 450, "bierre"),
            new("produit 3", 700, "bierre")
        };

        return PageResult<ProduitView>.GetInstance(page, 10, produitViews);
    }
}