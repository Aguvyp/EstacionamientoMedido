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
        Repositorio repo = new Repositorio();

        public List<PlazaEstacionamiento> ObtenerPlazaEst()
        {
            return repo.PlazasEstacionamiento;
        }

        public ResponseWrapper<PlazaEstacionamiento> PlazaDisponible()
        {
            PlazaEstacionamiento plazaDisponible = repo.PlazasEstacionamiento.Where(x => x.Disponible == true).FirstOrDefault();
            if (plazaDisponible != null)
            {
                return new ResponseWrapper<PlazaEstacionamiento>(plazaDisponible, false);
            }  
            else
            {
                return new ResponseWrapper<PlazaEstacionamiento>(true);
            }
        }
    }
}
