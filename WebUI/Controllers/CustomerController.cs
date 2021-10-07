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
            Customer toEdit = _bl.GetOneCustomerById(id);
            return View(toEdit);
            }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Customer cust)
            {
            try
                {
                _bl.RemoveCustomer(id);
                return RedirectToAction(nameof(Index));
                }
            catch
                {
                return View();
                }
            }
        // POST: CustomerController/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout(Customer cust)
            {
            try
                {
                
                cust = null;
                TempData["CustomerId"] = null;
                TempData.Remove("CustomerId");
                return RedirectToAction("Index", "Home");
                }
            catch
                {
                return RedirectToAction("Index", "Home");
                }
            }
        // POST: CustomerController/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Customer cust)
            {

            
                Customer loggedin = _bl.VerifyLogin(cust.UserName, cust.Password);
            if (loggedin == null)
                {
                TempData["CustomerId"] = null;
                return RedirectToAction("Create");
                }
            else if (loggedin.UserName =="Admin")
                    {
                TempData["CustomerId"] = cust.CustomerId.ToString();
                TempData.Keep("CustomerId");
              
                return RedirectToAction("Index", "Home", loggedin);
                    }
                else
                    {
                
                TempData["CustomerId"] = cust.CustomerId.ToString();
                TempData.Keep("CustomerId");
              
                    return RedirectToAction("Index", "Home", loggedin);
                
                }
                }
        }
    }
