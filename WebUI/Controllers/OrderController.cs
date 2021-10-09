using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebUI.Controllers
    {
    public class OrderController : Controller
        {
        // GET: OrderController
        public ActionResult Index()
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
        public ActionResult Create(Customer customer, List<LineItem> lineItems)
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

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
            {
            return View();
            }

        // POST: OrderController/Edit/5
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

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
            {
            return View();
            }

        // POST: OrderController/Delete/5
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
