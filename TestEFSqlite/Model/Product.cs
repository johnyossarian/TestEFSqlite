using System;

namespace TestEFSqlite.Model
{
    class Product
    {
        public int ProductID { get; set; }

        public string Name { get; set; }

        public decimal Height { get; set; }

        public decimal Width { get; set; }

        public decimal Depth { get; set; }

        public decimal Weight { get; set; }

        public  DateTime DateAdded { get; set; }

        public Product()
        {
            DateAdded = DateTime.Now;        }
    }
}
