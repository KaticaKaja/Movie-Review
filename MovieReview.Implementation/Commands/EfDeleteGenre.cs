using MovieReview.Application.Commands;
using MovieReview.Application.Exceptions;
using MovieReview.Domain;
using MovieReview.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Implementation.Commands
{
    public class EfDeleteGenre : IDeleteGenre
    {
        private readonly MovieReviewContext context;

        public EfDeleteGenre(MovieReviewContext context)
        {
            this.context = context;
        }
        public int Id => 18;

        public string Name => "Delete Genre";

        public void Execute(int id)
        {
            var genre = context.Genres.Find(id);

            if (genre == null)
            {
                throw new EntityNotFoundException(id, typeof(Genre));
            }

            genre.IsDeleted = true;
            context.SaveChanges();
        }
    }
}
