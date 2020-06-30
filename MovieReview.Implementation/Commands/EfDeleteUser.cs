using MovieReview.Application.Commands;
using MovieReview.Application.Exceptions;
using MovieReview.Domain;
using MovieReview.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Implementation.Commands
{
    public class EfDeleteUser : IDeleteUser
    {
        private readonly MovieReviewContext context;

        public EfDeleteUser(MovieReviewContext context)
        {
            this.context = context;
        }

        public int Id => 5;

        public string Name => "Delete User";

        public void Execute(int id)
        {
            var user = context.Users.Find(id);

            if (user == null)
            {
                throw new EntityNotFoundException(id, typeof(User));
            }

            context.Users.Remove(user);

            context.SaveChanges();
        }
    }
}
