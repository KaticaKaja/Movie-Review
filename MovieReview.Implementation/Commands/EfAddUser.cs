using AutoMapper;
using FluentValidation;
using MovieReview.Application.CommandDto;
using MovieReview.Application.Commands;
using MovieReview.Domain;
using MovieReview.EfDataAccess;
using MovieReview.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieReview.Implementation.Commands
{
    public class EfAddUser : IAddUser
    {
        private readonly MovieReviewContext context;
        private readonly IMapper mapper;
        private readonly AddUserValidator validator;
        public EfAddUser(MovieReviewContext context, IMapper mapper, AddUserValidator validator)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = validator;
        }

        public int Id => 1;

        public string Name => "Add User using Ef";

        public void Execute(UserDto request)
        {
            var user = mapper.Map<User>(request);

            validator.ValidateAndThrow(request);

            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
