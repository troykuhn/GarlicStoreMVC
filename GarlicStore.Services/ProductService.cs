using GarlicStore.Data;
using GarlicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarlicStore.Services
{
    public class ProductService
    {
        public bool CreateProduct(ProductCreate model)
        {
            var entity =
                new Product()
                {
                    ProductId = model.ProductId,
                    ProductName = model.ProductName,
                    StockQuantity = model.StockQuantity,
                    Price = model.Price
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Products.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ProductListItem> GetProducts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Products
                        .Select(
                            e =>
                                new ProductListItem
                                {
                                    ProductId = e.ProductId,
                                    ProductName = e.ProductName,
                                    StockQuantity = e.StockQuantity,
                                    Rating = e.Rating
                                }
                        );

                return query.ToArray();
            }
        }

        public ProductDetail GetProductById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Products.FirstOrDefault(p => p.ProductId == id);

                var model = new ProductDetail
                {
                    ProductId = entity.ProductId,
                    ProductName = entity.ProductName,
                    StockQuantity = entity.StockQuantity,
                    Price = entity.Price,
                    Rating = entity.Rating
                };
                return model;
            }
        }

        public bool EditProduct(ProductEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Products.FirstOrDefault(p => p.ProductId == model.ProductId);

                entity.StockQuantity = model.StockQuantity;
                entity.Price = model.Price;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteProduct(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Products.Single(p => p.ProductId == id);

                ctx.Products.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
