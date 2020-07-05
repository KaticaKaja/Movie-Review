using FluentValidation;
using MovieReview.Application.DataTransfer;
using MovieReview.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Implementation.Validators
{
    public class GenreValidator : AbstractValidator<GenreDto>
    {
        public GenreValidator(MovieReviewContext context){
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Genre name is required");

        }
    }
}
