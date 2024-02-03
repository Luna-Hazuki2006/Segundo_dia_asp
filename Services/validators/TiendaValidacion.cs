using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using FluentValidation;

namespace Services.validators
{
    public class TiendaValidacion : AbstractValidator<Tienda>
    {
        public TiendaValidacion() {
            RuleFor(e => e.Id);
            RuleFor(e => e.Inventario_Tienda);
            RuleFor(e => e.Dinero_Tienda);
            RuleFor(e => e.Stock);
        }
    }
}