using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace WebUI.Models
    {
    public class InventoryVM
        {
        public int InventoryID { get; set; }
        public int InvStoreID { get; set; }
        public int InvProductID { get; set; }
        public List<Product> Product { get; set; }
        public int Quantity { get; set; }
        public StoreFront StoreFront { get; set; }
        public List<LineItem> LineItemsList { get; set; }
        }
    }
