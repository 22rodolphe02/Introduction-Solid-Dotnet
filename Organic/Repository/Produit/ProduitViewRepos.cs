using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Organic.Data;
using Organic.Models.Product;
using Organic.Repository.Produit.Interface;
using Organic.Repository.Seed;
using Organic.ViewModels.Search;

namespace Organic.Repository.Produit;

public class ProduitViewRepos : ReadRepository<ProduitView>,IProduitViewRepos
{
    public ProduitViewRepos(AppDbContext dbContext) : base(dbContext)
    {
    }
    public async Task<PageResult<ProduitView>> Search(ProduitSearchViewModel? request, Page page)
    {
        IQueryable<ProduitView> query = DbSet;
        if (request is ProduitSimpleSearchModel produitSearch )
        {
            
            /*if (produitSearch.QuantityMin != null)
            {
                query = query.Where(p => p.Sachet >= produitSearch.QuantityMin);
            }
            if (produitSearch.QuantityMax != null)
            {
                query = query.Where(p => p.Sachet <= produitSearch.QuantityMax);
            }
            if (!string.IsNullOrEmpty(produitSearch.Category))
            {
                query = query.Where(p => p.Category.ToLower().Contains(produitSearch.Category.ToLower()));
            }

            if (!string.IsNullOrEmpty(produitSearch.Nom))
            {
                query = query.Where(p => p.Produit.ToLower().Contains(produitSearch.Nom.ToLower()));
            } */
            
            
            query = query.Where(p =>
                (produitSearch.QuantityMin == null || p.Sachet >= produitSearch.QuantityMin) &&
                (produitSearch.QuantityMax == null || p.Sachet <= produitSearch.QuantityMax) &&
                (string.IsNullOrEmpty(produitSearch.Category) || p.Category.ToLower().Contains(produitSearch.Category.ToLower())) &&
                (string.IsNullOrEmpty(produitSearch.Nom) || p.Produit.ToLower().Contains(produitSearch.Nom.ToLower()))
            );

        }

        var data = await query
            .Skip((page.Number - 1) * page.Size)
            .Take(page.Size)
            .OrderBy(view => view.Produit)
            .ToListAsync();

        var pageResult = PageResult<ProduitView>.GetInstance(page,query.Count(), data);

        return pageResult;
    }
}