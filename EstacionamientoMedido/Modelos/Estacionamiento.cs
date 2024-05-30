using EstacionamientoMedido.Controladores;
using EstacionamientoMedido.Enumeraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Modelos
{
    public class Estacionamiento
    {
        public DateTime Entrada { get; private set; }
        public DateTime Salida { get; private set; }
        public PlazaEstacionamiento PlazaEstacionamiento { get; set; }
        public int PrecioHora { get; private set; }
        public EnumEstacionamiento Estado { get; private set; }
        public Vehiculo VehiculoEstacionado { get; private set; }
        public double TotalEstacionamiento { get; private set; }

        public Estacionamiento()
        {
            
        }
        
        public Estacionamiento(Vehiculo vehiculo, int preciohora, PlazaEstacionamiento plazaSelect) 
        {
            PlazaEstacionamiento = plazaSelect;
            Estado = EnumEstacionamiento.Activo;
            VehiculoEstacionado = vehiculo;
            Entrada = DateTime.Now;
            PrecioHora = preciohora;
        }

        public void SalidaEstacionamiento()
        {
            Estado = EnumEstacionamiento.Terminado;

            Salida = DateTime.Now;


            TimeSpan diferenciaTiempo = Salida - Entrada;
            double horas = diferenciaTiempo.TotalHours;

            if (horas < 1)
            {
                TotalEstacionamiento = PrecioHora;
            }
            else
            {
                TotalEstacionamiento = horas * PrecioHora;
            }

            
        }

        
    }
}
