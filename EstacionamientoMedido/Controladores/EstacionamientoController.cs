using EstacionamientoMedido.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Controladores
{
    public class EstacionamientoController
    {  
        Repositorio repo = new Repositorio();

        public void GuardarEstacionamiento(Estacionamiento e)
        {
            repo.Estacionamientos.Add(e);
        }

        public List<Estacionamiento> ObtenerEstacionamiento()
        {
            return repo.Estacionamientos;
        }
    }
}
