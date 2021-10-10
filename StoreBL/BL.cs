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
        public List<Customer> GetCustomersByName(string fname, string lname)
            {
                return _repo.GetCustomersByName(fname, lname);
            }
        public Customer GetOneCustomerById(int custID)
            {
            return _repo.GetOneCustomerById(custID);
            }
        public Customer GetOneCustomersByName(string fname, string lname)
            {
            return _repo.GetOneCustomersByName(fname, lname);
            }
        public Customer VerifyLogin(string user, string pass)
            {
            return _repo.VerifyLogin(user,pass);
            }

        public Customer UpdateCustomer(Customer currentCustomer)
            {
            return _repo.UpdateCustomer(currentCustomer);
            }

        public List<Customer> GetAllCustomers()
            {
            return _repo.GetAllCustomers();
            }
        public void RemoveCustomer(int custID)
            {
            _repo.RemoveCustomer(custID);
            }
  

        public List<Product> ProductsList()
            {
            return _repo.ProductsList();
            }




        public List<Product> ProductsListByGenre(string genre)
            {
            
            return _repo.ProductsListByGenre(genre);
            }

        public Product AddProduct(Product newProduct)
            {
            return _repo.AddProduct(newProduct);
            }
        //public decimal ShoppingCartTotal(Dictionary<Product, int> myCart)
        //    {
        //    return ShoppingCart.MyCart.Sum(x => x.Key.Price);
        //    }

        public Product GetOneProduct(int ProdId)
            {
            return _repo.GetOneProduct(ProdId);
            }
        public List<Inventory>  GetInventoryByStoreID(int storeId)
            {
            return _repo.GetInventoryByStoreID(storeId);
            }


        public List<StoreFront> GetAllStoreFronts()
            {
            return _repo.GetAllStoreFronts();
            }
        public StoreFront AddStoreFront(StoreFront store)
            {
            return _repo.AddStoreFront(store);
            }

        public StoreFront GetStoreByCustomerId(int custId)
            {
            return _repo.GetStoreByCustomerId(custId);
            }

        public void RemoveStoreFront(int ID)
            {
            _repo.RemoveStoreFront(ID);
            }


        public StoreFront GetOneStoreFront(int id)
            {
            return _repo.GetOneStoreFront(id);
            }

        public StoreFront UpdateStoreFront(StoreFront store)
            {
            return _repo.UpdateStoreFront(store);
            }

        public Order AddNewOrder(Order newOrd)
            {
            return _repo.AddNewOrder(newOrd);
            }

        public LineItem AddLineItem(LineItem item, int id)
            {
            return _repo.AddLineItem(item, id);
            }
        public LineItem UpdateLineItem(LineItem lineItem)
            {
            return _repo.UpdateLineItem(lineItem);
            }
        public void InventoryToUpdate(List<Inventory> items)
            {
            _repo.InventoryToUpdate(items);
            }
        public List<LineItem> LineItemsListByOrderID(int orderId)
            {
            return _repo.LineItemsListByOrderID(orderId);
            }
        public LineItem GetLineItemDetailsbyId(int lineID)
            {
            return _repo.GetLineItemDetailsbyId(lineID);
            }


        public List<Order> ListOfOrdersByCust(Customer cust)
            {
            return _repo.ListOfOrdersByCust(cust);
            }



        public List<Order> ListOrder()
            {
            return _repo.ListOrder();
            }
        public Inventory AddInventory(Inventory inventoryToAdd)
            {
            return _repo.AddInventory(inventoryToAdd);
            }
        public List<Inventory> GetInventoryForAdmin(int input)
            {
            return _repo.GetInventoryForAdmin(input);
            }

 
        public Product UpdateProduct(Product prod)
            {
            return _repo.UpdateProduct(prod);
            }

        public void RemoveProduct(int ProdId)
            {
            _repo.RemoveProduct(ProdId);
            }

    
        public void InventoryToRemove(List<Inventory> items)
            {
            _repo.InventoryToRemove(items);
            }



        }
    }
