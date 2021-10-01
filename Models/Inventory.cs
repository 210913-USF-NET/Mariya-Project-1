using System.Collections.Generic;

namespace Models
{
    public class Inventory
    {
        public int InventoryID { get; set; }
        public int StoreID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public StoreFront StoreFront { get; set; }
        public List<LineItem> LineItemsList { get; set; }
    //public override string ToString()
    //    {
    //        return $"\nProduct ID : {this.ProductID} Quantity available: {this.Quantity}";
    //    }
    }
}