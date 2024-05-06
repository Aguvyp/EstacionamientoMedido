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
        public void MenuAMostrar()
        {
            int eleccion;
            Console.WriteLine("***************** MENU *****************");
            Console.WriteLine("| 1. Cargar cliente                    |");
            Console.WriteLine("| 2. Mostrar clientes cargados         |");
            Console.WriteLine("| 3. Buscar cliente por DNI            |");
            Console.WriteLine("| 4. Buscar cliente por Apellido       |");
            Console.WriteLine("| 5. Eliminar cliente                  |");
            Console.WriteLine("| 6. Registrar vehiculo nuevo          |");
            Console.WriteLine("| 7. Mostrar vehiculos registrados     |");
            Console.WriteLine("| 8. Modificar vehiculo                |");
            Console.WriteLine("| 9. Eliminar vehiculo                 |");
            Console.WriteLine("| 10. Buscar vehiculo por patente      |");
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
                    clienteView.CargarDatosCliente();
                    Console.WriteLine();
                    MenuAMostrar();
                    break;

                case 2:
                    clienteView.MostrarClientesRegistrados();
                    Console.WriteLine();
                    MenuAMostrar();
                    break;


                case 3:
                    clienteView.ObtenerClientePorDNI();
                    Console.WriteLine();
                    MenuAMostrar();
                    break;

                case 4:
                    clienteView.ObtenerPorApellido();
                    Console.WriteLine();
                    MenuAMostrar();
                    break;

                case 5:
                    clienteView.EliminarClienteRegistrado();
                    Console.WriteLine();
                    MenuAMostrar();
                    break;

                case 6:
                    vehiculoView.CargarDatosVehiculo();
                    Console.WriteLine();
                    MenuAMostrar();
                    break;

                case 7:
                    vehiculoView.MostrarVehiculosRegistrados();
                    Console.WriteLine();
                    MenuAMostrar();
                    break;

                case 8:
                    vehiculoView.ModificarVehiculo();
                    Console.WriteLine();
                    MenuAMostrar();
                    break;

                case 9:
                    vehiculoView.EliminarVehiculo();
                    Console.WriteLine();
                    MenuAMostrar();
                    break;

                case 10:
                    vehiculoView.BuscarVehiculoPorPatente();
                    Console.WriteLine();
                    MenuAMostrar();
                    break;

                default:
                    break;

            }
        }
    }
}

