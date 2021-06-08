using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public enum Colour
    {
        white, black, green, blue, red
    }
    public enum Size
    {
        Small, Medium, Large, Huge
    }
    public class Product
    {
        public string Name;
        public Colour Colour;
        public Size Size;
        public Product(string name, Colour colour, Size size)
        {
            if (name == null)
            {
                throw new ArgumentNullException(paramName: nameof(name));
            }
            Name = name;
            Colour = colour;
            Size = size;
        }
    }

    public class ProductFilter
    {
        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var item in products)
            {
                if (item.Size == size)
                {
                    yield return item;
                }
            }
        }
        public IEnumerable<Product> FilterByColour(IEnumerable<Product> products, Colour colour)
        {
            foreach (var item in products)
            {
                if (item.Colour == colour)
                {
                    yield return item;
                }
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var apple = new Product("Apple", Colour.green, Size.Small);
            var tree = new Product("Tree", Colour.green, Size.Large);
            var house = new Product("House", Colour.blue, Size.Huge);

            Product[] products = { apple, tree, house };

            var pf = new ProductFilter();
            Console.WriteLine("Green Products (old):");
            foreach (var item in pf.FilterByColour(products,Colour.green))
            {
                Console.WriteLine( $"{item.Name} is green");
            }

            //CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
