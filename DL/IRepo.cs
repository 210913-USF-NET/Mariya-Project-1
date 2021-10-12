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
        List<string> ProdGenreList();
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
        Inventory InventoryToUpdate(Inventory inv);
        void InventoryToRemove(int id);

        ShoppingCart AddShoppingCart(ShoppingCart shoppingCart);
        List<ShoppingCart> GetShoppingCartByCustId(int CustId);
        ShoppingCart UpdateShoppingCart(ShoppingCart shoppingCart);
        void RemoveItemFromShoppingCart(ShoppingCart shoppingCart);
        void EmptyShoppingCart(List<ShoppingCart> mycart);

        LineItem AddLineItem(LineItem item);
        List<LineItem> LineItemsListByOrderID(int orderId);
        LineItem UpdateLineItem(LineItem lineItem);
        LineItem GetLineItemDetailsbyId(int lineId);

        Order AddNewOrder(Order newOrd);
        Order UpdateOrder(Order myOrder);
        
        
        List<Order> ListOfOrdersByCust(Customer cust);
        List<Order> ListOrder();



        }
    }