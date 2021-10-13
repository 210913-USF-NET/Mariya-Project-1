using System.Collections.Generic;
using Models;

namespace StoreBL
{
    public interface IBL
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

        ShoppingCart AddShoppingCart(ShoppingCart shoppingCart);
        List<ShoppingCart> GetShoppingCartByCustId(int CustId);
        ShoppingCart UpdateShoppingCart(ShoppingCart shoppingCart);
        void RemoveItemFromShoppingCart(ShoppingCart shoppingCart);
        void EmptyShoppingCart(List<ShoppingCart> mycart, int custId);

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
        Inventory GetInventoryByinvID(int id);

        LineItem AddLineItem(LineItem item);
        List<LineItem> LineItemsListByOrderID(int orderId);
        LineItem UpdateLineItem(LineItem lineItem);
        LineItem GetLineItemDetailsbyId(int lineID);

        Order AddNewOrder(Order newOrd);
        Order UpdateOrder(Order myOrder);
        Order GetLastOrderPlacedbyCust(int custId);
        List<Order> AdminOrderHistoryDA(int id);
        List<Order> AdminOrderHistoryDD(int id);
        List<Order> AdminOrderHistoryTA(int id);
        List<Order> AdminOrderHistoryTD(int id);

        List<Order> ListOfOrdersByCust(Customer cust);
        List<Order> ListOrder();
        


        ///shopping cart view list option? or add and remove options for shopping cart here?
        ///to add itemst to shoppinhg cart use key.product Id= int input to prod id

        }
}