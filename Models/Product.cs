using System.Collections.Generic;

namespace Models
{
    public class Product
    {
        public Product() { }

        public Product(int id) :this()
            {
            this.ProductId = id;
            }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductAuthor { get; set; }
        public decimal Price { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        //public List<Inventory> Inventories { get; set; }
        public string ImageName { get; set; }

       
        }
}