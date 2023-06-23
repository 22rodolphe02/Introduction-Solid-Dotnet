namespace Organic.Repository;

public class Page
{
    public int Size { get; set; }
    public int Number { get; set; }
    
    public Page(){}

    public Page(int number, int size)
    {
        Number = number;
        Size = size;
    }
    
}

/*public static void Main()
{
    Console.WriteLine("bonjour");
}*/