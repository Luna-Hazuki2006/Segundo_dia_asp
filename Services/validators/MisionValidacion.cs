using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using FluentValidation;

namespace Services.validators
{
    public class MisionValidacion : AbstractValidator<Mision>
    {
        public MisionValidacion() {
            RuleFor(e => e.Id)
                .NotNull()
                .GreaterThanOrEqualTo(1);
            RuleFor(e => e.Recompensas);
            RuleFor(e => e.Objetivos);
            RuleFor(e => e.Estado);
        }
    }
}