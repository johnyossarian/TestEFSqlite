using TestEFSqlite.Database;
using TestEFSqlite.Model;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
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
                WriteLine(string.Format("Product Table Record Count: {0}", ProductCount));
                ++ProductCount;
                
                List<Product> productList = new List<Product>();

                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int i = 0;  i < 1000; i++)
                {
                    Product product = new Product { Name = "New Product #" + ProductCount.ToString(), Width = 1.456M, Height = 1.789M, Depth = 1.123M, Weight = 1.135M };
                    db.Products.Add(product);
                    db.Products.Add(product);
                    db.SaveChanges();
                    
                }
                WriteLine(string.Format("Record Saved, elapsed: {0}ms", sw.ElapsedMilliseconds));
                sw.Restart();

                db.Products.AddRange(productList);


                WriteLine(string.Format("Record List Saved, elapsed: {0}ms", sw.ElapsedMilliseconds));
                sw.Restart();

                List<Product> products = db.Products.ToList();

                WriteLine(string.Format("1000 Records retreived, elapsed: {0}ms", sw.ElapsedMilliseconds));
                sw.Restart();

                /*foreach (Product p in products)
                {
                    WriteLine(string.Format("ID: {0} Name: {1}, HxWxD: {2}X{3}X{4}", p.ProductID, p.Name, p.Height, p.Width, p.Depth, p.Weight));
                }*/

                WriteLine("Press Enter to exit...");
                ReadKey();
            }
        }
    }
}
