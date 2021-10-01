using System;
using System.Collections.Generic;

namespace Models
{
    public class Order
    {
        public long OrderId { get; set; }
        public int CustomerID { get; set; }
        public int StoreID { get; set; }
        public List<LineItem> LineItems { get; set; }
        public Customer Customer { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }
    }
}