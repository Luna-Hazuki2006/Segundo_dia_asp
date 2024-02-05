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
            RuleFor(e => e.Id)
                .NotNull()
                .GreaterThanOrEqualTo(1);
            RuleFor(e => e.Nombre)
                .NotEmpty()
                .MaximumLength(255);
            RuleFor(e => e.Nivel)
                .LessThanOrEqualTo(99)
                .GreaterThanOrEqualTo(Personaje => Personaje.Nivel);
            RuleFor(e => e.Salud)
                .LessThanOrEqualTo(100)
                .GreaterThanOrEqualTo(Personaje => Personaje.Salud);
            RuleFor(e => e.Energia)
                .LessThanOrEqualTo(100)
                .GreaterThanOrEqualTo(Personaje => Personaje.Energia);
            RuleFor(e => e.Fuerza)
                .LessThanOrEqualTo(100)
                .GreaterThanOrEqualTo(Personaje => Personaje.Fuerza);
            RuleFor(e => e.Inteligencia)
                .LessThanOrEqualTo(100)
                .GreaterThanOrEqualTo(Personaje => Personaje.Inteligencia);
            RuleFor(e => e.Agilidad)
                .LessThanOrEqualTo(100)
                .GreaterThanOrEqualTo(Personaje => Personaje.Agilidad);
            RuleFor(e => e.Inventario)
                .NotNull();
        }
    }
}