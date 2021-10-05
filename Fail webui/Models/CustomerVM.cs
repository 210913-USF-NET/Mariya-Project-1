using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace WebUI.Models
    {
    public class CustomerVM
        {
        public CustomerVM() {}
        public CustomerVM(CustomerVM cust)
            {
            this.CustomerId = CustomerId;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.UserName = UserName;
            this.Password = Password;
            this.Email = Email;
            this.Street = Street;
            this.City = City;
            this.State = State;
            this.CustomerDefaultStoreID = CustomerDefaultStoreID;

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
        [RegularExpression(@"^[@.]+$", ErrorMessage = "Email must contain @ and .")]
        public string Email { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        //public string Country { get; set; }
        //[Required]
        public int CustomerDefaultStoreID { get; set; }
        public bool IsAdmin { get; set; } = false;

        public List<Order> OrdersList { get; set; }

        public Customer ToModel()
            {
            Customer newCust;
            try
                {
                newCust = new Customer
                    {
                    CustomerId = this.CustomerId,
                    FirstName = this.FirstName,
                    LastName = this.LastName,
                    UserName = this.UserName,
                    Password = this.Password,
                    Email = this.Email,
                    Street = this.Street,
                    City = this.City,
                    State = this.State,
                    CustomerDefaultStoreID = this.CustomerDefaultStoreID
                    };
                }
            catch
                {
                throw;
                }
            return newCust;

            }
        }
    }
