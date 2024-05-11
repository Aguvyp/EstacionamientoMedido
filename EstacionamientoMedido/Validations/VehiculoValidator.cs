using EstacionamientoMedido.Modelos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Validations
{
    public class VehiculoValidator : AbstractValidator<Vehiculo>
    {
        public VehiculoValidator()
        {
            RuleFor(Vehiculo => Vehiculo.Marca)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(20);

            RuleFor(Vehiculo => Vehiculo.Modelo)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(20);

            RuleFor(Vehiculo => Vehiculo.Patente)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(20);

            RuleFor(Vehiculo => Vehiculo.Color)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(20);

            //TODO
            //Implementar el resto de propiedades de vehiculo y el resto de modelos

        }
    }
}
