using FluentValidation;
using MovieReview.Application.DataTransfer;
using MovieReview.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Implementation.Validators
{
    public class ActorValidator : AbstractValidator<ActorDto>
    {
        public ActorValidator(MovieReviewContext context)
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name is required");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name is required");
        }
    }
}
