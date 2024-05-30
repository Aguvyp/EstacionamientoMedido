using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using EstacionamientoMedido.Helpers;
using EstacionamientoMedido.Modelos;

namespace EstacionamientoMedido.Controladores
{
    public class PlazaEstController
    {
        Repositorio repo = Repositorio.GetInstance();

        public void CargarPlaza(PlazaEstacionamiento plazaNueva)
        {
           repo.PlazasEstacionamiento.Add(plazaNueva);
        }
        public List<PlazaEstacionamiento> ObtenerPlazaEst()
        {
            return repo.PlazasEstacionamiento;
        }

        public List<PlazaEstacionamiento> PlazasDisponibles()
        {
            List<PlazaEstacionamiento> plazasDisponibles = repo.PlazasEstacionamiento
                .Where(x => x.Disponible == true)
                .ToList();

            return plazasDisponibles;
        }
    }
}
