using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace WebUI.Models
    {
    public class OrderVM
        {
        public long OrderId { get; set; }
        public int OrderCustomerID { get; set; }
        public int OrderStoreID { get; set; }
        public List<LineItem> LineItems { get; set; }
        public Customer Customer { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime Date { get; set; }
        public int LineItemId { get; set; }
        public int LineProductID { get; set; }
        public int StoreId { get; set; }

        public int Quantity { get; set; }

        }
    }
