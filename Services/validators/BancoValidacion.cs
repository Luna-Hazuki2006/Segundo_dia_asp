using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using FluentValidation;

namespace Services.validators
{
    public class BancoValidacion : AbstractValidator<Banco>
    {
        public BancoValidacion() {
            RuleFor(e => e.Id);
            RuleFor(e => e.Cuenta_Bacaria);
            RuleFor(e => e.Seguridad);
            RuleFor(e => e.Intereses);
        }
    }
}