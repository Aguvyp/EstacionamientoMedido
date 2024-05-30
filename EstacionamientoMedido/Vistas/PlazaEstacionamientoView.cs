using EstacionamientoMedido.Controladores;
using EstacionamientoMedido.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Vistas
{
    public class PlazaEstacionamientoView
    {
        PlazaEstController plazaEstController = new PlazaEstController();

        public void CargarPlazaEstacionamiento()
        {
            List<PlazaEstacionamiento> listaPlazas = new List<PlazaEstacionamiento>();
            int totalPlazas;
            Console.Write("Cantidad de plazas totales:");
            totalPlazas = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < totalPlazas; i++)
            {
                PlazaEstacionamiento plazaNueva = new PlazaEstacionamiento();
                Console.Write("Nombre plaza: ");
                plazaNueva.Nombre = Console.ReadLine();
                plazaEstController.CargarPlaza(plazaNueva);
                
            }
        }

        public void ObtenerPlazasCargadas()
        {
            List<PlazaEstacionamiento> listaPlazas = plazaEstController.ObtenerPlazaEst();

            Console.WriteLine("Plazas totales cargadas");
            foreach(var item in listaPlazas)
            {
                Console.WriteLine($"> {item.Nombre}");
            }
            
        }
    }
}
