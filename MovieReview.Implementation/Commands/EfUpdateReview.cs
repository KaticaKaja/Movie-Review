using AutoMapper;
using FluentValidation;
using MovieReview.Application.Commands;
using MovieReview.Application.DataTransfer;
using MovieReview.EfDataAccess;
using MovieReview.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Implementation.Commands
{
   
    public class EfUpdateReview : IUpdateReview
    {
        private readonly MovieReviewContext context;
        private readonly IMapper mapper;
        private readonly ReviewValidator validator;
        public EfUpdateReview(MovieReviewContext context, IMapper mapper, ReviewValidator validator)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = validator;
        }
        public int Id => 12;

        public string Name => "Update Review";

        public void Execute(ReviewDto request)
        {
            var reviewFromDb = context.Reviews.Find(request.Id);

            mapper.Map(request, reviewFromDb);

            validator.ValidateAndThrow(request);

            context.SaveChanges();
        }
    }
    }
}
