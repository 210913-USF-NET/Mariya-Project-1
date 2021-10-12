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
        // GET: OrderController
        public ActionResult Index()
            {
            List<LineItem> myorder = _bl.LineItemsListByOrderID(int.Parse(ViewBag.Order));
            return View(myorder);
            }
        public ActionResult IndexCust()
            {
            return View();
            }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
            {
            return View();
            }

        // GET: OrderController/Create
        public ActionResult Create(int custId, List<int> lineId)
            {
            return View();
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
            decimal mytotal = decimal.Parse(ViewBag.Total);
            //need to update
            List<Inventory> inventoUpdate= _bl.GetInventoryByStoreID(Storeid);
            //need to go through cart and update above tables and then delete cart and ViewBag total
            List<ShoppingCart> cart= _bl.GetShoppingCartByCustId(custId);
            Order newOrder = new Order();
            newOrder.OrderCustomerID = custId;
            newOrder.OrderStoreID = Storeid;
            newOrder.OrderTotal = mytotal;
            Order checkedout = _bl.AddNewOrder(newOrder);
                ViewBag.Order = checkedout.OrderId.ToString();
                foreach(var item in cart)
                    {
                    LineItem linelist = new LineItem();
                    linelist.LineOrderID = (int)checkedout.OrderId;
                    linelist.LineProductID = item.ProductID;
                    linelist.Quantity = (int)item.Quantity;
                    linelist.Product = item.Product;
                    linelist.StoreId = item.StoreId;
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
                checkedout.LineItems = _bl.LineItemsListByOrderID((int)checkedout.OrderId);
                _bl.EmptyShoppingCart(cart);
                ViewBag.Total = null;
                return RedirectToAction(nameof(Index));
                }
            catch(Exception e)
                {
                Log.Information($"{e}");
                return View();
                }
            }

        }
    }
