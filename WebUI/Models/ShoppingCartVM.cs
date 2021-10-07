using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace WebUI.Models
    {
    public class ShoppingCartVM
        {
        
        public int StoreID { get; set; }
        public string CustomerFname { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public decimal Price { get; set; }
        public List<Product> shoppingCartProd { get; set; }
        public int Quantity { get; set; }

        }
    }
