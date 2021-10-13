using System;
using System.Collections.Generic;
using Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DL;


namespace DL
    {
    public class Repo : IRepo
        {
        private  readonly StoreDBContext _context;
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
            return  _context.Customers.FirstOrDefault(u => u.UserName == user && u.Password == pass);
            }

        public Customer GetOneCustomerById(int custID)
            {
            return _context.Customers.Include(x => x.OrdersList).FirstOrDefault(u => u.CustomerId == custID);

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
                IsAdmin = x.IsAdmin,
                }).ToList();

            }
        public Customer UpdateCustomer(Customer currentCustomer)
            {
            Customer updatedcust = new Customer()
                {
                CustomerId = currentCustomer.CustomerId,
                FirstName = currentCustomer.FirstName,
                LastName = currentCustomer.LastName,
                UserName = currentCustomer.UserName,
                Password = currentCustomer.Password,
                Email = currentCustomer.Email,
                Street = currentCustomer.Street,
                City = currentCustomer.City,
                State = currentCustomer.State,
                Country = currentCustomer.Country,
                CustomerDefaultStoreID = currentCustomer.CustomerDefaultStoreID,
                IsAdmin = currentCustomer.IsAdmin,
                OrdersList = GetListOrderbyCustID(currentCustomer.CustomerId)

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
                ImageName = prod.ImageName,
                ProductAuthor = prod.ProductAuthor,
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
        public List<string> ProdGenreList()
            {
            List<string> Genres= _context.Products.Select(x => x.Genre).Distinct().ToList();
            return Genres;
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
        public StoreFront GetStoreByCustomerId(int custId)
            {
            return _context.StoreFronts.Include(x => x.Inventories).ThenInclude(x => x.Product).Select(x => new StoreFront()
                {
                StoreFrontId = x.StoreFrontId,
                StoreName = x.StoreName,
                StoreStreet = x.StoreStreet,
                StoreCity = x.StoreCity,
                StoreState = x.StoreState,
                StoreCountry = x.StoreCountry
                }).FirstOrDefault(i => i.StoreFrontId == custId);
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

        public List<Inventory> GetInventoryByStoreID(int  storeId)
            {
            return _context.Inventories.ToList().Where(x => x.InvStoreID == storeId).ToList();
            }

        public Inventory AddInventory(Inventory inventoryToAdd)
            {
            Inventory toUpdate = new Inventory()
                {
                InvStoreID = inventoryToAdd.InvStoreID,
                InvProductID = inventoryToAdd.InvProductID,
                InventoryID = inventoryToAdd.InventoryID,
                Quantity = inventoryToAdd.Quantity,
                };
            toUpdate = _context.Add(toUpdate).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return toUpdate;
            }
        public List<LineItem> LineItemsListByOrderID(int orderID)
            {
            List <LineItem> line = _context.LineItems.Include("Product").Where(i => i.LineOrderID == orderID).Select(i => i).ToList();
            foreach(var l in line)
                {
                l.Product = GetOneProduct(l.LineProductID);
                }
            return line;
            }
        public LineItem GetLineItemDetailsbyId(int lineitemID)
            {
            return _context.LineItems.FirstOrDefault(i => i.LineItemId == lineitemID);
            }
        public LineItem AddLineItem(LineItem item)
            {
            //LineItem linetoAdd = new LineItem()
            //    {
            //    LineOrderID = item.LineOrderID,
            //    LineProductID = item.LineProductID,
            //    StoreId = item.StoreId,
            //    Quantity = item.Quantity,
            //    Product = item.Product,
                
            //    };
            //_context.LineItems.(linetoAdd).State = EntityState.Added;
            item = _context.Add(item).Entity;
            //_context.R
            //_context.LineItems.Attach(linetoAdd);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return item;
            }
        public LineItem UpdateLineItem(LineItem lineItem)
            {
            LineItem linetoUpdate = new LineItem()
                {
                LineItemId = lineItem.LineItemId,
                LineOrderID = lineItem.LineOrderID,
                LineProductID = lineItem.LineProductID,
                StoreId = lineItem.StoreId,
                Quantity = lineItem.Quantity,
                };
            linetoUpdate = _context.Update(linetoUpdate).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return linetoUpdate;
            }
        public List<Order> GetListOrderbyCustID(int id)
            {
            List<Order> orders = _context.Orders.Where(x => x.OrderCustomerID == id).Select(r => r).ToList();
            foreach(var o in orders)
                {
                List<LineItem> items = _context.LineItems.Where(x => x.LineOrderID == o.OrderId).ToList();
                o.LineItems = items;

                }
           
            return orders;
            }

        public List<Order> ListOrder()
            {
            return _context.Orders.Select(r => new Order()).ToList();
            }
        public Order AddNewOrder(Order newOrd)
            {
            newOrd = _context.Add(newOrd).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return newOrd;
            }
        public Order UpdateOrder(Order myOrder)
            {
            _context.Update(myOrder);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return myOrder;
            }
        /// <summary>
        /// Takes a list of inventory created in UI and adds in a foreach loop
        /// </summary>
        /// <param name="items"></param>



        public List<Order> ListOfOrdersByCust(Customer currentCustomer)
            {
            return _context.Orders.Where(x => x.OrderCustomerID == currentCustomer.CustomerId).Select(r => r).ToList();
            }


        public List<Inventory> GetInventoryForAdmin(int input)
            {
            return _context.Inventories.Where(y => y.InvStoreID == input).Select(i => new Models.Inventory()).ToList();
            }


        public ShoppingCart AddShoppingCart(ShoppingCart shoppingCart)
            {
            ShoppingCart toUpdate = new ShoppingCart()
                {
                CustId = shoppingCart.CustId,
                ProductID = shoppingCart.ProductID,
                Quantity = shoppingCart.Quantity,
                StoreId = shoppingCart.StoreId,
                Product = GetOneProduct(shoppingCart.ProductID)
                };
            toUpdate = _context.Add(toUpdate).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return toUpdate;
            }

        public List<ShoppingCart> GetShoppingCartByCustId(int CustId)
            {
            return _context.ShoppingCarts.Include("Product").ToList().Where(x => x.CustId == CustId).ToList();
            }

        public ShoppingCart UpdateShoppingCart(ShoppingCart cart)
            {
            _context.ShoppingCarts.Update(cart);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return cart;
            }

        public void RemoveItemFromShoppingCart(ShoppingCart cart)
            {
           // ShoppingCart todelte = _context.ShoppingCarts.FirstOrDefault(x => x.Id == cart.Id);
            _context.Remove(cart);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            }

        public Inventory InventoryToUpdate(Inventory inv)
            {
            Inventory toupdate = new Inventory()
                {
                InventoryID = inv.InventoryID,
                InvStoreID = inv.InvStoreID,
                InvProductID = inv.InvProductID,
                Quantity = inv.Quantity,
                Product = GetOneProduct(inv.InvProductID)
                };

            _context.Update(toupdate);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return inv;
            }

        public void InventoryToRemove(int id)
            {
            Inventory todelte = _context.Inventories.FirstOrDefault(x => x.InventoryID == id);
            _context.Remove(todelte);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            }



        public void EmptyShoppingCart(List<ShoppingCart> mycart, int custId)
            {
            List<ShoppingCart> myCart = _context.ShoppingCarts.Where(x => x.CustId == custId).ToList();
            foreach (var item in myCart)
                {
                _context.Remove(item);
                }
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            }

        public Order GetLastOrderPlacedbyCust(int custId)
            {
            return _context.Orders.Where(x => x.OrderCustomerID == custId).OrderByDescending(x => x.Date).FirstOrDefault();
            }

        public Inventory GetInventoryByinvID(int id)
            {
            return _context.Inventories.FirstOrDefault(x => x.InventoryID == id);
            }

        public List<Order> AdminOrderHistoryDA(int id)
            {
            return _context.Orders.Include("LineItems").Where(x => x.OrderCustomerID == id || x.OrderStoreID == id).OrderBy(x => x.Date).ToList();
            }

        public List<Order> AdminOrderHistoryDD(int id)
            {
            return _context.Orders.Include("LineItems").Where(x => x.OrderCustomerID == id || x.OrderStoreID == id).OrderByDescending(x => x.Date).ToList();
            }

        public List<Order> AdminOrderHistoryTA(int id)
            {
            return _context.Orders.Include("LineItems").Where(x => x.OrderCustomerID == id || x.OrderStoreID == id).OrderBy(x => x.OrderTotal).ToList();
            }

        public List<Order> AdminOrderHistoryTD(int id)
            {
            return _context.Orders.Include("LineItems").Where(x => x.OrderCustomerID == id || x.OrderStoreID == id).OrderByDescending(x => x.OrderTotal).ToList();
            }
        }
    }