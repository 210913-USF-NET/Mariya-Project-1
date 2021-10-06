using System.Collections.Generic;
using Models;

namespace StoreBL
{
    public interface IBL
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
        StoreFront UpdateStoreFront(int ID);
        void RemoveStoreFront(int ID);
        Order AddNewOrder(Order newOrd);
        void AddLineItems(List<LineItem> items);
        List<Order> ListOfOrdersByCust(Customer cust);
        List<Order> ListOrder();
        List<LineItem> LineItemsList();
        Product AddProduct(int input);
       
        ///shopping cart view list option? or add and remove options for shopping cart here?
        ///to add itemst to shoppinhg cart use key.product Id= int input to prod id

        }
}