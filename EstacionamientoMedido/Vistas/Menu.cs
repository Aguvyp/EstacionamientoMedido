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
        public void MenuAMostrar()
        {
            int eleccion;
            Console.WriteLine("***************** MENU *****************");
            Console.WriteLine("| 1. Iniciar estacionamiento           |");
            Console.WriteLine("| 2. Finalizar estacionamiento         |");
            Console.WriteLine("| ------------------------------------ |");
            Console.WriteLine("| 3. Cargar cliente                    |");
            Console.WriteLine("| 4. Mostrar clientes cargados         |");
            Console.WriteLine("| 5. Buscar cliente por DNI            |");
            Console.WriteLine("| 6. Buscar cliente por Apellido       |");
            Console.WriteLine("| 7. Eliminar cliente                  |");
            Console.WriteLine("| ------------------------------------ |");
            Console.WriteLine("| 8. Registrar vehiculo nuevo          |");
            Console.WriteLine("| 9. Mostrar vehiculos registrados     |");
            Console.WriteLine("| 10. Modificar vehiculo               |");
            Console.WriteLine("| 11. Eliminar vehiculo                |");
            Console.WriteLine("| 12. Buscar vehiculo por patente      |");
            Console.WriteLine("|______________________________________| ");
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
                    clienteView.CargarDatosCliente();
                    Console.WriteLine();
                    MenuAMostrar();
                    break;

                case 4:
                    clienteView.MostrarClientesRegistrados();
                    Console.WriteLine();
                    MenuAMostrar();
                    break;


                case 5:
                    clienteView.ObtenerClientePorDNI();
                    Console.WriteLine();
                    MenuAMostrar();
                    break;

                case 6:
                    clienteView.ObtenerPorApellido();
                    Console.WriteLine();
                    MenuAMostrar();
                    break;

                case 7:
                    clienteView.EliminarClienteRegistrado();
                    Console.WriteLine();
                    MenuAMostrar();
                    break;

                case 8:
                    vehiculoView.CargarDatosVehiculo();
                    Console.WriteLine();
                    MenuAMostrar();
                    break;

                case 9:
                    vehiculoView.MostrarVehiculosRegistrados();
                    Console.WriteLine();
                    MenuAMostrar();
                    break;

                case 10:
                    vehiculoView.ModificarVehiculo();
                    Console.WriteLine();
                    MenuAMostrar();
                    break;

                case 11:
                    vehiculoView.EliminarVehiculo();
                    Console.WriteLine();
                    MenuAMostrar();
                    break;

                case 12:
                    vehiculoView.BuscarVehiculoPorPatente();
                    Console.WriteLine();
                    MenuAMostrar();
                    break;

                case 13:
                    Environment.Exit(0);
                    break;

                default:
                    Console.Clear();
                    break;

            }
        }
    }
}

