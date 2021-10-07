using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
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

        // GET: StorefrontController/Details/5
        public ActionResult Details(int id)
            {
            return View();
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
                return RedirectToAction(nameof(Index));
                }
            catch
                {
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
                return RedirectToAction(nameof(Index));
                }
            catch
                {
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
                return RedirectToAction(nameof(Index));
                }
            catch
                {
                return View();
                }
            }
        }
    }
