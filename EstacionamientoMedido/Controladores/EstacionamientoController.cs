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
        PlazaEstController plazaEst = new PlazaEstController();


        private const int PrecioHora = 0;

        public void IniciarEstacionmiento(string patente, PlazaEstacionamiento plazaSelect)
        {
            PlazaEstacionamiento plazaSeleccionada = plazaSelect;
        
            Vehiculo vehiculo = controladorVehiculo.ObtenerVehiculoPorPatente(patente);

            Estacionamiento estacionamiento = new Estacionamiento(vehiculo, PrecioHora, plazaSeleccionada);
           
            repo.Estacionamientos.Add(estacionamiento);
        }

        public PlazaEstacionamiento AsignarPlaza(string plaza)
        {
            Estacionamiento est = new Estacionamiento();
            PlazaEstacionamiento plazaElegida = repo.PlazasEstacionamiento
                .Where(x => x.Nombre == plaza)
                .FirstOrDefault();

            est.PlazaEstacionamiento = plazaElegida;

            return est.PlazaEstacionamiento;
       
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
