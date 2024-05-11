using EstacionamientoMedido.Controladores;
using EstacionamientoMedido.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Vistas
{
    public class EstacionamientoView
    {
        EstacionamientoController controladorEstacionamiento = new EstacionamientoController();
        VehiculoController controladorVehiculo = new VehiculoController();
        VehiculoView vistaVehiculo = new VehiculoView();
        public void IniciarEstacionamiento()
        {
            Console.WriteLine("Ingrese patente de entrada: ");
            string patente = Console.ReadLine();

            if (!controladorVehiculo.ExistePatente(patente))
            {
                vistaVehiculo.CargarDatosVehiculo();
            }

            controladorEstacionamiento.IniciarEstacionmiento(patente);
            Console.WriteLine("Estacionamiento iniciado con exito");
        }

        public void FinalizarEstacionamiento()
        {
            Console.WriteLine("Ingrese patente de salida: ");
            string patente = Console.ReadLine();

            Estacionamiento finalizado = controladorEstacionamiento.FinalizarEstacionamiento(patente);
            
            Console.WriteLine(" ************ Estacionamiento finalizado con exito ************");
            Console.WriteLine("Datos:");
            Console.WriteLine($"Patente: {finalizado.VehiculoEstacionado.Patente} - Dueño: {finalizado.VehiculoEstacionado.Cliente.Apellido}, {finalizado.VehiculoEstacionado.Cliente.Nombre} " +
                $" - DNI: {finalizado.VehiculoEstacionado.Cliente.DNI}");
            Console.WriteLine($"Hora ingreso: {finalizado.Entrada} - Hora salida: {finalizado.Salida} - Precio por hora: {finalizado.PrecioHora}");
            Console.WriteLine($"Precio total estacionamiento: ${finalizado.TotalEstacionamiento}");

        }
    }
}
