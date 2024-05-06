using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstacionamientoMedido.Helpers;
using EstacionamientoMedido.Modelos;

namespace EstacionamientoMedido.Controladores
{
    public class VehiculoController
    {
        Repositorio repo = new Repositorio();

        public void CargarVehiculo(Vehiculo v)
        {
            repo.Vehiculos.Add(v);
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
            repo.Vehiculos.Add(v);

            return v;
        }

        public void Eliminar(Vehiculo v)
        {
            Vehiculo vehiculoDelete = repo.Vehiculos
                .Where(x => x.Patente == v.Patente)
                .SingleOrDefault();

            repo.Vehiculos.Remove(vehiculoDelete);
        }

        public ResponseWrapper<Vehiculo> ObtenerVehiculoPorPatente(string patente)
        {
            Vehiculo vNuevo = new Vehiculo();
            Vehiculo vehiculoABuscar = repo.Vehiculos
                .Where(x=> x.Patente ==  patente)
                .SingleOrDefault();

            if(vehiculoABuscar == null || patente == "")
            {
                Console.WriteLine("No hay vehiculo con esa patente, ingreselo");
                Vehiculo aIngresar = new Vehiculo();
                CargarVehiculo(aIngresar);

                return new ResponseWrapper<Vehiculo>(aIngresar, false);
            }
            else
            {
                return new ResponseWrapper<Vehiculo>(vehiculoABuscar, false);
            }
        }
            

    }
}
