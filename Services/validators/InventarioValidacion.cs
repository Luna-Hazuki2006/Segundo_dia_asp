using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using FluentValidation;

namespace Services.validators
{
    public class InventarioValidacion : AbstractValidator<Inventario>
    {
        public InventarioValidacion() {
            RuleFor(e => e.Id)
                .NotNull()
                .GreaterThanOrEqualTo(1);
            RuleFor(e => e.Espacio_Disponible);
            RuleFor(e => e.Peso_Total);
            RuleFor(e => e.Objetos);
        }
    }
}