namespace Organic.Repository;

public class PageResult<T> where T : class
{
    // Numéro de page
    public int PageIndex { get; set; }
    
    //Nombre d'élément par page
    public int ItemsNumber { get; set; }
    public int TotalPage { get; set; }
    public IEnumerable<T> Result { get; set; }

    private PageResult()
    {
        Result = new List<T>();
    }

    public static PageResult<T> GetInstance(int number, int itemsNumber, int count, IEnumerable<T> result)
    {

        return GetInstance(new Page(number, itemsNumber), count, result);
    }

    public static PageResult<T> GetInstance(Page page,int count, IEnumerable<T> data)
    {
        return new PageResult<T>()
        {
            PageIndex = page.Number,
            TotalPage = GetTotalPage(count, page.Size),
            ItemsNumber = page.Size,
            Result = data
            // Result = data as List<T>
        };
    }

    private static int GetTotalPage(int count, int itemsPage)
    {
        // Console.WriteLine(Math.Ceiling(40/10));
        return (int)Math.Ceiling(count / (double) itemsPage);
    }
}