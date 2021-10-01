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
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        //public override string ToString(){
        //    return $"\nStore ID: {this.StoreID}\nStore Name: {this.Name}\nAddress: {this.Address}";
        //}

        public List<Inventory> Inventories { get; set; }
    }
}