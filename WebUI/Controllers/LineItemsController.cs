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
    public class LineItemsController : Controller
        {
        private readonly IBL _bl;
        public LineItemsController(IBL bl)
            {
            _bl = bl;
            }
        // GET: LineItemsController
        public ActionResult Index(int id)
            {
            List<LineItem> myorders = _bl.LineItemsListByOrderID(id);
            return View(myorders);
            }

        // GET: LineItemsController/Details/5
        public ActionResult Details(int id)
            {
            return View();
            }

        // GET: LineItemsController/Create
        public ActionResult Create()
            {
            return View();
            }

        // POST: LineItemsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: LineItemsController/Edit/5
        public ActionResult Edit(int id)
            {
            return View();
            }

        // POST: LineItemsController/Edit/5
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

        // GET: LineItemsController/Delete/5
        public ActionResult Delete(int id)
            {
            return View();
            }

        // POST: LineItemsController/Delete/5
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
