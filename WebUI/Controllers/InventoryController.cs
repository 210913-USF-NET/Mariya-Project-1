using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using StoreBL;
using WebUI.Models;

namespace WebUI.Controllers
    {
    public class InventoryController : Controller
        {
        private readonly IBL _bl;
        public InventoryController(IBL bl)
            {
            _bl = bl;
            }
        // GET: InventoryController
        public ActionResult Index(int id)
            {
            ViewData["Int"] = id;
            ViewBag.Store = _bl.GetOneStoreFront(id);
            List<Inventory> myInventory = _bl.GetInventoryByStoreID(id);
            foreach(var p in myInventory)
                {

                }
            return View(myInventory);
            }


        // GET: InventoryController/Details/5
        public ActionResult Details(int id)
            {
            return View();
            }

        // GET: InventoryController/Create
        public ActionResult Create(int storeId)
            {
            //int storenum = int.Parse(storeId);
            ViewBag.Store = _bl.GetOneStoreFront(storeId);
            return View(new Inventory(storeId));
            }

        // POST: InventoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inventory inventory)
            {
            Product prod = _bl.GetOneProduct(inventory.InvProductID);
            inventory.Product = prod;
            try
                {
                Inventory inven = _bl.AddInventory(inventory);
                return RedirectToAction(nameof(Index),new {id = inventory.InvStoreID });
                }
            catch
                {
                return View();
                }
            }

        // GET: InventoryController/Edit/5
        public ActionResult Edit(int id)
            {
            return View();
            }

        // POST: InventoryController/Edit/5
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

        // GET: InventoryController/Delete/5
        public ActionResult Delete(int id)
            {
            return View();
            }

        // POST: InventoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
