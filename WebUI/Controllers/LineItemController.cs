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
    public class LineItemController : Controller
        {
        private readonly IBL _bl;
        public LineItemController(IBL bl)
            {
            _bl = bl;
            }
        // GET: LineItemController
        public ActionResult Index(int id)
            {
            List<LineItem> lineItems = _bl.LineItemsListByOrderID(id);
            return View(lineItems);
            }

        // GET: LineItemController/Details/5
        public ActionResult Details(int id)
            {
           LineItem item = _bl.GetLineItemDetailsbyId(id);
            return View(item);
            }

        // GET: LineItemController/Create
        public ActionResult Create(int id)
            {
            return View();
            }

        // POST: LineItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LineItem lineItem, int id)
            {
            try
                {
                _bl.AddLineItem(lineItem, id);
                return RedirectToAction(nameof(Index));
                }
            catch
                {
                return View();
                }
            }

        // GET: LineItemController/Edit/5
        public ActionResult Edit(int id)
            {
            List<LineItem> linelist = _bl.LineItemsListByOrderID(id);
            return View(linelist);
            }

        // POST: LineItemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LineItem lineItem)
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

        // GET: LineItemController/Delete/5
        public ActionResult Delete(int id)
            {
            return View();
            }

        // POST: LineItemController/Delete/5
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
