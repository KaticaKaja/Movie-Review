using AutoMapper;
using FluentValidation;
using MovieReview.Application.Commands;
using MovieReview.Application.DataTransfer;
using MovieReview.Domain;
using MovieReview.EfDataAccess;
using MovieReview.Implementation.Common;
using MovieReview.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Implementation.Commands
{
    public class EfUpdateUser : IUpdateUser
    {
        private readonly MovieReviewContext context;
        private readonly IMapper mapper;
        private readonly UpdateUserValidator validator;
        public EfUpdateUser(MovieReviewContext context, IMapper mapper, UpdateUserValidator validator)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = validator;
        }
        public int Id => 4;

        public string Name => "Update User";

        public void Execute(UserDto dto)
        {
            var userFromDb = context.Users.Find(dto.Id);

            userFromDb.Password = CommonMethods.ConvertToEncrypt(userFromDb.Password);

            mapper.Map(dto,userFromDb);

            validator.ValidateAndThrow(dto);

            context.SaveChanges();
        }

    }
}
