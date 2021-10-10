using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace WebUI.Models
    {
    public class StoreVM
        {
        public StoreVM() { }
        public StoreVM(StoreFront store) 
            {
            this.Id = store.StoreFrontId;
            this.Name = store.StoreName;
            this.Street = store.StoreState;
            this.City = store.StoreCity;
            this.State = store.StoreState;
            this.Country = store.StoreCountry;
            this.Inventories = store.Inventories;
            }
        //public StoreVM(Inventory inven)
        //    {
        //    this.InventoryID = inven.InventoryID;
        //    this.InvProductID = inven.InvProductID;
        //    this.InvStoreID = inven.InvStoreID;
        //    this.Quantity = inven.Quantity;
        //    }
        //public StoreFront(int id)
        //    {
        //    this.StoreFrontId = id;
        //    }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }


        public List<Inventory> Inventories { get; set; }
        }
    }
