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
                context.Products.AddRange(
                    new Product()
                        {
                        ProductId = 1,
                        Price = 1.00M,
                        ProductAuthor = "me",
                        ProductName = "Book",
                        Description = "testing",
                        Genre = "help",
                        ImageName = "name"
                        },
                    new Product()
                        {
                        ProductId = 2,
                        Price = 1.00M,
                        ProductAuthor = "mycat",
                        ProductName = "Name",
                        Description = "testing",
                        Genre = "help",
                        ImageName = "name"
                        }
                    );
                context.StoreFronts.AddRange(
                    new StoreFront()
                        {
                        StoreCity = "maine",
                        StoreFrontId = 1,
                        StoreCountry = "usa",
                        StoreName = "name",
                        StoreState = "FL",
                        StoreStreet = "145 Main"
                        },
                    new StoreFront()
                        {
                        StoreCity = "city",
                        StoreFrontId = 2,
                        StoreCountry = "usa",
                        StoreName = "store",
                        StoreState = "FL",
                        StoreStreet = "12 Main"
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
                cust = repo.GetOneCustomersByName(custFName, custLName);
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
        public void FindingOneProductShouldReturnProduct()
            {
            int test = 1;
            Product product = new Product();
            using (var context = new StoreDBContext(options))
                {
                //Arrange with my repo and the item i'm going to add
                IRepo repo = new Repo(context);


                //Act
                product = repo.GetOneProduct(test);
                }

            using (var context = new StoreDBContext(options))
                {
                //Assert

                Assert.NotNull(product);
                Assert.Equal(1, product.ProductId);

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
        [Fact]
        public void FindingOneStoreShouldReturnStore()
            {
            int test = 1;
            StoreFront store = new StoreFront();
            using (var context = new StoreDBContext(options))
                {
                //Arrange with my repo and the item i'm going to add
                IRepo repo = new Repo(context);


                //Act
                store = repo.GetOneStoreFront(test);
                }

            using (var context = new StoreDBContext(options))
                {
                //Assert

                Assert.NotNull(store);
                Assert.Equal(1, store.StoreFrontId);

                }
            }
        [Fact]
        public void AddingAProductShouldAddAProduct()
            {
            using (var context = new StoreDBContext(options))
                {
                //Arrange with my repo and the item i'm going to add
                IRepo repo = new Repo(context);
                Product prodtoadd = new Product()
                    {
                    ProductId = 6,
                    Price = 10.00M,
                    ProductAuthor = "Willow",
                    ProductName = "Trying",
                    Description = "testing",
                    Genre = "help",
                    ImageName = "name"
                    };

                //Act
                repo.AddProduct(prodtoadd);
                }

            using (var context = new StoreDBContext(options))
                {
                //Assert
                Product product = context.Products.FirstOrDefault(r => r.ProductId == 6);

                Assert.NotNull(product);
                Assert.Equal("Willow", product.ProductAuthor);
                Assert.Equal("Trying", product.ProductName);
                Assert.Equal("name", product.ImageName);
                }
            }
        [Fact]
        public void AddingAStoreShouldAddAStore()
            {
            using (var context = new StoreDBContext(options))
                {
                //Arrange with my repo and the item i'm going to add
                IRepo repo = new Repo(context);
                StoreFront storetoadd = new StoreFront()
                    {
                    StoreCity = "sity",
                    StoreFrontId = 6,
                    StoreCountry = "usa",
                    StoreName = "Super",
                    StoreState = "FL",
                    StoreStreet = "145 Main"
                    };

                //Act
                repo.AddStoreFront(storetoadd);
                }

            using (var context = new StoreDBContext(options))
                {
                //Assert
                StoreFront store = context.StoreFronts.FirstOrDefault(r => r.StoreFrontId == 6);

                Assert.NotNull(store);
                Assert.Equal("Super", store.StoreName);
                Assert.Equal(6, store.StoreFrontId);
                Assert.Equal("FL", store.StoreState);
                }
            }
        }
    }