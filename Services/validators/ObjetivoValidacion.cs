using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using FluentValidation;

namespace Services.validators
{
    public class ObjetivoValidacion : AbstractValidator<Objetivo>
    {
        public ObjetivoValidacion() {
            RuleFor(x => x.Id).
                NotNull(). 
                GreaterThanOrEqualTo(1);
            RuleFor(x => x.Nombre);
            RuleFor(x => x.Descripcion);
            RuleFor(x => x.Hecho);
        }
    }
}