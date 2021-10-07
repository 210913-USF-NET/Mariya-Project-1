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
        public Customer VerifyLogin(string user, string pass)
            {
            Customer loggIn = _context.Customers.FirstOrDefault(u => u.UserName == user && u.Password == pass);
            return loggIn;
            }

        public Customer GetOneCustomerById(int custID)
            {
            return _context.Customers.FirstOrDefault(u => u.CustomerId == custID);
            }
        public void RemoveCustomer(int custID)
            {
            
            _context.Customers.Remove(GetOneCustomerById(custID));
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
        public Customer UpdateCustomer(Customer cust)
            {
            Customer updatedcust = new Customer()
                {
                CustomerId = cust.CustomerId,
                FirstName = cust.FirstName,
                LastName = cust.LastName,
                UserName = cust.UserName,
                Password = cust.Password,
                Email = cust.Email,
                Street = cust.Street,
                City = cust.City,
                State = cust.State,
                Country = cust.Country,
                CustomerDefaultStoreID = cust.CustomerDefaultStoreID,
                IsAdmin = cust.IsAdmin
                };
            updatedcust = _context.Customers.Update(updatedcust).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return updatedcust;
            }
        public List<Product> ProductsList()
            {
            return _context.Products.Select(prod => new Product()
                {
                ProductId = prod.ProductId,
                ProductName = prod.ProductName,
                Price = prod.Price,
                Genre = prod.Genre,
                Description = prod.Description
                }).ToList();
            }

        public Product GetOneProduct(int ProdId)
            {
            return _context.Products.FirstOrDefault(x => x.ProductId == ProdId);
            }

        public Product UpdateProduct(Product prod)
            {
            Product updatedprod = new Product()
                {
                ProductId = prod.ProductId,
                ProductName = prod.ProductName,
                Price = prod.Price,
                Genre = prod.Genre,
                Description = prod.Description
                };

            updatedprod = _context.Products.Update(updatedprod).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return updatedprod;
            }

        public void RemoveProduct(int ProdId)
            {
            _context.Products.Remove(GetOneProduct(ProdId));
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
        public List<StoreFront> GetAllStoreFronts()
            {
            return _context.StoreFronts.Select(x => new StoreFront()
                {
                StoreFrontId = x.StoreFrontId,
                StoreName = x.StoreName,
                StoreStreet = x.StoreStreet,
                StoreCity = x.StoreCity,
                StoreState = x.StoreState,
                StoreCountry = x.StoreCountry
                }).ToList();
            }
        public StoreFront GetOneStoreFront(int id)
            {
            return _context.StoreFronts.FirstOrDefault(x => x.StoreFrontId == id);
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
            StoreFront storetoUpdate = new StoreFront()
                {
                StoreFrontId = store.StoreFrontId,
                StoreName = store.StoreName,
                StoreStreet = store.StoreStreet,
                StoreCity = store.StoreCity,
                StoreState = store.StoreState,
                StoreCountry = store.StoreCountry
                };
             storetoUpdate = _context.Update(storetoUpdate).Entity;
             _context.SaveChanges();
             _context.ChangeTracker.Clear();

            return storetoUpdate;
            }

        public void RemoveStoreFront(int id)
            {
            _context.Remove(GetOneStoreFront(id));
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            }

        public List<Inventory> GetInventoryByStoreID(Customer newCustomer)
            {
            return _context.Inventories.Where(y => y.InvStoreID == newCustomer.CustomerDefaultStoreID).Select(i => new Inventory()).ToList();
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




        

       
        }
    }