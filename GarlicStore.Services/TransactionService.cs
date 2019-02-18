using GarlicStore.Data;
using GarlicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarlicStore.Services
{
    public class TransactionService
    {
        private readonly Guid _userId;
        public TransactionService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTransaction(TransactionCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var product = ctx.Products.Single(p => p.ProductId == model.ProductId);

                var transaction = new Transaction()
                {
                    OwnerId = _userId,
                    ProductId = product.ProductId,
                    Price = product.Price,
                    Quantity = model.Quantity,

                    DateOfTransaction = DateTimeOffset.Now
                };
                transaction.OrderCost = product.Price * Convert.ToDecimal(model.Quantity);
                ctx.Transactions.Add(transaction);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TransactionListItem> GetTransactions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Transactions
                    .Where(p => p.OwnerId == _userId)
                    .Select(p => new TransactionListItem
                    {
                        TransactionId = p.TransactionId,
                        DateOfTransaction = p.DateOfTransaction,
                        OrderCost = p.OrderCost
                    }
                    );
                return query.ToArray();
            }
        }

        public TransactionDetail GetTransactionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Transactions.FirstOrDefault(p => p.TransactionId == id);
                //var product = ctx.Products.Single(p => p.ProductId == entity.ProductId);

                var model = new TransactionDetail()
                {
                    TransactionId = entity.TransactionId,
                    ProductId = entity.ProductId,
                    ProductName = entity.Product.ProductName,
                    Quantity = entity.Quantity,
                    Price = entity.Price,
                    OrderCost = entity.OrderCost,
                    DateOfTransaction = entity.DateOfTransaction
                };
                return model;
            }
        }

        public bool EditTransaction(TransactionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                //var product = ctx.Products.Single(p => p.ProductId == model.ProductId);
                var entity = ctx.Transactions.FirstOrDefault(p => p.TransactionId == model.TransactionId);

                entity.TransactionId = model.TransactionId;
                entity.ProductId = model.ProductId;
                entity.Quantity = model.Quantity;
                entity.DateOfTransaction = DateTimeOffset.Now;
                entity.OrderCost = Convert.ToDecimal(model.Quantity) * entity.Price;
                

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTransaction(int transactionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Transactions.Single(t => t.TransactionId == transactionId);

                ctx.Transactions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        //private bool CalculateOrderCost(int transactionId)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var query = ctx.Transactions.Where(t => t.TransactionId == transactionId).ToList();

        //        decimal orderCost = 0;
        //        foreach (var transaction in query)
        //        {
        //            orderCost += transaction.OrderCost;
        //        }
        //        orderCost /= query.O
        //    }
        //}
    }
}

