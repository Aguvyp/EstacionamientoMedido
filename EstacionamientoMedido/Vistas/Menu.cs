using EstacionamientoMedido.Modelos;
using EstacionamientoMedido.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Vistas
{
    public class Menu
    {
        ClienteView clienteView = new ClienteView();
        VehiculoView vehiculoView = new VehiculoView();
        EstacionamientoView estacionamientoView = new EstacionamientoView();
        PlazaEstacionamientoView plazaView = new PlazaEstacionamientoView();
        public void MenuAMostrar()
        {
            int eleccion;
            Console.WriteLine("***************** MENU *****************");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("| 1. Iniciar estacionamiento            |");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("| 2. Finalizar estacionamiento          |");
           Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("| 3. Mostrar estacionamientos           |");
            Console.WriteLine("| 4. Buscar estacionamiento por patente |");
            Console.WriteLine("| --------------------------------------|");
            Console.WriteLine("| 5. Mostrar clientes cargados          |");
            Console.WriteLine("| 6. Buscar cliente por DNI             |");
            Console.WriteLine("| 7. Buscar cliente por Apellido        |");
            Console.WriteLine("| 8. Eliminar cliente                   |");
            Console.WriteLine("| --------------------------------------|");
            Console.WriteLine("| 9. Registrar vehiculo nuevo          |");
            Console.WriteLine("| 10. Mostrar vehiculos registrados     |");
            Console.WriteLine("| 11. Modificar vehiculo                |");
            Console.WriteLine("| 12. Eliminar vehiculo                 |");
            Console.WriteLine("| 13. Buscar vehiculo por patente       |");
            Console.WriteLine("|---------------------------------------|");
            Console.WriteLine("| 14. Cargar plazas                     |");
            Console.WriteLine("| 15. Mostrar plazas cargadas           |");
            Console.WriteLine("|---------------------------------------|");
            Console.WriteLine("| 16. Salir                             |");
            Console.WriteLine("|_______________________________________| ");
            //Console.WriteLine("5. Iniciar estacionamiento");
            //Console.WriteLine("6. Finalizar estacionamiento");
            //Console.WriteLine("7. Cerrar");
            Console.WriteLine();
            Console.Write("Opcion: ");
            eleccion = int.Parse(Console.ReadLine());


            switch (eleccion)
            {
                case 1:
                    estacionamientoView.IniciarEstacionamiento();
                    Console.WriteLine();
                    MenuAMostrar();
                    break;

                case 2:
                    estacionamientoView.FinalizarEstacionamiento();
                    Console.WriteLine();
                    MenuAMostrar();
                    break;

                case 3:
                    estacionamientoView.VerEstacionamientos();
                    Console.WriteLine();
                    MenuAMostrar();
                    break;

                case 4:
                    estacionamientoView.VerEstacionamientosFiltrados();
                    Console.WriteLine();
                    MenuAMostrar();
                    break;


                case 5:
                    clienteView.MostrarClientesRegistrados();
                    Console.WriteLine();
                    MenuAMostrar();
                    break;


                case 6:
                    clienteView.ObtenerClientePorDNI();
                    Console.WriteLine();
                    MenuAMostrar();
                    break;

                case 7:
                    clienteView.ObtenerPorApellido();
                    Console.WriteLine();
                    MenuAMostrar();
                    break;

                case 8:
                    clienteView.EliminarClienteRegistrado();
                    Console.WriteLine();
                    MenuAMostrar();
                    break;

                case 9:
                    vehiculoView.CargarDatosVehiculo();
                    Console.WriteLine();
                    MenuAMostrar();
                    break;

                case 10:
                    vehiculoView.MostrarVehiculosRegistrados();
                    Console.WriteLine();
                    MenuAMostrar();
                    break;

                case 11:
                    vehiculoView.ModificarVehiculo();
                    Console.WriteLine();
                    MenuAMostrar();
                    break;

                case 12:
                    vehiculoView.EliminarVehiculo();
                    Console.WriteLine();
                    MenuAMostrar();
                    break;

                case 13:
                    vehiculoView.BuscarVehiculoPorPatente();
                    Console.WriteLine();
                    MenuAMostrar();
                    break;

                case 14:
                    plazaView.CargarPlazaEstacionamiento();
                    Console.WriteLine();
                    MenuAMostrar();
                    break;

                case 15:
                    plazaView.ObtenerPlazasCargadas();
                    Console.WriteLine();
                    MenuAMostrar();
                    break;

                case 16:
                    Environment.Exit(0);
                    break;

                default:
                    Console.Clear();
                    break;

            }
        }
    }
}

