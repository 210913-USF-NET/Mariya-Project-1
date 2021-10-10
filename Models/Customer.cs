using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Models
{
    [Serializable]
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
        [Display(Name = "First Name")]
        [BindProperty]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [BindProperty]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "User Name")]
        [BindProperty]
        public string UserName { get; set; }
        [Required]
        [BindProperty]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [BindProperty]
        [RegularExpression("^[@.]+$", ErrorMessage = "Email requires @ and . please enter a valid Emal.")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Street Address")]
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
        [Display(Name = "Store")]
        [BindProperty]
        public int CustomerDefaultStoreID { get; set; }
        public List<Order> OrdersList { get; set; }
        [BindProperty]
        [Display(Name = "Admin Privilege")]
        public bool IsAdmin { get; set; }

        }
}
