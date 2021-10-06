using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
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
        // GET: CustomerController
        public ActionResult Index()
            {
            List<Customer> allCustomer = _bl.GetAllCustomers();
            return View(allCustomer);
            }

        // GET: CustomerController/Details/5
        public ActionResult login(int id)
            {
            return View();
            }
        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
            {
            return View();
            }
        // GET: CustomerController/Create
        public ActionResult Create()
            {
            
            return View();
            }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer cust)
            {
            try
                {
                
                    _bl.AddCustomer(cust);
                    
                return RedirectToAction(nameof(Index));
                }
            catch
                {
                return View();
                }
            }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
            {
            Customer toEdit = _bl.GetOneCustomerById(id);
            return View(toEdit);
            }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer cust)
            {
            try
                {
              
                    _bl.UpdateCustomer(cust);
                    
                return RedirectToAction(nameof(Index));
                }
            catch
                {
                return RedirectToAction(nameof(Index));
                }
            }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
            {
            _bl.RemoveCustomer(id);
            return View();
            }

        // POST: CustomerController/Delete/5
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
