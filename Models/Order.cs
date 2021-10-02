using System;
using System.Collections.Generic;

namespace Models
{
    public class Order
    {
        public long OrderId { get; set; }
        public int OrderCustomerID { get; set; }
        public int OrderStoreID { get; set; }
        public List<LineItem> LineItems { get; set; }
        public Customer Customer { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime Date { get; set; }
    }
}