using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using FluentValidation;
using FluentValidation.Validators;

namespace Services.validators
{
    public class UsuarioValidacion : AbstractValidator<Usuario>
    {
        public UsuarioValidacion() {
            RuleFor(x => x.Cedula).NotEmpty();
            RuleFor(x => x.Nacimiento).NotEmpty();
            RuleFor(x => x.Apellidos).NotEmpty();
            RuleFor(x => x.Correo).NotEmpty()
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible);
        }
    }
}