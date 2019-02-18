using GarlicStore.Models;
using GarlicStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GarlicStore.WebMVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var service = new ProductService();
            var model = service.GetProducts();

            return View(model);
        }

        // GET Create Product
        public ActionResult Create()
        {
            return View();
        }

        //POST: Create Product
        [HttpPost]
        public ActionResult Create(ProductCreate model)
        {
            if (!ModelState.IsValid)
            {
            return View(model);
            }
            var service = new ProductService();

            service.CreateProduct(model);

            return RedirectToAction("Index");
        }

        //GET: Product Details
        public ActionResult Details(int id)
        {
            var service = new ProductService();
            var model = service.GetProductById(id);
            return View(model);
        }

        //GET: Product Edit
        public ActionResult Edit(int id)
        {
            var service = new ProductService();
            var detail = service.GetProductById(id);
            var model =
                new ProductEdit
                {
                    ProductId = detail.ProductId,
                    Price = detail.Price,
                    StockQuantity = detail.StockQuantity
                };
            return View(model);
        }

        //POST: Product Edit
        [HttpPost]
        public ActionResult Edit(int id, ProductEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = new ProductService();

            if (service.EditProduct(model))
            {
                TempData["SaveResult"] = "Your product was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your product could not be updated.");
            return View(model);
        }

        //GET: Product Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = new ProductService();
            var model = service.GetProductById(id);

            return View(model);
        }

        //POST: Product Delete
        [ActionName("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveProduct(int id)
        {
            var service = new ProductService();
            service.DeleteProduct(id);

            TempData["SaveResult"] = "The product has been deleted";

            return RedirectToAction("Index");
        }
    }
}