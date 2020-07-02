using FluentValidation;
using MovieReview.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Implementation.Validators
{
    public class TokenValidator : AbstractValidator<LoginRequestDto>
    {
        public TokenValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty();
            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8);
        }
    }
}
