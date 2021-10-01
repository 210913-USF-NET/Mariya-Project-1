using System.Collections.Generic;
using Models;

namespace StoreBL
{
    public interface IBL
    {
        List<Customer> GetAllCustomers();
        List<Customer> FindOneCustomer(string qryString);
        Customer AddCustomer(Customer newCustomer);
        void RemoveCustomer(Customer currentCustomer);
        Customer UpdateCustomer(Customer currentCustomer);
        List<Product> ProductsList();
        Product GetProduct(int input);
        Product AddProduct(int input);
        Product UpdateProduct(Product prodToUpdate);
        void RemoveProduct(Product prodToUpdate);
        List<Inventory> GetInventoryByStoreID(Customer newCustomer);
        List<Inventory> GetInventoryForAdmin(int input);
        void InventorToUpdate(List<Inventory> items);
        List<StoreFront> GetAllStoreFronts();
        StoreFront GetMyStore(Customer cust);
        StoreFront AddStoreFront(int ID);
        StoreFront UpdateStoreFront(int ID);
        void RemoveStoreFront(int ID);
        Order AddNewOrder(Order newOrd);
        void AddLineItems(List<LineItem> items);
        List<Order> ListOfOrdersByCust(Customer cust);
        List<Order> ListOrder();
        List<LineItem> LineItemsList();
        ///shopping cart view list option? or add and remove options for shopping cart here?

        }
}