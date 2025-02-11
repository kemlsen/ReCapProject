﻿using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.LastName).NotEmpty();
            RuleFor(p => p.Password).NotEmpty();
            RuleFor(p => p.Email).NotEmpty();
            RuleFor(p => p.FirstName).MinimumLength(3);
            RuleFor(p => p.LastName).MinimumLength(3);
            RuleFor(p => p.Email).EmailAddress().WithMessage("Geçerli mail adresi giriniz");
            RuleFor(p => p.Password).MinimumLength(6);

        }
    }
}
