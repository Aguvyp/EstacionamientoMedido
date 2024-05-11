using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstacionamientoMedido.Helpers;
using EstacionamientoMedido.Modelos;
using EstacionamientoMedido.Validations;
using FluentValidation.Results;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace EstacionamientoMedido.Controladores
{
    public class VehiculoController
    {
        Repositorio repo = Repositorio.GetInstance();

        public void CargarVehiculo(Vehiculo v)
        {
            VehiculoValidator validator = new VehiculoValidator();
            ValidationResult result = validator.Validate(v);

            if (result.IsValid)
            {
                repo.Vehiculos.Add(v);
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    Console.WriteLine(item.ErrorMessage);
                }
            }
            
        }

        public List<Vehiculo> ObtenerVehiculos()
        {

            return repo.Vehiculos;
        }

        public Vehiculo Modificar(Vehiculo v)
        {
            Vehiculo vehiculoDelete = repo.Vehiculos
                .Where(x=>x.Patente == v.Patente)
                .SingleOrDefault();

            repo.Vehiculos.Remove(vehiculoDelete);

            VehiculoValidator validator = new VehiculoValidator();
            ValidationResult result = validator.Validate(v);
            if (result.IsValid) 
            {
                repo.Vehiculos.Add(v);
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    Console.WriteLine(item.ErrorMessage);
                }
            }


            return v;
        }

        public void Eliminar(Vehiculo v)
        {
            Vehiculo vehiculoDelete = repo.Vehiculos
                .Where(x => x.Patente == v.Patente)
                .SingleOrDefault();

            repo.Vehiculos.Remove(vehiculoDelete);
        }

        public Vehiculo ObtenerVehiculoPorPatente(string patente)
        {
            Vehiculo vehiculoABuscar = repo.Vehiculos
                .Where(x=> x.Patente ==  patente)
                .SingleOrDefault();

            return vehiculoABuscar;
        }

        public bool ExistePatente(string patente)
        {
            bool resultado;
            resultado = repo.Vehiculos.Any(x => x.Patente == patente);
            return resultado;
        }
    }
}
