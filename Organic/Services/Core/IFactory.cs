using Organic.Models;
using Organic.Services.Produit.Interface;

namespace Organic.Services.Core;

public interface IProduitSearchFactory<T> where T : class
{
    T Create(ProduitSearchOption type);
}