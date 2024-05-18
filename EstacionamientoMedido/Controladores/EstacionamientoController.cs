using EstacionamientoMedido.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace EstacionamientoMedido.Controladores
{
    
    public class EstacionamientoController
    {  
        Repositorio repo = Repositorio.GetInstance();
        VehiculoController controladorVehiculo = new VehiculoController();
        private const int PrecioHora = 0;

        public void IniciarEstacionmiento(string patente)
        {

            Vehiculo vehiculo = controladorVehiculo.ObtenerVehiculoPorPatente(patente);

            Estacionamiento estacionamiento = new Estacionamiento(vehiculo, PrecioHora);

            repo.Estacionamientos.Add(estacionamiento);
        }

        public Estacionamiento FinalizarEstacionamiento(string patente)
        {
            Estacionamiento aSalir = repo.Estacionamientos
                .Where(x => x.VehiculoEstacionado.Patente == patente)
                .OrderBy(x => x.Entrada)
                .Single();

            repo.Estacionamientos.Remove(aSalir);
            aSalir.SalidaEstacionamiento();
            repo.Estacionamientos.Add(aSalir);
       
            return aSalir;
        }

        public List<Estacionamiento> ObtenerEstacionamientos()
        {
            return repo.Estacionamientos;
        }

        public List<Estacionamiento>ObtenerEstacionamientosPorPatente(string patente)
        {
            List<Estacionamiento> listaEstacionamientos = repo.Estacionamientos
                .Where(x => x.VehiculoEstacionado.Patente == patente)
                .ToList();

            return listaEstacionamientos;
        }

        public bool YaEstaEstacionado(string patente)
        {
            bool resultado;

            resultado = repo.Estacionamientos
                .Where(x => x.VehiculoEstacionado.Patente == patente)
                .Where(x => x.Estado == Enumeraciones.EnumEstacionamiento.Activo)
                .Any();

            return resultado;
        }
    }
}
