using System.Collections.Generic;

namespace Models
{
    public class Inventory
    {
        public Inventory()
            {

            this.Product = new Product(InvProductID);

            }
        public Inventory(int id) : this()
            {
            this.InvStoreID = id;

            }

        public int InventoryID { get; set; }
        public int InvStoreID { get; set; }
        public int InvProductID { get; set; }
        public Product Product { get; set; }
        
        public int Quantity { get; set; }


        }
}