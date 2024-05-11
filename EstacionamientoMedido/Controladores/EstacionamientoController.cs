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

        public void IniciarEstacionmiento(string patente)
        {

            Vehiculo vehiculo = controladorVehiculo.ObtenerVehiculoPorPatente(patente);

            Estacionamiento estacionamiento = new Estacionamiento();
            estacionamiento.Entrada = DateTime.Now;
            estacionamiento.VehiculoEstacionado = vehiculo;

            repo.Estacionamientos.Add(estacionamiento);
        }

        public Estacionamiento FinalizarEstacionamiento(string patente)
        {
            Estacionamiento aSalir = repo.Estacionamientos
                .Where(x => x.VehiculoEstacionado.Patente == patente)
                .OrderBy(x => x.Entrada)
                .Single();

            repo.Estacionamientos.Remove(aSalir);
            aSalir.Salida = DateTime.Now;
            
            TimeSpan diferenciaTiempo = aSalir.Salida - aSalir.Entrada;
            double horas = diferenciaTiempo.TotalHours;

            if (horas < 1) 
            {
                aSalir.TotalEstacionamiento = aSalir.PrecioHora;
            }
            else
            {
                aSalir.TotalEstacionamiento = horas * aSalir.PrecioHora;
            }

            repo.Estacionamientos.Add(aSalir);
       
            return aSalir;
        }
    }
}
