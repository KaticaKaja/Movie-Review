using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieReview.Application.DataTransfer;
using MovieReview.Application.Queries;
using MovieReview.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieReview.Implementation.Queries
{
    public class EfGetOneUserQuery : IGetOneUserQuery
    {
        private readonly MovieReviewContext context;
        private readonly IMapper mapper;

        public EfGetOneUserQuery(MovieReviewContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public int Id => 3;

        public string Name => "Get one user";

        public UserDto Execute(int id)
        {
            var usersFromDb = context.Users.Include(x => x.UserUseCases).AsQueryable();
            var userFromDb = usersFromDb.Where(x => x.Id == id).FirstOrDefault();

            var user =  mapper.Map<UserDto>(userFromDb);

            return user;
        }
    }
}
