using FluentValidation;
using MovieReview.Application.DataTransfer;
using MovieReview.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieReview.Implementation.Validators
{
    public class ReviewValidator : AbstractValidator<ReviewDto>
    {
        public ReviewValidator(MovieReviewContext context)
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title is required");
            RuleFor(x => x.Text)
                .NotEmpty()
                .MaximumLength(300)
                .WithMessage("Please use up to 300 characters");
            RuleFor(x => x.MovieRating)
                .InclusiveBetween(1, 5)
                .WithMessage("Rate between 1 and 5");
            RuleFor(x => x.MovieId)
                .Must(x => context.Movies.Any(m => m.Id == x))
                .WithMessage("No such movie in the database");
        }
    }
}
