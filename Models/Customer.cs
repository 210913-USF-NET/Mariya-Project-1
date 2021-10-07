using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Models
{
    public class Customer
    {
      
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
       
        [TempData]
        public int CustomerId { get; set; }
        [Required]
        [BindProperty]
        public string FirstName { get; set; }
        [Required]
        [BindProperty]
        public string LastName { get; set; }
        [Required]
        [BindProperty]
        public string UserName { get; set; }
        [Required]
        [BindProperty]
        public string Password { get; set; }
        [Required]
        [BindProperty]
        [RegularExpression("^[@.]+$", ErrorMessage = "Email requires @ and . please enter a valid Emal.")]
        public string Email { get; set; }
        [Required]
        [BindProperty]
        public string Street { get; set; }
        [Required]
        [BindProperty]
        public string City { get; set; }
        [Required]
        [BindProperty]
        public string State { get; set; }
        [Required]
        [BindProperty]
        public string Country { get; set; }
        [Required]
        [BindProperty]
        public int CustomerDefaultStoreID { get; set; }
        public List<Order> OrdersList { get; set; }
        [BindProperty]
        public bool IsAdmin { get; set; }

        }
}
