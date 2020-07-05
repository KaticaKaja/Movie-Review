using MovieReview.Application.Commands;
using MovieReview.Application.Exceptions;
using MovieReview.Domain;
using MovieReview.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Implementation.Commands
{
    public class EfDeleteActor : IDeleteActor
    {
        private readonly MovieReviewContext context;

        public EfDeleteActor(MovieReviewContext context)
        {
            this.context = context;
        }
        public int Id => 21;

        public string Name => "Delete Actor";

        public void Execute(int id)
        {
            var actor = context.Actors.Find(id);

            if (actor == null)
            {
                throw new EntityNotFoundException(id, typeof(Actor));
            }

            actor.IsDeleted = true;
            context.SaveChanges();
        }
    }
}
