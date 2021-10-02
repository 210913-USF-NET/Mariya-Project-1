using Models;
using System;
using System.Collections.Generic;


namespace DL
{
    public interface IRepo
    {
        List<Customer> GetAllCustomers();
        List<Customer> FindOneCustomer(string qryString);
        Customer AddCustomer(Customer newCustomer);
        void RemoveCustomer(Customer currentCustomer);
        //Customer UpdateCustomer(Customer currentCustomer);
        //List<Product> ProductsList();
        //Product GetProduct(int input);
        //Product AddProduct(int input);
        //Product UpdateProduct(Product prodToUpdate);
        //void RemoveProduct(Product prodToUpdate);
        //List<Inventory> GetInventoryByStoreID(Customer newCustomer);
        //List<Inventory> GetInventoryForAdmin(int input);
        //void InventoryToUpdate(List<Inventory> items);
        //void InventoryToRemove(List<Inventory> items);
        //List<StoreFront> GetAllStoreFronts();
        //StoreFront GetMyStore(Customer cust);
        //StoreFront AddStoreFront(int ID);
        //StoreFront UpdateStoreFront(int ID);
        //void RemoveStoreFront(int ID);
        //Order AddNewOrder(Order newOrd);
        
        //void AddLineItems(List<LineItem> items);
        //List<Order> ListOfOrdersByCust(Customer cust);
        //List<Order> ListOrder();
        //List<LineItem> LineItemsList();
       

    }
}