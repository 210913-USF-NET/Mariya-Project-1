using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DL;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Models;
using Xunit;
namespace Test
    {
    public class DLTest
        {
        private readonly DbContextOptions<StoreDBContext> options;


        public DLTest()
            {
            options = new DbContextOptionsBuilder<StoreDBContext>().UseSqlite("Filename=Test.db").Options;
            Seed();
            }
        private void Seed()
            {
            using (var context = new StoreDBContext(options))
                {
                //first, we are going to make sure
                //that the DB is in clean slate
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Customers.AddRange(
                    new Customer()
                        {
                        CustomerId = 1,
                        FirstName = "Bob",
                        LastName = "Fish",
                        UserName ="BFF",
                        Password ="pass",
                        Email = "email",
                        Street = "1234 Main",
                        City = "Lakeland",
                        State = "FL",
                        Country ="USA"
                        },
                    new Customer()
                        {
                        CustomerId = 2,
                        FirstName = "Andy",
                        LastName = "Bird",
                        UserName = "AFF",
                        Password = "passit",
                        Email = "email@usk.gov",
                        Street = "2 Green St",
                        City = "Odessa",
                        State = "KR",
                        Country = "UA"
                        }
                );

                context.SaveChanges();
                }

            }
        [Fact]
        public void AddingACustomerShouldAddACustomer()
            {
            using (var context = new StoreDBContext(options))
                {
                //Arrange with my repo and the item i'm going to add
                IRepo repo = new Repo(context);
                Customer customerToAdd = new Customer()
                    {
                    CustomerId = 3,
                    FirstName = "George",
                    LastName = "Horse",
                    UserName = "HGG",
                    Password = "pass1",
                    Email = "email@gmail.com",
                    Street = "1020 Main",
                    City = "Palm Springs",
                    State = "CA",
                    Country = "USA"
                    };

                //Act
                repo.AddCustomer(customerToAdd);
                }

            using (var context = new StoreDBContext(options))
                {
                //Assert
                Customer customer = context.Customers.FirstOrDefault(r => r.CustomerId == 3);

                Assert.NotNull(customer);
                Assert.Equal("George", customer.FirstName);
                Assert.Equal("Palm Springs", customer.City);
                Assert.Equal("CA", customer.State);
                }
            }
        [Fact]
        public void FindingExistingCustomerShouldReturnCustomer()
            {
            Customer cust;
            String custFName = "Bob";
            String custLName = "Fish";
            using (var context = new StoreDBContext(options))
                {
                //Arrange with my repo and the item i'm going to add
                IRepo repo = new Repo(context);


                //Act
                cust = repo.FindOneCustomersByName(custFName, custLName);
                }

            using (var context = new StoreDBContext(options))
                {
                //Assert
                
                Assert.NotNull(cust);
                Assert.Equal("Fish", cust.LastName);
                Assert.Equal("Lakeland", cust.City);
                Assert.Equal("FL", cust.State);
                }
            }
        [Fact]
        public void FindingExistingCustomersShouldReturnCustomers()
            {
            List<Customer> allcust = new List<Customer>();
            using (var context = new StoreDBContext(options))
                {
                //Arrange with my repo and the item i'm going to add
                IRepo repo = new Repo(context);


                //Act
                allcust = repo.GetAllCustomers();
                }

            using (var context = new StoreDBContext(options))
                {
                //Assert

                Assert.NotNull(allcust);
                Assert.Equal(2, allcust.Count);

                }
            }
        }
    }