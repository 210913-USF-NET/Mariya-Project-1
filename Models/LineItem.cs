using System.Collections.Generic;

namespace Models
{
    public class LineItem
    {

        public int LineItemId { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int StoreId { get; set; }
        public Inventory Inventories { get; set; }
        public int Quantity { get; set; }
        public Order Order { get; set; }
        
        }
}