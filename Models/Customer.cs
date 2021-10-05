﻿using System;
using System.Collections.Generic;

namespace Models
{
    public class Customer
    {
        //deost that create new Guid?
        public Customer(){
            
        }

        //public Customer(string name) : this()
        //    {
        //    this.Name = name;

        //    }

        //public Customer(string name, string address) : this(name){
        //    this.Address = address;

        //}
        //public Customer(string name, int age, string address, int storeId) : this(name, address){

        //}
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int CustomerDefaultStoreID { get; set; }
        public List<Order> OrdersList { get; set; }
        public bool IsAdmin { get; set; }

        }
}
