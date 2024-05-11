using EstacionamientoMedido.Modelos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Validations
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(Cliente => Cliente.DNI)
                .NotNull()
                .NotEmpty()
                .Length(8);

            RuleFor(Cliente => Cliente.Nombre)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(20);

            RuleFor(Cliente => Cliente.Apellido)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(20);

            RuleFor(Cliente => Cliente.Email)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50)
                .EmailAddress();

            RuleFor(Cliente => Cliente.Telefono)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(20);
        }

    }
}
