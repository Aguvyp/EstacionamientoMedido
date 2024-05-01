using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstacionamientoMedido.Modelos;

namespace EstacionamientoMedido.Controladores
{
    public class PlazaEstController
    {
        Repositorio repo = new Repositorio();

        void CargarPlazaEst(PlazaEstacionamiento pe)
        {
            repo.PlazasEstacionamiento.Add(pe);
        }

        public List<PlazaEstacionamiento> ObtenerPlazaEst(PlazaEstacionamiento pe)
        {
            return repo.PlazasEstacionamiento;
        }
    }
}
