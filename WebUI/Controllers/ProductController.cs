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
    public class ProductController : Controller
        {
        private readonly IBL _bl;
        public ProductController(IBL bl)
            {
            _bl = bl;
            }
        // GET: HomeController1
        public ActionResult Index()
            {
            List<Product> allProd = _bl.ProductsList();
            return View(allProd);
            }
        // GET: HomeController1
        public ActionResult IndexHome()
            {
            List<string> genreList = _bl.ProdGenreList();
            ViewBag.Genre = genreList;
            List<Product> allProd = _bl.ProductsList();
            return View(allProd);
            }


        // GET: HomeController1/Create
        public ActionResult Create()
            {
            return View();
            }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product prod)
            {
            try
                {
                
                    _bl.AddProduct(prod);
                Log.Information("Product created");
                return RedirectToAction(nameof(Index));
                }
            catch (Exception e)
                {
                Log.Information($"{e}");
                return View();
                }
            }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
            {
            Product prodToEdit = _bl.GetOneProduct(id);
            return View(prodToEdit);
            }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product prod)
            {
            try
                {
                _bl.UpdateProduct(prod);
                return RedirectToAction(nameof(Index));
                }
            catch (Exception e)
                {
                Log.Information($"{e}");
                return RedirectToAction(nameof(Index));
                }
            }

        // GET: HomeController1/Delete/5
        public ActionResult Delete()
            {
   
            return View();
            }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
            {
            try
                {
                _bl.RemoveProduct(id);
                Log.Information("Product delted");
                return RedirectToAction(nameof(Index));
                }
            catch
                {
                return View();
                }
            }
        }
    }
