﻿using Domain.Models;
using FluentValidation;

namespace Domain.Validators
{
    public class TaskCalendarValidator : AbstractValidator<TaskCalendar>
    {
        public TaskCalendarValidator()
        {
            RuleFor(x => x.ClientId)
            .NotNull()
            .WithMessage("ClientId cannot be null");

            RuleFor(x => x.Template)
             .NotNull()
             .WithMessage("Template cannot be null.");


            RuleFor(x => x.Params)
             .NotNull()
             .WithMessage("Params cannot be null.");

            RuleFor(x => x.DateTime)
             .NotNull()
             .WithMessage("DateTime cannot be null.");
        }
    }
}
