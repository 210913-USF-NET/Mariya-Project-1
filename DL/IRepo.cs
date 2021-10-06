using Models;
using System;
using System.Collections.Generic;


namespace DL
{
    public interface IRepo
    {
        Customer AddCustomer(Customer newCustomer);
        List<Customer> GetCustomersByName(string fname, string lname);
        Customer GetOneCustomersByName(string fname, string lname);
        Customer GetcustbyEmailUsername(string input);
        Customer GetOneCustomerById(int custID);
        void RemoveCustomer(int custID);
        List<Customer> GetAllCustomers();
        Customer UpdateCustomer(Customer currentCustomer);






        List<Product> ProductsList();
        List<Product> ProductsListByGenre(string genre);
        Product AddProduct(Product newProduct);
        Product GetProduct(int input);
        Product UpdateProduct(int ProdId);
        void RemoveProduct(int ProdId);
        List<Inventory> GetInventoryByStoreID(Customer newCustomer);
        List<Inventory> GetInventoryForAdmin(int input);
        void InventoryToUpdate(List<Inventory> items);
        void InventoryToRemove(List<Inventory> items);
        List<StoreFront> GetAllStoreFronts();
        StoreFront GetMyStore(Customer cust);
        StoreFront AddStoreFront(StoreFront store);
        StoreFront UpdateStoreFront(StoreFront store);
        void RemoveStoreFront(StoreFront store);
        Order AddNewOrder(Order newOrd);
        void AddLineItems(List<LineItem> items);
        List<Order> ListOfOrdersByCust(Customer cust);
        List<Order> ListOrder();
        List<LineItem> LineItemsList();


        }
    }