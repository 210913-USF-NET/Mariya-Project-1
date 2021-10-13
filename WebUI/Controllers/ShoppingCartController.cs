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
    public class ShoppingCartController : Controller
        {
        private IBL _bl;
        public ShoppingCartController(IBL bl)
            {
            _bl = bl;
            }
        // GET: ShoppingCartController
        public ActionResult Index()
            {
            var userId = HttpContext.Request.Cookies["CustomerId"];
            int custId = int.Parse(userId);
            var id = HttpContext.Request.Cookies["MyStore"];
            int Storeid = int.Parse(id);
            List<ShoppingCart> myCart = _bl.GetShoppingCartByCustId(custId);
            decimal sum = 0.00M;
            foreach (var item in myCart)
                {
                if(item.Quantity == 0)
                    {
                    _bl.RemoveItemFromShoppingCart(item);
                    }
                item.Product = _bl.GetOneProduct(item.ProductID);
                item.CustId = custId;
                item.StoreId = Storeid;
                sum += item.Product.Price * (decimal)item.Quantity;
                }
            ViewBag.Total = sum.ToString();
            return View(myCart);
            }

        // GET: ShoppingCartController/Create
        public ActionResult Create()
            {
            return View();
            }

        // POST: ShoppingCartController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
            {
            try
                {
                var userId = HttpContext.Request.Cookies["CustomerId"];
                int custId = int.Parse(userId);
                var id = HttpContext.Request.Cookies["MyStore"];
                int Storeid = int.Parse(id);
                ShoppingCart mycart = new ShoppingCart();
                mycart.ProductID = int.Parse(collection["prod.InvProductID"]);
                mycart.Quantity = int.Parse(collection["prod.Quantity"]);

                mycart.StoreId = Storeid;
                mycart.CustId = custId;
                mycart.Product = _bl.GetOneProduct(int.Parse(collection["prod.InvProductID"]));


                _bl.AddShoppingCart(mycart);
                Log.Information("Cart created");
                return RedirectToAction(nameof(Index));
                }
            catch (Exception e)
                {
                Log.Information($"{e}");
                return View();
                }
            }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(IFormCollection collection)
            {
            try
                {
            var userId = HttpContext.Request.Cookies["CustomerId"];
            int custId = int.Parse(userId);
            var id = HttpContext.Request.Cookies["MyStore"];
            int Storeid = int.Parse(id);
            ShoppingCart mycart = new ShoppingCart();
            mycart.Id = int.Parse(collection["prod.Id"]);
            mycart.ProductID = int.Parse(collection["prod.ProductID"]);
            mycart.Quantity = int.Parse(collection["prod.Quantity"]);
            mycart.StoreId = Storeid;
            mycart.CustId = custId;
            mycart.Product = _bl.GetOneProduct(int.Parse(collection["prod.ProductID"]));
            if(int.Parse(collection["prod.Quantity"]) == 0){
                _bl.RemoveItemFromShoppingCart(mycart);
                return RedirectToAction(nameof(Index));
                }

                _bl.UpdateShoppingCart(mycart);
                Log.Information("Cart Updated");
                return RedirectToAction(nameof(Index));
                }
            catch (Exception e)
                {
                Log.Information($"{e}");
                return View();
                }
            }
        // GET: ShoppingCartController/Edit/5
        public ActionResult Edit(int id)
            {
            return View();
            }

        // POST: ShoppingCartController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
            {
            try
                {
                return RedirectToAction(nameof(Index));
                }
            catch
                {
                return View();
                }
            }

        }
    }
