﻿using Domain.Models;
using FluentValidation;

namespace Domain.Validators
{
    public class ContactListValidator : AbstractValidator<ContactList>
    {
        public ContactListValidator()
        {
            RuleFor(x => x.Id)
                .Null()
                .WithMessage("{PropertyName} must be null.");

            RuleFor(x => x.IdClient)
                .NotNull()
                .WithMessage("{PropertyName} cannot be null.");

            RuleFor(x => x.ListContact)
                .NotNull()
                .WithMessage("{PropertyName} cannot be null.");

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("{PropertyName} cannot be null.");

            RuleFor(x => x.TipoContato)
               .NotNull()
               .WithMessage("{PropertyName} cannot be null.");

        }
    }
}
