using System;
using System.Collections.Generic;
using Models;

namespace Models
{
    public  class ShoppingCart 
    {
        //public static  = new Dictionary<Product, int>();
        public int ShoppingCartId { get; set; }
        public Customer ShoppingCartCustomer { get; set; }
        public Product ShoppingCartProd { get; set; }
        public int ShoppingCartQuantity { get; set; }


        }
}