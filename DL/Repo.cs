using System;
using System.Collections.Generic;
using Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
/*using Entity = DL.Entities;*/
using DL;


namespace DL
    {
    public class Repo : IRepo
        {
        private StoreDBContext _context;
        public Repo(StoreDBContext context)
            {
            _context = context;
            }
        /// <summary>
        /// Takes created model customer and converts to Entity customer then returns once customer has been added to DB
        /// </summary>
        /// <param name="newCustomer">model created from user input</param>
        /// <returns>Return customer obj once it's been added to DB</returns>
        public Customer AddCustomer(Customer newCustomer)
            {

            newCustomer = _context.Add(newCustomer).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return newCustomer;
            }

        ///// <summary>
        ///// Searches DB for any customers with name or username like input
        ///// </summary>
        ///// <param name="qryString">name string to get from user input in console</param>
        ///// <returns>List Of Customers with matching names</returns>
        public List<Customer> GetCustomersByName(string fname, string lname)
            {
            return _context.Customers.Where(u => u.FirstName.ToLower().Trim().Contains(fname.ToLower().Trim()) || u.LastName.ToLower().Trim().Contains(lname.ToLower().Trim())).ToList();
            }

        public Customer GetOneCustomersByName(string fname, string lname)
            {
            return _context.Customers.Where(u => u.FirstName.ToLower().Trim().Contains(fname.ToLower().Trim()) && u.LastName.ToLower().Trim().Contains(lname.ToLower().Trim())).FirstOrDefault();
            }
        public Customer GetcustbyEmailUsername(string input)
            {
            return _context.Customers.Where(u => u.UserName.ToLower().Trim().Contains(input.ToLower().Trim()) || u.Email.ToLower().Trim().Equals(input.ToLower().Trim())).FirstOrDefault();
            }

        public Customer GetOneCustomerById(int custID)
            {
            return _context.Customers.FirstOrDefault(u => u.CustomerId == custID);
            }
        public void RemoveCustomer(int custID)
            {
            Customer toDelete = _context.Customers.FirstOrDefault(x => x.CustomerId == custID);
            _context.Customers.Remove(toDelete);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            }
        public List<Customer> GetAllCustomers()
            {
            return _context.Customers.Select(x => new Customer()
                { 
                CustomerId = x.CustomerId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                UserName = x.UserName,
                Password = x.Password,
                Email = x.Email,
                Street = x.Street,
                City = x.City,
                State = x.State,
                Country = x.Country,
                CustomerDefaultStoreID = x.CustomerDefaultStoreID,
                IsAdmin = x.IsAdmin
                }).ToList();

            }
        public Customer UpdateCustomer(Customer currentCustomer)
            {
            Customer updatedcust = (from i in _context.Customers
                                   where i.CustomerId == currentCustomer.CustomerId
                                    select i).FirstOrDefault();
            currentCustomer = updatedcust;
            _context.Customers.Update(updatedcust);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return updatedcust;
            }
        public List<Product> ProductsList()
            {
            return _context.Products.Select(x => new Product()
                {
                ProductName = x.ProductName,
                ProductId = x.ProductId,
                Price = x.Price,
                Genre = x.Genre,
                Description = x.Description
                }
            ).ToList();
            }


        public Product UpdateProduct(int ProdId)
            {
            Product updatedprod = _context.Products.FirstOrDefault(x => x.ProductId == ProdId);
            _context.Products.Update(updatedprod);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return updatedprod;
            }

        public void RemoveProduct(int ProdId)
            {
            Product prodDelte = _context.Products.FirstOrDefault(x => x.ProductId == ProdId);
            
            _context.Products.Remove(prodDelte);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            }
        public List<Product> ProductsListByGenre(string genre)
            {
            return _context.Products.Where(x => x.Genre.Equals(genre)).Select(x => new Product()
                {
                ProductName = x.ProductName,
                ProductId = x.ProductId,
                Price = x.Price,
                Genre = x.Genre,
                Description = x.Description
                }
            ).ToList();
            }
        public Product AddProduct(Product newProduct)
            {

            newProduct = _context.Add(newProduct).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return newProduct;
            }

        /// Returns model store by inputting customer default store
        /// </summary>
        /// <param name="cust"> obj that is passed around while still logged in</param>
        /// <returns>StoreFront Obj</returns>
        public StoreFront GetMyStore(Customer cust)
            {
            StoreFront myStore = _context.StoreFronts.FirstOrDefault(x => x.StoreFrontId == cust.CustomerDefaultStoreID);
            return new StoreFront();
            }
        /// <summary>
        /// Returns list of Customers by using customer obj passed in getting list where cust store == inventory store
        /// </summary>
        /// <param name="newCustomer">bj that is passed around while still logged in</param>
        /// <returns>List of inventory items by customer default store</returns>
        public List<Inventory> GetInventoryByStoreID(Customer newCustomer)
            {
            return _context.Inventories.Where(y => y.InvStoreID == newCustomer.CustomerDefaultStoreID).Select(i => new Inventory()).ToList();
            }
        public List<StoreFront> GetStoreFronts()
            {
            return _context.StoreFronts.Select(r => new StoreFront()
                ).ToList();
            }
        public Product GetProduct(int input)
            {
            Product myProduct = _context.Products.FirstOrDefault(x => x.ProductId == input);
            return new Models.Product();
            }
        public Order AddNewOrder(Order newOrd)
            {
            newOrd = _context.Add(newOrd).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return newOrd;
            }
        /// <summary>
        /// Takes a list of inventory created in UI and adds in a foreach loop
        /// </summary>
        /// <param name="items"></param>
        public void InventorToUpdate(List<Inventory> items)
            {

            foreach (Inventory item in items)
                {

                Inventory updatedInventory = (from i in _context.Inventories
                                              where i.InvProductID == item.InvProductID && i.InvStoreID == item.InvStoreID
                                              select i).SingleOrDefault();

                updatedInventory.Quantity = item.Quantity;
                }
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            }
        public void AddLineItems(List<LineItem> items)
            {
            foreach (LineItem i in items)
                {
                items = _context.Add(items).Entity;
                }

            _context.SaveChanges();
            }

        public List<Order> ListOfOrdersByCust(Customer cust)
            {
            return _context.Orders.Where(x => x.OrderCustomerID == cust.CustomerId).Select(r => new Models.Order()).ToList();
            }
        public List<LineItem> LineItemsList()
            {
            return _context.LineItems.Select(i => new LineItem()).ToList();
            }
        public List<Order> ListOrder()
            {
            return _context.Orders.Select(r => new Order()).ToList();
            }


        public List<Inventory> GetInventoryForAdmin(int input)
            {
            return _context.Inventories.Where(y => y.InvStoreID == input).Select(i => new Models.Inventory()).ToList();
            }






        public void InventoryToUpdate(List<Inventory> items)
            {
            throw new NotImplementedException();
            }

        public void InventoryToRemove(List<Inventory> items)
            {
            throw new NotImplementedException();
            }

        public List<StoreFront> GetAllStoreFronts()
            {
            throw new NotImplementedException();
            }

        public StoreFront AddStoreFront(StoreFront store)
            {
            store = _context.Add(store).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return store;
            }

        public StoreFront UpdateStoreFront(StoreFront store)
            {
            store = _context.Update(store).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return store;
            }

        public void RemoveStoreFront(StoreFront store)
            {
            store = _context.Remove(store).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            }

        

       
        }
    }