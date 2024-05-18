﻿using EstacionamientoMedido.Enumeraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Modelos
{
    public class Estacionamiento
    {
        public DateTime Entrada { get; set; }
        public DateTime Salida { get; set; }
        public PlazaEstacionamiento PlazaEstacionamiento { get; set; }
        public int PrecioHora { get; set; }
        public EnumEstacionamiento Estado { get; set; }
        public Vehiculo VehiculoEstacionado { get; set; }
        public double TotalEstacionamiento { get; set; }


        public Estacionamiento(Vehiculo vehiculo, int preciohora) 
        {
            Estado = EnumEstacionamiento.Activo;
            VehiculoEstacionado = vehiculo;
            Entrada = DateTime.Now;
            PrecioHora = preciohora;
        }
    }
}
