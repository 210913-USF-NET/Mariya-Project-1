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
        Customer VerifyLogin(string user, string pass);
        Customer GetOneCustomerById(int custID);
        void RemoveCustomer(int custID);
        List<Customer> GetAllCustomers();
        Customer UpdateCustomer(Customer currentCustomer);

        List<Product> ProductsList();
        List<Product> ProductsListByGenre(string genre);
        Product AddProduct(Product newProduct);
        Product GetOneProduct(int ProdId);
        Product UpdateProduct(Product prod);
        void RemoveProduct(int ProdId);

        List<StoreFront> GetAllStoreFronts();
        StoreFront AddStoreFront(StoreFront store);
        StoreFront GetStoreByCustomerId(int custId);
        StoreFront GetOneStoreFront(int id);
        StoreFront UpdateStoreFront(StoreFront store);
        void RemoveStoreFront(int id);

        Inventory AddInventory(Inventory inventoryToAdd);
        List<Inventory> GetInventoryByStoreID(int storeId);
        List<Inventory> GetInventoryForAdmin(int input);
        void InventoryToUpdate(List<Inventory> items);
        void InventoryToRemove(List<Inventory> items);

        LineItem AddLineItem(LineItem item, int id);
        List<LineItem> LineItemsListByOrderID(int orderId);
        LineItem UpdateLineItem(LineItem lineItem);
        LineItem GetLineItemDetailsbyId(int lineId);

        Order AddNewOrder(Order newOrd);
        
        List<Order> ListOfOrdersByCust(Customer cust);
        List<Order> ListOrder();



        }
    }