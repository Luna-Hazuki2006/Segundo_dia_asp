using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using FluentValidation;

namespace Services.validators
{
    public class Tipo_PersonajeValidacion : AbstractValidator<Tipo_Personaje>
    {
        public Tipo_PersonajeValidacion() {
            RuleFor(x => x.Id).
                NotNull(). 
                GreaterThanOrEqualTo(1);
            RuleFor(x => x.Nombre).NotEmpty();
            RuleFor(x => x.Descripcion);
        }
    }
}