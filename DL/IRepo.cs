using Models;
using System;
using System.Collections.Generic;


namespace DL
{
    public interface IRepo
    {
        List<Customer> GetAllCustomers();
        List<Customer> FindCustomersByName(string fname, string lname);
        Customer AddCustomer(Customer newCustomer);
        void RemoveCustomer(Customer currentCustomer);
        Customer FindOneCustomerById(int custID);
        Customer FindOneCustomersByUserName(string username);
        Customer FindOneCustomersByName(string fname, string lname);
        void CustomerStoreUpdate(int custId, int newStoreID);
        Customer UpdateCustomer(Customer currentCustomer);
        List<Product> ProductsList();
        List<Product> ProductsListByGenre();
        Product AddProduct(Product newProduct);
        Product GetProduct(int input);
        Product UpdateProduct(Product prodToUpdate);
        void RemoveProduct(Product prodToUpdate);
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