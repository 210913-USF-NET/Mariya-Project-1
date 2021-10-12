using System.Collections.Generic;

namespace Models
{
    public class Inventory
    {
        public Inventory()
            {
            //this.InvProductID = Product.ProductId;
            this.Product = new Product(InvProductID);
  
            
            //this.StoreFront = new StoreFront(InvStoreID);
            }
        public Inventory(int id) : this()
            {
            this.InvStoreID = id;
            //this.StoreFront.StoreFrontId = id;
            }

        public int InventoryID { get; set; }
        public int InvStoreID { get; set; }
        public int InvProductID { get; set; }
        public Product Product { get; set; }
        
        public int Quantity { get; set; }
        //public StoreFront StoreFront { get; set; }
        //public List<LineItem> LineItemsList { get; set; }

        }
}