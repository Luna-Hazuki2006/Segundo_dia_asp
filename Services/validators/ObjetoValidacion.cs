using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using FluentValidation;

namespace Services.validators
{
    public class ObjetoValidacion : AbstractValidator<Objeto>
    {
        public ObjetoValidacion() {
            RuleFor(e => e.Id)
                .NotNull()
                .GreaterThanOrEqualTo(1);
            RuleFor(e => e.Descripcion);
            RuleFor(e => e.Valor);
            RuleFor(e => e.Tipo);
        }
    }
}