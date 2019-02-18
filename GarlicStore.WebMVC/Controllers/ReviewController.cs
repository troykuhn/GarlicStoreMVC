using GarlicStore.Models;
using GarlicStore.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GarlicStore.WebMVC.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Review
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReviewService((userId));
            var model = service.GetReviews();
            return View(model);
        }

        //GET: Review Create
        public ActionResult Create()
        {
            var productService = new ProductService();
            var productList = productService.GetProducts();

            ViewBag.ProductId = new SelectList(productList, "ProductId", "ProductName");

            return View();
        }

        //POST: Review Create
        [HttpPost]
        public ActionResult Create(ReviewCreate model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var service = GetReviewService();

            if(service.CreateReview(model))
            {
                return RedirectToAction("Index");
            }

            var productService = new ProductService();
            var productList = productService.GetProducts();

            ViewBag.ProductId = new SelectList(productList, "ProductId", "ProductName");

            return View(model);
        }

        //GET: Review Details
        public ActionResult Details (int id)
        {
            var service = GetReviewService();
            var model = service.GetReviewById(id);
            return View(model);
        }

        //GET: Review Edit
        public ActionResult Edit (int id)
        {
            var service = GetReviewService();
            var detail = service.GetReviewById(id);
            var model = new ReviewEdit
            {
                ReviewId = detail.ReviewId,
                ProductId = detail.ProductId,
                Rating = detail.Rating,
                Message = detail.Message
            };

            var productService = new ProductService();
            var productList = productService.GetProducts();

            ViewBag.ProductId = new SelectList(productList, "ProductId", "ProductName", model.ProductId);

            return View(model);
        }

        // POST: Review Edit
        [HttpPost]
        public ActionResult Edit(ReviewEdit model)
        {
            var productService = new ProductService();
            var productList = productService.GetProducts();

            ViewBag.ThemeParkID = new SelectList(productList, "ProductId", "ProductName", model.ProductId);

            if (!ModelState.IsValid)
                return View(model);

            var service = GetReviewService();

            if (service.EditReview(model))
                return RedirectToAction("Index");

            ModelState.AddModelError("", "Could not update review");
            return View(model);
        }

        // GET: Review Delete
        public ActionResult Delete(int id)
        {
            var service = GetReviewService();
            var model = service.GetReviewById(id);
            return View(model);
        }

        // POST: Review Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteProductReview(int id)
        {
            var service = GetReviewService();

            if (service.DeleteReview(id))
                return RedirectToAction("Index");

            ModelState.AddModelError("", "Could not delete review");

            return RedirectToAction("Delete", new { id });
        }

        private ReviewService GetReviewService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReviewService(userId);
            return service;
        }
    }
}