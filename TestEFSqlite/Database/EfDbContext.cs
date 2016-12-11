using System.Data.Entity;
using TestEFSqlite.Model;


namespace TestEFSqlite.Database
{
    class EfDbContext : DbContext
    {

        public EfDbContext() : base("EfDbConnection") { }

        public DbSet<Product> Products { get; set; }
    }
}
