using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Models;
using Serilog;
using StoreBL;

namespace WebUI.Controllers
    {
    public class CustomerController : Controller
        {
        private readonly IBL _bl;
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

        // GET: CustomerController/Create
        public ActionResult Create()
            {
            
            return View();
            }
        public ActionResult Login()
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
                
                Customer custcreated = _bl.AddCustomer(cust);
                HttpContext.Response.Cookies.Append("CustomerId", custcreated.CustomerId.ToString());
                HttpContext.Response.Cookies.Append("MyStore", custcreated.CustomerDefaultStoreID.ToString());
                Log.Information("Customer Created");
                return RedirectToAction("IndexCust", "StoreFront");
                }
            catch (Exception e)
                {
                Log.Information($"{e}");
                return View();
                }
            }

        // GET: CustomerController/Edit/5
        public ActionResult Profile()
            {
            var userId = HttpContext.Request.Cookies["CustomerId"];
            int custId = int.Parse(userId);
            Customer toEdit = _bl.GetOneCustomerById(custId);
            return View(toEdit);
            }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Profile(int id, Customer cust)
            {
            try
                {

                Customer toEdit = _bl.UpdateCustomer(cust);
                HttpContext.Response.Cookies.Append("MyStore", toEdit.CustomerDefaultStoreID.ToString());
                return RedirectToAction("Index","Home");
                }
            catch (Exception e)
                {
                Log.Information($"{e}");
                return RedirectToAction(nameof(Index));
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

                Customer toEdit = _bl.UpdateCustomer(cust);
                HttpContext.Response.Cookies.Append("CustomerId", toEdit.CustomerId.ToString());
                HttpContext.Response.Cookies.Append("MyStore", toEdit.CustomerDefaultStoreID.ToString());
                return RedirectToAction(nameof(Index));
                }
            catch (Exception e)
                {
                Log.Information($"{e}");
                return RedirectToAction(nameof(Index));
                }
            }
        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
            {
             Customer todelete= _bl.GetOneCustomerById(id);

            return View(todelete);
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
            catch (Exception e)
                {
                Log.Information($"{e}");
                return RedirectToAction("Index", "Home");
                }
            
            }
        public ActionResult Logout(int id)
            {
            Customer toEdit = _bl.GetOneCustomerById(id);
            return View(toEdit);
            }
        // POST: CustomerController/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout(Customer cust)
            {
            try
                {
                Response.Cookies.Delete("CustomerId");
                Response.Cookies.Delete("MyStore");
                return RedirectToAction("Index", "Home");
                }
            catch (Exception e)
                {
                Log.Information($"{e}");
                return RedirectToAction("Index", "Home");
                }

            }
        // POST: CustomerController/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Customer cust)
            {
            try
                {

                Customer loggedin = _bl.VerifyLogin(cust.UserName, cust.Password);
                if (loggedin == null)
                    {
                    ViewBag.Customer = null;
                    ModelState.AddModelError(string.Empty, "That is not a valid Log in");
                    return View("Login");
                   
                    }
                else if (loggedin.IsAdmin)
                    {
                    HttpContext.Response.Cookies.Append("CustomerId", loggedin.UserName);
                    return RedirectToAction("Index", "Home", loggedin);
                    }
                else
                    {
                    ViewBag.Customer = loggedin;
                    HttpContext.Response.Cookies.Append("CustomerId", loggedin.CustomerId.ToString());
                    HttpContext.Response.Cookies.Append("MyStore", loggedin.CustomerDefaultStoreID.ToString());
                    return RedirectToAction("IndexCust", "StoreFront");

                    }
                }
            catch (Exception e)
                {
                Log.Information($"{e}");
                return View();
                }
            }

        }
    }
