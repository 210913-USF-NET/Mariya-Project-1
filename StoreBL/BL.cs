using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DL;
using Models;

namespace StoreBL
{
    public class BL : IBL
    {
        private IRepo _repo;
        public BL(IRepo repo)
        {
            _repo = repo;
        }
        public Customer AddCustomer(Customer newCustomer)
            {
            //newCustomer.CustomerId = new Guid();
            return _repo.AddCustomer(newCustomer);
            }
        public List<Customer> FindCustomersByName(string fname, string lname)
            {
                return _repo.FindCustomersByName(fname, lname);
            }
        public Customer FindOneCustomerById(int custID)
            {
            return _repo.FindOneCustomerById(custID);
            }
        public List<Customer> GetAllCustomers()
            {
            return _repo.GetAllCustomers();
            }
        public void RemoveCustomer(Customer currentCustomer)
            {
            _repo.RemoveCustomer(currentCustomer);
            }
        public void CustomerStoreUpdate(int custId, int newStoreID)
            {
             _repo.CustomerStoreUpdate(custId,newStoreID);
            }

        public List<Product> ProductsList()
            {
            return _repo.ProductsList();
            }

        public List<Customer> FindCustomersByName(string qryString)
            {
            throw new NotImplementedException();
            }

        public Customer FindOneCustomersByName(string fname, string lname)
            {
            return _repo.FindOneCustomersByName(fname, lname);
            }

        public List<Product> ProductsListByGenre()
            {
            
            return _repo.ProductsListByGenre();
            }

        public Product AddProduct(Product newProduct)
            {
            return _repo.AddProduct(newProduct);
            }
        //public decimal ShoppingCartTotal(Dictionary<Product, int> myCart)
        //    {
        //    return ShoppingCart.MyCart.Sum(x => x.Key.Price);
        //    }

        public Product GetProduct(int input)
            {
            return _repo.GetProduct(input);
            }
        public List<Inventory> GetInventoryByStoreID(Customer newCustomer)
            {
            return _repo.GetInventoryByStoreID(newCustomer);
            }

        public StoreFront GetMyStore(Customer cust)
            {
            return _repo.GetMyStore(cust);
            }

        public List<StoreFront> GetAllStoreFronts()
            {
            return _repo.GetAllStoreFronts();
            }
    

        public Order AddNewOrder(Order newOrd)
            {
            return _repo.AddNewOrder(newOrd);
            }

        public void AddLineItems(List<LineItem> items)
            {
            _repo.AddLineItems(items);
            }

        public void InventoryToUpdate(List<Inventory> items)
            {
            _repo.InventoryToUpdate(items);
            }

        public List<Order> ListOfOrdersByCust(Customer cust)
            {
            return _repo.ListOfOrdersByCust(cust);
            }

        public List<LineItem> LineItemsList()
            {
            return _repo.LineItemsList();
            }

        public List<Order> ListOrder()
            {
            return _repo.ListOrder();
            }

        public List<Inventory> GetInventoryForAdmin(int input)
            {
            return _repo.GetInventoryForAdmin(input);
            }

        public Customer FindOneCustomersByUserName(string username)
            {
            return _repo.FindOneCustomersByUserName(username);
            }

        public Customer UpdateCustomer(Customer currentCustomer)
            {
            return _repo.UpdateCustomer(currentCustomer);
            }

        public Product UpdateProduct(Product prodToUpdate)
            {
            return _repo.UpdateProduct(prodToUpdate);
            }

        public void RemoveProduct(Product prodToUpdate)
            {
            _repo.RemoveProduct(prodToUpdate);
            }

    
        public void InventoryToRemove(List<Inventory> items)
            {
            _repo.InventoryToRemove(items);
            }


        public StoreFront AddStoreFront(StoreFront store)
            {
            return _repo.AddStoreFront(store);
            }

        public StoreFront UpdateStoreFront(int ID)
            {
            throw new NotImplementedException();
            }

        public void RemoveStoreFront(int ID)
            {
            throw new NotImplementedException();
            }

        public Product AddProduct(int input)
            {
            throw new NotImplementedException();
            }
        }
    }
