using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Serilog;
using StoreBL;

namespace WebUI.Controllers
    {
    public class OrderController : Controller
        {
        private IBL _bl;
        public OrderController(IBL bl)
            {
            _bl = bl;
            }
        public ActionResult HistoryOrder(string selectedBatchId)
            {
            if(Request.Cookies["HistoryOrder"] != null)
                {
                Response.Cookies.Delete("HistoryOrder");
                }
            Response.Cookies.Append("HistoryOrder", selectedBatchId);
            return RedirectToAction("Index", "Order" );
            }
        public ActionResult CustHistoryOrder(string selectedBatchId)
            {
            if (Request.Cookies["HistoryOrder"] != null)
                {
                Response.Cookies.Delete("HistoryOrder");
                }
            Response.Cookies.Append("HistoryOrder", selectedBatchId);
            return RedirectToAction("IndexHCust", "Order");
            }
        // GET: OrderController
        public ActionResult Index(int id)
            {
            int input = id;
            //Request.Cookies["Id"];
            //Response.Cookies.Append("Id", id.ToString());
            //var cookie = Request.Cookies["Id"];
            //int input = int.Parse(cookie);
  
            List<Order> orders = new List<Order>();
            if(Request.Cookies["HistoryOrder"] != null)
                {
                switch (Request.Cookies["HistoryOrder"])
                    {
                    case "Newest":
                        orders = _bl.AdminOrderHistoryDA(input);
                        break;
                    case "Oldest":
                        orders = _bl.AdminOrderHistoryDD(input);
                        break;
                    case "Total Highest":
                        orders = _bl.AdminOrderHistoryTD(input);
                        break;
                    case "Total Lowest":
                        orders = _bl.AdminOrderHistoryTA(input);
                        break;

                    }
                }
            else
                {
                orders = _bl.AdminOrderHistoryDA(input);
                }
            return View(orders);
            }
        public ActionResult IndexHCust()
            {
            var userId = HttpContext.Request.Cookies["CustomerId"];
            int custId = int.Parse(userId);
            List<Order> orders = new List<Order>();
            if (Request.Cookies["HistoryOrder"] != null)
                {
                switch (Request.Cookies["HistoryOrder"])
                    {
                    case "Newest":
                        orders = _bl.AdminOrderHistoryDA(custId);
                        break;
                    case "Oldest":
                        orders = _bl.AdminOrderHistoryDD(custId);
                        break;
                    case "Total Highest":
                        orders = _bl.AdminOrderHistoryTD(custId);
                        break;
                    case "Total Lowest":
                        orders = _bl.AdminOrderHistoryTA(custId);
                        break;
                    }
                }
            else
                {
                orders = _bl.AdminOrderHistoryDA(custId);
                }
                return View(orders);
            }
        public ActionResult IndexCust()
            {
            var userId = HttpContext.Request.Cookies["CustomerId"];
            int custId = int.Parse(userId);
            
            Order myOrder = _bl.GetLastOrderPlacedbyCust(custId);
            List<LineItem> linelist = _bl.LineItemsListByOrderID((int)myOrder.OrderId);
            myOrder.LineItems = linelist;
            return View(myOrder);
            }

        // GET: OrderController/Create
        public ActionResult Create(int custId, List<int> lineId)
            {
            return RedirectToAction(nameof(IndexCust));
            }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create()
            {
            try
                {
            var userId = HttpContext.Request.Cookies["CustomerId"];
            int custId = int.Parse(userId);
            var id = HttpContext.Request.Cookies["MyStore"];
            int Storeid = int.Parse(id);
            decimal mytotal = 1.00M;
            //need to update
            List<Inventory> inventoUpdate= _bl.GetInventoryByStoreID(Storeid);
            //need to go through cart and update above tables and then delete cart and ViewBag total
            List<ShoppingCart> cart= _bl.GetShoppingCartByCustId(custId);
            Order newOrder = new Order();
            newOrder.OrderCustomerID = custId;
            newOrder.OrderStoreID = Storeid;
            newOrder.OrderTotal = mytotal;
            
                Order checkedout = _bl.AddNewOrder(newOrder);
                ViewBag.Order = checkedout;
                foreach(var item in cart)
                    {
                    LineItem linelist = new LineItem();
                    linelist.LineOrderID = (int)checkedout.OrderId;
                    linelist.LineProductID = item.ProductID;
                    linelist.Quantity = (int)item.Quantity;

                    linelist.StoreId = item.StoreId;
                    mytotal += (decimal)item.Quantity * (item.Product.Price);
                    _bl.AddLineItem(linelist);
                    foreach(var inv in inventoUpdate)
                        {
                        if(inv.InvProductID == item.ProductID && inv.InvStoreID == item.StoreId)
                            {
                            inv.Quantity -= (int)item.Quantity;
                           
                            }
                        _bl.InventoryToUpdate(inv);
                        }
                    }
                checkedout.OrderTotal = mytotal;
               // checkedout.LineItems = _bl.LineItemsListByOrderID((int)checkedout.OrderId);
                _bl.UpdateOrder(checkedout);
                _bl.EmptyShoppingCart(cart, custId);
                Log.Information("OrderCreated");
                return RedirectToAction(nameof(IndexCust));
                }
            catch(Exception e)
                {
                Log.Information($"{e}");
                return RedirectToAction(nameof(IndexCust));
                }
            }

        }
    }
