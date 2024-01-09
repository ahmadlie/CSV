using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CSVTask.Helper
{
    public  class CSVHelper
    {
        public static List<Employee> Employees { get; set; }
        public static List<Category> Categories { get; set; }
        public static List<Order> Orders { get; set; }
        public static List<Product> Products { get; set; }

        public CSVHelper() 
        { 
            Employees = new List<Employee>();
            Categories = new List<Category>();
            Orders = new List<Order>();
            Products = new List<Product>();
        }
        public static void ConvertToClass( string path)
        {
            List<string> csvLines = File.ReadLines(path).ToList();
            for (int i = 0; i < csvLines.Count(); i++)
            {
                string[] data = csvLines[i].Split(',');
                var types = Assembly.GetExecutingAssembly().GetTypes();
                var name = types[0].Name;
                var type = types.Where(x => x.Name == data[0].TrimStart().TrimEnd()).FirstOrDefault();
                if (type == null)
                    throw new Exception("Class Not Found!");
                else
                {
                    if (type.Name == "Employee")
                    {                       
                        for (int j = 1; j < data.Length; j++)
                        {
                            var obj = Activator.CreateInstance(type);

                            Employees.Add((Employee)obj);
                            foreach (var property in type.GetProperties())
                            {
                                property.SetValue(obj, data[j]);
                            }
                        }
                    }
                    else if (type.Name == "Category")
                    {
                        for (int j = 1; j < data.Length; j++)
                        {
                            var obj = Activator.CreateInstance(type);
                            Categories.Add((Category)obj);
                            foreach (var property in type.GetProperties())
                            {
                                if (data[j] == "Beverages")
                                {
                                    property.SetValue(obj, CategoryType.Beverage);
                                }
                                else
                                {
                                    property.SetValue(obj, CategoryType.SoftDrink);
                                }
                            }
                        }
                    }
                    else if (type.Name == "Order")
                    {
                        var obj = Activator.CreateInstance(type);
                        Orders.Add((Order)obj);


                        var props = type.GetProperties();
                        for (int j = 0; j < props.Count(); j++)
                        {
                            props[j].SetValue(obj, data[j + 1]);
                        }

                    }
                    else
                    {
                        var obj = Activator.CreateInstance(type);
                        Products.Add((Product)obj);
                        var props = type.GetProperties();
                        for (int j = 0; j < props.Count(); j++)
                        {
                            props[j].SetValue(obj, data[j + 1]);
                        }
                    }
                }
            }
        }
    }
}

