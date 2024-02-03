using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using FluentValidation;

namespace Services.validators
{
    public class EnemigoValidacion : AbstractValidator<Enemigo>
    {
        public EnemigoValidacion() {
            RuleFor(e => e.Id);
            RuleFor(e => e.Nivel_Amenaza);
            RuleFor(e => e.Habilidades);
            RuleFor(e => e.Recompensas);
        }
    }
}