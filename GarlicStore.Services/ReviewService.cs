using GarlicStore.Data;
using GarlicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarlicStore.Services
{
    public class ReviewService
    {
        private readonly Guid _userId;

        public ReviewService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateReview(ReviewCreate model)
        {
            var review = new Review
            {
                ProductId = model.ProductId,
                Rating = model.Rating,
                Message = model.Message,
                OwnerId = _userId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Reviews.Add(review);
                if (ctx.SaveChanges() == 1)
                {
                    CalculateRating(review.ProductId);
                    return true;
                }
                return false;
            }
        }

        public IEnumerable<ReviewListItem> GetReviews()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Reviews
                    .Select(r => new ReviewListItem
                    {
                        ReviewId = r.ReviewId,
                        ProductId = r.ProductId,
                        Rating = r.Rating,
                        ProductName = r.Product.ProductName
                    }).ToArray();

                return query;
            }
        }

        public ReviewDetail GetReviewById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Reviews.Single(r => r.ReviewId == id);

                var model = new ReviewDetail
                {
                    ReviewId = entity.ReviewId,
                    ProductId = entity.ProductId,
                    ProductName = entity.Product.ProductName,
                    Message = entity.Message,
                    Rating = entity.Rating
                };

                return model;
            }
        }

        public bool EditReview(ReviewEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Reviews.Single(r => r.ReviewId == model.ReviewId && r.OwnerId == _userId);

                entity.Rating = model.Rating;
                entity.Message = model.Message;
                entity.ProductId = model.ProductId;

                if(ctx.SaveChanges() == 1)
                {
                    CalculateRating(model.ProductId);
                    return true;
                }
                return false;
            }
        }

        public bool DeleteReview(int reviewId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Reviews.Single(r => r.ReviewId == reviewId);

                ctx.Reviews.Remove(entity);

                if(ctx.SaveChanges() == 1)
                {
                    CalculateRating(entity.ProductId);
                    return true;
                }
                return false;
            }
        }

        private bool CalculateRating(int productId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Reviews.Where(r => r.ProductId == productId).ToList();

                float totalRating = 0;
                foreach (var rating in query)
                {
                    totalRating += rating.Rating;
                }
                totalRating /= query.Count;

                var product = ctx.Products.Single(p => p.ProductId == productId);
                product.Rating = totalRating;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
