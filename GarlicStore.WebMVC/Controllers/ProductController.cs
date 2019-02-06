using GarlicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GarlicStore.WebMVC.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var model = new ProductListItem[0];
            return View(model);
        }

        // GET Create Product
        public ActionResult Create()
        {
            return View();
        }

        //GET: Create Product Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}