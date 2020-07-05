using FluentValidation;
using MovieReview.Application.DataTransfer;
using MovieReview.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MovieReview.Implementation.Validators
{
    public class MovieValidator : AbstractValidator<MovieDto>
    {
        public MovieValidator(MovieReviewContext context)
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title is required");
            RuleFor(x => x.Duration)
                .GreaterThan(0)
                .WithMessage("Duration must be longer than 0 minutes");
            RuleFor(x => x.Year)
                .GreaterThan(1887)
                .WithMessage("First movie was filmed in 1888, not before that");
        }
    }
}
