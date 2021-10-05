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
    public class CustomerController : Controller
        {
        private IBL _bl;
        public CustomerController(IBL bl)
            {
            _bl = bl;
            }
        // GET: HomeController1
        public ActionResult Index()
            {
            List<Customer> allCustomer = _bl.GetAllCustomers();
            return View(allCustomer);
            }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
            {
            return View();
            }

        // GET: HomeController1/Create
        public ActionResult Create()
            {
            return View();
            }

        // POST: HomeController1/Create
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

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
            {
            return View();
            }

        // POST: HomeController1/Edit/5
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

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
            {
            return View();
            }

        // POST: HomeController1/Delete/5
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
