﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Modelos
{
    public class PlazaEstacionamiento
    {
        public string Nombre { get; set; }
        public bool Disponible { get; set; }

        public PlazaEstacionamiento()
        {
            Disponible = true;
        }

    }
}
