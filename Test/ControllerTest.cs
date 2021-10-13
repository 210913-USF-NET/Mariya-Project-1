using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using WebUI.Controllers;
using StoreBL;
using Models;
using Microsoft.AspNetCore.Mvc;

namespace Test
    {
    public class ControllerTest
        {
        [Fact]
        public void CustomerIndexShouldReturnListOfCustomers()
            {
            var mockBL = new Mock<IBL>();
            mockBL.Setup(x => x.GetAllCustomers()).Returns(
                new List<Customer>() 
                    { 
                    new Customer()
                        {
                        CustomerId = 1,
                        FirstName = "Bob",
                        LastName = "Green",
                        UserName = "BigGreen",
                        Password = "pass",
                        Street = "1234 st",
                        City = "Boston",
                        State= "MA",
                        Country = "USA",
                        CustomerDefaultStoreID =1,
                        IsAdmin = false,
                        Email = "email@mail.com"
                        },
                    new Customer()
                        {
                        CustomerId = 2,
                        FirstName = "Nancy",
                        LastName = "Wheeler",
                        UserName = "SimpleLife",
                        Password = "pass",
                        Street = "12 Main",
                        City = "Hawkins",
                        State= "IN",
                        Country = "USA",
                        CustomerDefaultStoreID =4,
                        IsAdmin = false,
                        Email = "email@mail.com"
                        }
                    }
                );
            var controller = new CustomerController(mockBL.Object);
            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model =Assert.IsAssignableFrom<IEnumerable<Customer>>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());

            }
        [Fact]
        public void ProductIndexShouldReturnListOfProd()
            {
            var mockBL = new Mock<IBL>();
            mockBL.Setup(x => x.ProductsList()).Returns(
                new List<Product>()
                    {
                    new Product()
                        {
                        ProductId = 1,
                        Price = 1.00M,
                        ProductAuthor = "me",
                        ProductName = "Book",
                        Description= "testing",
                        Genre = "help",
                        ImageName = "name"
                        },
                    new Product()
                        {
                        ProductId = 2 ,
                        Price = 1.00M,
                        ProductAuthor = "mycat",
                        ProductName = "Name",
                        Description= "testing",
                        Genre = "help",
                        ImageName = "name"
                        }
                    }
                );
            var controller = new ProductController(mockBL.Object);
            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Product>>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
            }
        [Fact]
        public void StoreIndexShouldReturnListOfStores()
            {
            var mockBL = new Mock<IBL>();
            mockBL.Setup(x => x.GetAllStoreFronts()).Returns(
                new List<StoreFront>()
                    {
                    new StoreFront()
                        {
                        StoreCity = "maine",
                        StoreFrontId =1,
                        StoreCountry  = "usa",
                        StoreName = "name",
                        StoreState = "FL",
                        StoreStreet = "145 Main"
                        },
                    new StoreFront()
                        {
                        StoreCity = "city",
                        StoreFrontId =2,
                        StoreCountry  = "usa",
                        StoreName = "store",
                        StoreState = "FL",
                        StoreStreet = "12 Main"
                        }
                    }
                );
            var controller = new StorefrontController(mockBL.Object);
            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<StoreFront>>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
            }
        //[Fact]
        //public void OrderIndexShouldReturnListOfOrders()
        //    {
        //    var mockBL = new Mock<IBL>();
        //    int test = 1;
        //    mockBL.Setup(x => x.ListOrder()).Returns(
        //        new List<Order>()
        //            {
        //            new Order()
        //                {
        //                OrderCustomerID =1,
        //                OrderId =4,
        //                OrderStoreID =1,
        //                OrderTotal = 15.00M,
        //                Date = DateTime.Now,
        //                LineItems = new List <LineItem>(){
        //                    new LineItem()
        //                        {
        //                        LineItemId = 1,
        //                        LineOrderID=4,
        //                        LineProductID=1,
        //                        StoreId=1,
        //                        Quantity =1,
        //                        Product = new Product()
        //                            {
        //                            ProductId = 1,
        //                            Price = 1.00M,
        //                            ProductAuthor = "me",
        //                            ProductName = "Book",
        //                            Description= "testing",
        //                            Genre = "help",
        //                            ImageName = "name"
        //                            },
        //                        },
        //                    },
        //                },
        //            new Order()
        //                {
        //               OrderCustomerID =1,
        //                OrderId =6,
        //                OrderStoreID =3,
        //                OrderTotal = 15.00M,
        //                Date = DateTime.Now,
        //                LineItems = new List <LineItem>(){
        //                    new LineItem()
        //                        {
        //                        LineItemId = 2,
        //                        LineOrderID=6,
        //                        LineProductID=1,
        //                        StoreId=3,
        //                        Quantity =1,
        //                        Product = new Product()
        //                            {
        //                            ProductId = 1,
        //                            Price = 1.00M,
        //                            ProductAuthor = "me",
        //                            ProductName = "Book",
        //                            Description= "testing",
        //                            Genre = "help",
        //                            ImageName = "name"
        //                            },

        //                        }
        //                    }
        //                }
        //            }
        //        );
        //    var controller = new OrderController(mockBL.Object);
        //    var result = controller.Index(1);

        //    var viewResult = Assert.IsType<ViewResult>(result);
        //    var model = Assert.IsAssignableFrom<IEnumerable<Order>>(viewResult.ViewData.Model);
        //    Assert.Equal(2, model.Count());
        //    }
        }
    }
