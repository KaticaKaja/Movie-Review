using FluentValidation;
using MovieReview.Application.DataTransfer;
using MovieReview.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieReview.Implementation.Validators
{
    public class AddUserValidator : AbstractValidator<UserDto>
    {
        public AddUserValidator(MovieReviewContext context)
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name is required");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name is required");
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Username is required")
                .MinimumLength(4)
                .WithMessage("Username must be at least 4 characters long")
                .Must(x => !context.Users.Any(user => user.Username == x))
                .WithMessage("Username is already taken.");
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .Must(x => !context.Users.Any(user => user.Email == x))
                .WithMessage("This email is already taken.");
            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8);
        }
    }
}
