using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using FluentValidation;

namespace Services.validators
{
    public class PersonajeValidacion : AbstractValidator<Personaje>
    {
        public PersonajeValidacion() {
            RuleFor(e => e.Nombre)
                .NotEmpty()
                .MaximumLength(255);
            RuleFor(e => e.Nivel)
                .LessThanOrEqualTo(100)
                .GreaterThanOrEqualTo(Personaje => Personaje.Nivel);
            
        }
    }
}