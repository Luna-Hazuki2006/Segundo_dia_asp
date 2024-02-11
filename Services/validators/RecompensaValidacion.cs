using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using FluentValidation;

namespace Services.validators
{
    public class RecompensaValidacion : AbstractValidator<Recompensa>
    {
        public RecompensaValidacion() {
            RuleFor(x => x.Id).
                NotNull(). 
                GreaterThanOrEqualTo(1);
            RuleFor(x => x.Objetos);
            RuleFor(x => x.Experiencia);
            RuleFor(x => x.Enemigos);
            RuleFor(x => x.Monedas);
        }
    }
}