using FluentValidation;
using MovieReview.Application.DataTransfer;
using MovieReview.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieReview.Implementation.Validators
{
    public class UpdateUserValidator : AbstractValidator<UserDto>
    {
        public UpdateUserValidator(MovieReviewContext context)
        {
            RuleFor(x => x.FirstName)
                .NotEmpty();
            RuleFor(x => x.LastName)
                .NotEmpty();
            RuleFor(x => x.Username)
                .NotEmpty()
                .MinimumLength(4)
                .Must((dto, username) => !context.Users.Any(user => user.Username == username && user.Id != dto.Id))
                .WithMessage("Username is already taken.");
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .Must((dto, email) => !context.Users.Any(user => user.Email == email && user.Id != dto.Id))
                .WithMessage("This email is already taken.");
            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8);
        }
    }
}
