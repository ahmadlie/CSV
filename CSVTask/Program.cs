using CSVTask.Helper;

namespace CSVTask;
public class Program
{
    public static void Main(string[] args)
    {
        //var csvLines = File.ReadLines("D:\\ConsolApps\\CSVTask\\CSVTask\\CSV\\task.csv.txt");
        CSVHelper cSVHelper = new CSVHelper();
        CSVHelper.ConvertToClass("D:\\ConsolApps\\CSVTask\\CSVTask\\CSV\\task.csv.txt");

        
        
        Console.WriteLine("__________________");
        Console.WriteLine("Categories");
        foreach (var category in CSVHelper.Categories)
        {
            Console.WriteLine(category.CategoryType);
        }

        
        Console.WriteLine("__________________");
        Console.WriteLine("Employees");
        foreach (var employee in CSVHelper.Employees)
        {
            Console.WriteLine(employee.Name);
        }


        
        Console.WriteLine("__________________");
        Console.WriteLine("Orders");
        foreach (var order in CSVHelper.Orders)
        {
            Console.WriteLine($"{order.Name} => {order.Count}");
        }


        
        Console.WriteLine("__________________");
        Console.WriteLine("Products");
        foreach (var product in CSVHelper.Products)
        {
            Console.WriteLine($"{product.Name} => {product.Count}");
        }
    }

   
}