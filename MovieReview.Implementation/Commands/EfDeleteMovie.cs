using MovieReview.Application.Commands;
using MovieReview.Application.Exceptions;
using MovieReview.Domain;
using MovieReview.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Implementation.Commands
{
    public class EfDeleteMovie : IDeleteMovie
    {
        private readonly MovieReviewContext context;

        public EfDeleteMovie(MovieReviewContext context)
        {
            this.context = context;
        }
        public int Id => 10;

        public string Name => "Delete Movie";

        public void Execute(int id)
        {
            var movie = context.Movies.Find(id);

            if (movie == null)
            {
                throw new EntityNotFoundException(id, typeof(Movie));
            }

            //context.Users.Remove(user);
            movie.IsDeleted = true;
            context.SaveChanges();
        }
    }
}
