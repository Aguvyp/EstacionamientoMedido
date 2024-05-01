using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
