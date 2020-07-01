using AutoMapper;
using FluentValidation;
using MovieReview.Application.Commands;
using MovieReview.Application.DataTransfer;
using MovieReview.Domain;
using MovieReview.EfDataAccess;
using MovieReview.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Implementation.Commands
{
    public class EfAddReview : IAddReview
    {
        private readonly MovieReviewContext context;
        private readonly IMapper mapper;
        private readonly ReviewValidator validator;
        public EfAddReview(MovieReviewContext context, IMapper mapper, ReviewValidator validator)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = validator;
        }
        public int Id => 11;

        public string Name => "Add Review";

        public void Execute(ReviewDto request)
        {
            var review = mapper.Map<Review>(request);

            validator.ValidateAndThrow(request);

            context.Reviews.Add(review);
            context.SaveChanges();
        }
    }
}
