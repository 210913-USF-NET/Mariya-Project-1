using System.Collections.Generic;

namespace Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public List<Inventory> Inventories { get; set; }
        public int MyProperty { get; set; }
        //public override string ToString()
        //{
        //    return $"Product Name: {this.Name}\nProduct Id: {this.ProductId} Product Price: {this.Price:C}\nProduct Genre: {this.Genre}\nProduct Description: {this.Description}\n";
        //}
        }
}