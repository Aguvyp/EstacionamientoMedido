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
        public void MenuAMostrar()
        {
            int eleccion;
            Console.WriteLine("1. Cargar cliente");
            Console.WriteLine("2. Mostrar clientes cargados");
            Console.WriteLine("3. Registrar vehiculo nuevo");
            Console.WriteLine("4. Mostrar vehiculos registrados");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("5. Iniciar estacionamiento");
            Console.WriteLine("6. Finalizar estacionamiento");
            Console.WriteLine("7. Cerrar");
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
                    Vehiculo vehiculoTemporal = CargarDatosVehiculo(repo.Clientes);
                    vehiculoControlador.CargarVehiculo(vehiculoTemporal);
                    Console.WriteLine();
                    MenuAMostrar();
                    break;

                case 4:
                    MostrarVehiculosRegistrados(vehiculoControlador.ObtenerVehiculos());
                    Console.WriteLine();
                    MenuAMostrar();
                    break;

                case 5:
                    List<Vehiculo> vehiculosCargados = vehiculoControlador.ObtenerVehiculos();
                    Estacionamiento estacionamientoTemporal = IniciarEstacionamiento(vehiculosCargados, repo.PlazasEstacionamiento);
                    estacionamientoController.GuardarEstacionamiento(estacionamientoTemporal);
                    // Console.WriteLine($"Plaza: {estacionamientoTemporal.PlazaEstacionamiento.Nombre} | Patente: {estacionamientoTemporal.VehiculoEstacionado.Patente} | Dueño: {estacionamientoTemporal.VehiculoEstacionado.Cliente.Apellido}, {estacionamientoTemporal.VehiculoEstacionado.Cliente.Nombre} | Telefono: {estacionamientoTemporal.VehiculoEstacionado.Cliente.Telefono} \n" +
                    //$"Marca: {estacionamientoTemporal.VehiculoEstacionado.Marca} | Modelo: {estacionamientoTemporal.VehiculoEstacionado.Modelo} | Color: {estacionamientoTemporal.VehiculoEstacionado.Color}");
                    Console.WriteLine();
                    MenuAMostrar();
                    break;

                case 6:
                    List<Estacionamiento> estacionamientosIniciados = estacionamientoController.ObtenerEstacionamiento();
                    FinalizarEstacionamiento(estacionamientosIniciados);
                    Console.WriteLine();
                    MenuAMostrar();
                    break;


                default:
                    break;

            }
        }
}
