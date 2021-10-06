using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Customer
    {
        //deost that create new Guid?
        public Customer(){
            this.OrdersList = new List<Order>();
        }
        public Customer(int id) : this()
            {
            this.CustomerId = id;
            }
        public Customer(string username) : this()
            {
            this.UserName = username;
            }
        public Customer(string fname, string lname) : this()
            {
            this.FirstName = fname;
            this.LastName = lname;
            }
       

        public int CustomerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [RegularExpression("^[@.]+$", ErrorMessage = "Email requires @ and . please enter a valid Emal.")]
        public string Email { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public int CustomerDefaultStoreID { get; set; }
        public List<Order> OrdersList { get; set; }
        public bool IsAdmin { get; set; }

        }
}
