using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
    {
    public class ShoppingCart
        {
        public ShoppingCart() { }
        public int Id { get; set; }
        public int CustId { get; set; }
        public int ProductID { get; set; }
        public int StoreId { get; set; }
        //public Inventory Inventories { get; set; }
        public int? Quantity { get; set; }
        public Product Product { get; set; }

        }
    }
