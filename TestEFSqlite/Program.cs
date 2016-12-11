using TestEFSqlite.Database;
using TestEFSqlite.Model;
using System.Linq;
using System.Collections.Generic;
using static System.Console;

namespace TestEFSqlite
{
    class Program
    {
        static void Main(string[] args)
        {
            using (EfDbContext db = new EfDbContext())
            {
                int ProductCount = db.Products.Count();
                ++ProductCount;
                
                Product product = new Product { Name = "New Product #" + ProductCount.ToString(), Width = 1.456M, Height = 1.789M, Depth = 1.123M, Weight = 1.135M };
                db.Products.Add(product);
                db.SaveChanges();

                List<Product> products = db.Products.ToList();
                foreach (Product p in products)
                {
                    WriteLine(string.Format("ID: {0} Name: {1}, HxWxD: {2}X{3}X{4}", p.ProductID, p.Name, p.Height, p.Width, p.Depth, p.Weight));
                }

                WriteLine("Press Enter to exit...");
                ReadKey();
            }
        }
    }
}
