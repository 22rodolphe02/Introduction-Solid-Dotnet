using Organic.Models.Product;
using Organic.Repository;
using Organic.Repository.Interface;
using Organic.Repository.Produit.Interface;
using Organic.Services.Produit.Interface;
using Organic.Services.Seed;
using Organic.ViewModels.Search;
using Organic.ViewModels.Search.Seed;

namespace Organic.Services.Produit;

public class ProduitViewService : ViewService<ProduitView>, IProduitViewService, IProduitSearchService
{
    private readonly IProduitViewRepos _viewRepos;
    
    public ProduitViewService(IReadRepository<ProduitView> repository, IProduitViewRepos viewRepos) : base(repository)
    {
        _viewRepos = viewRepos;
    }

    public async Task<PageResult<ProduitView>> Search(ProduitSearchViewModel? search, Page page)
    {
        return await _viewRepos.Search(search, page);
    }
}