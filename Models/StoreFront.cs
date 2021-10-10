using System;
using System.Collections.Generic;


namespace Models
{
    public class StoreFront
    {
        public StoreFront()
            {
            //this.Inventories =new List<Inventory>();
            }
        public StoreFront(int id)
            {
            this.StoreFrontId =id;
            }
        public int StoreFrontId { get; set; }
        public string StoreName { get; set; }
        public string StoreStreet { get; set; }
        public string StoreCity { get; set; }
        public string StoreState { get; set; }
        public string StoreCountry { get; set; }


        public List<Inventory> Inventories { get; set; }
        }
}