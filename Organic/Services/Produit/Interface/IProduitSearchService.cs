using Organic.Models.Product;
using Organic.Repository;
using Organic.ViewModels.Search;

namespace Organic.Services.Produit.Interface;

public interface IProduitSearchService
{
    public Task<PageResult<ProduitView>> Search(ProduitSearchViewModel? search, Page page);
}