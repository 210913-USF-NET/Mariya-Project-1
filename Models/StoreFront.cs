using System;
using System.Collections.Generic;


namespace Models
{
    public class StoreFront
    {
        //public StoreFront()
        //    {
        //    StoreID = new Guid();
        //    }
     
        public int StoreFrontId { get; set; }
        public string StoreName { get; set; }
        public string StoreStreet { get; set; }
        public string StoreCity { get; set; }
        public string StoreState { get; set; }
        public string StoreCountry { get; set; }

        //public override string ToString(){
        //    return $"\nStore ID: {this.StoreID}\nStore Name: {this.Name}\nAddress: {this.Address}";
        //}

        public List<Inventory> Inventories { get; set; }
    }
}