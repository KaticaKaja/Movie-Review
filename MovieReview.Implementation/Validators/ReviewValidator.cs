using FluentValidation;
using MovieReview.Application.DataTransfer;
using MovieReview.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Implementation.Validators
{
    public class ReviewValidator : AbstractValidator<ReviewDto>
    {
        public ReviewValidator(MovieReviewContext context)
        {
            RuleFor(x => x.Title)
                .NotEmpty();
            RuleFor(x => x.Text)
                .NotEmpty()
                .MaximumLength(300)
                .WithMessage("Please use up to 300 characters");
            RuleFor(x => x.MovieRating)
                .InclusiveBetween(1, 5)
                .WithMessage("Rate between 1 and 5");
        }
    }
}
