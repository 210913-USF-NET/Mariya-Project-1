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
    public class StorefrontController : Controller
        {
        private IBL _bl;
        public StorefrontController(IBL bl)
            {
            _bl = bl;
            }
        // GET: StorefrontController
        public ActionResult Index()
            {
            List<StoreFront> allStore = _bl.GetAllStoreFronts();
            
            return View(allStore);
            }
        // GET: StorefrontController
        public ActionResult IndexCust()
            {
            var mystore = HttpContext.Request.Cookies["MyStore"];
            int Storeid = int.Parse(mystore);
           
            //int Id = int.Parse(Storeid);
            List<string> genreList = _bl.ProdGenreList();
            ViewBag.Genre = genreList;
            StoreFront allStore = _bl.GetStoreByCustomerId(Storeid);
            ViewBag.myStore = allStore;
            List<Inventory> myInventory = _bl.GetInventoryByStoreID(Storeid);
            foreach (var prod in myInventory)
                {
                prod.Product = _bl.GetOneProduct(prod.InvProductID);
                //prod.Genre = genre;
                };
            
            return View(myInventory);
            }



        // GET: StorefrontController/Create
        public ActionResult Create()
            {
            return View();
            }

        // POST: StorefrontController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StoreFront store)
            {
            try
                {
                _bl.AddStoreFront(store);
                Log.Information("Store created");
                return RedirectToAction(nameof(Index));
                }
            catch (Exception e)
                {
                Log.Information($"{e}");
                return View();
                }
            }

        // GET: StorefrontController/Edit/5
        public ActionResult Edit(int id)
            {
            StoreFront toedit = _bl.GetOneStoreFront(id);
            return View(toedit);
            }

        // POST: StorefrontController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StoreFront store)
            {
            try
                {
                _bl.UpdateStoreFront(store);
                Log.Information("store updated");
                return RedirectToAction(nameof(Index));
                }
            catch (Exception e)
                {
                Log.Information($"{e}");
                return View();
                }
            }

        // GET: StorefrontController/Delete/5
        public ActionResult Delete(int id)
            {
            StoreFront toedit = _bl.GetOneStoreFront(id);
            
            return View(toedit);
            }

        // POST: StorefrontController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, StoreFront store)
            {
            try
                {
                _bl.RemoveStoreFront(id);
                Log.Information("Store delted");
                return RedirectToAction(nameof(Index));
                }
            catch (Exception e)
                {
                Log.Information($"{e}");
                return View();
                }
            }
        }
    }
