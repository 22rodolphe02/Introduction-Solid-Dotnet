using Organic.Models.Product;
using Organic.Repository.Interface;
using Organic.ViewModels.Search;
using Organic.ViewModels.Search.Seed;

namespace Organic.Repository.Produit.Interface;

public interface IProduitViewRepos : IReadRepository<ProduitView>
{
    public Task<PageResult<ProduitView>> Search(ProduitSearchViewModel? request, Page page);
}