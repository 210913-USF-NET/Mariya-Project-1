using System;
using System.Collections.Generic;

namespace Models
{
#nullable enable
    public class Order
    {
#nullable enable
        public Order()
            {
            this.Date = DateTime.Now;
            }
        public long OrderId { get; set; }
        public int OrderCustomerID { get; set; }
        public int OrderStoreID { get; set; }
        public List<LineItem>? LineItems { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime Date { get; set; }
    }
}