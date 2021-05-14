using Example.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Validates
{
    public class ValidateJob : AbstractValidator<Job>
    {
        [Obsolete]
        public ValidateJob()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("{Id} should not be empty.");

            RuleFor(p => p.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} should not be empty.")
                .Length(2, 25);
        }

    }
}