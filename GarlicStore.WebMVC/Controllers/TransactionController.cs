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

    public class TransactionController : Controller
    {
        // GET: Transaction
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TransactionService((userId));
            var model = service.GetTransactions();
            return View(model);
        }

        //GET: Create Transaction
        public ActionResult Create()
        {
            var transactionService = new ProductService();
            var transactionList = transactionService.GetProducts();

            ViewBag.ProductId = new SelectList(transactionList, "ProductId", "ProductName");
            return View();
        }

        //POST: Create Transaction
        [HttpPost]
        public ActionResult Create(TransactionCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = GetTransactionService();

            if (service.CreateTransaction(model))
            {
                TempData["SaveResult"] = "Your transaction has been submitted.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Transaction could not be created.");

            var transactionService = new ProductService();
            var transactionList = transactionService.GetProducts();

            ViewBag.ProductId = new SelectList(transactionList, "ProductId", "ProductName");
            return View(model);
        }

        ////GET: Transaction Details
        public ActionResult Details(int id)
        {
            var service = GetTransactionService();
            var model = service.GetTransactionById(id);
            return View(model);
        }


        //GET: Transaction Edit
        public ActionResult Edit(int id)
        {
            var service = GetTransactionService();
            var detail = service.GetTransactionById(id);
            var model =
                new TransactionEdit
                {
                    ProductId = detail.ProductId,
                    TransactionId = detail.TransactionId,
                    Quantity = detail.Quantity,
                    UpdatedTransactionTime = detail.DateOfTransaction
                };

            var transactionService = new ProductService();
            var transactionList = transactionService.GetProducts();

            ViewBag.ProductId = new SelectList(transactionList, "ProductId", "ProductName");
            return View(model);
        }

        //POST: Transaction Edit
        [HttpPost]
        public ActionResult Edit(int id, TransactionEdit model)
        {
            var transactionService = new ProductService();
            var transactionList = transactionService.GetProducts();

            ViewBag.ProductId = new SelectList(transactionList, "ProductId", "ProductName");

            if (!ModelState.IsValid)
                return View(model);

            var service = GetTransactionService();

            if (service.EditTransaction(model))
            {
                TempData["SaveResult"] = "Your transaction was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your transaction could not be updated.");
            return View(model);
        }

        //GET: Transaction Delete
        public ActionResult Delete(int id)
        {
            var service = GetTransactionService();
            var model = service.GetTransactionById(id);
            return View(model);
        }

        //POST: Transaction Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteTransaction(int id)
        {
            var service = GetTransactionService();
            if (service.DeleteTransaction(id))
                return RedirectToAction("Index");

            ModelState.AddModelError("", "Could not delete Transaction");

            return RedirectToAction("Delete", new { id });
        }

        private TransactionService GetTransactionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TransactionService((userId));
            return service;
        }
    }
}