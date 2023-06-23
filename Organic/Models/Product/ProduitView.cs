using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organic.Models.Product;

[Table("v_produit")]
public class ProduitView
{
    [Column("id")]
    public int Id { get; set; }
    [Column("produit")]
    public string Produit { get; set; }
    [Display(Name = "Sachet de")]
    [Column("sachet")]
    public double Sachet { get; set; }
    [Column("category")]
    public string Category { get; set; }

    public ProduitView()
    {
    }

    public ProduitView(string produit, double sachet, string category)
    {
        Produit = produit;
        Sachet = sachet;
        Category = category;
    }
}