using System.Collections.Generic;

namespace Models
{
    public class LineItem
    {

        public int LineItemId { get; set; }
        public int LineOrderID { get; set; }
        public int LineProductID { get; set; }
        public int StoreId { get; set; }
        public Inventory Inventories { get; set; }
        public int Quantity { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }

        }
}