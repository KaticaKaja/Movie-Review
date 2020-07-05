using MovieReview.Application.Commands;
using MovieReview.Application.Exceptions;
using MovieReview.Domain;
using MovieReview.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Implementation.Commands
{
    public class EfDeleteReview : IDeleteReview
    {
        private readonly MovieReviewContext context;

        public EfDeleteReview(MovieReviewContext context)
        {
            this.context = context;
        }
        public int Id => 13;

        public string Name => throw new NotImplementedException();

        public void Execute(int id)
        {
            var review = context.Reviews.Find(id);

            if (review == null)
            {
                throw new EntityNotFoundException(id, typeof(Review));
            }

            review.IsDeleted = true;
            context.SaveChanges();
        }
    }
}
