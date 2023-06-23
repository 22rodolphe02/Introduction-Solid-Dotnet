namespace Organic.ViewModels.Search;

public class ProduitSimpleSearchModel : ProduitSearchViewModel
{
    public double? QuantityMin { get; set; }
    public double? QuantityMax { get; set; }
    public string? Category { get; set; }
}