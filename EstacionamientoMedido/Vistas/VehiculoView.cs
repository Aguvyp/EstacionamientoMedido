using EstacionamientoMedido.Controladores;
using EstacionamientoMedido.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Vistas
{
    public class VehiculoView
    {
        VehiculoController vehiculoControlador = new VehiculoController();

        public void CargarDatosVehiculo()
        {
            List<Cliente> listadoClientes = new List<Cliente>();

            string dueñoMomentaneo;
            Vehiculo vehiculoNuevo = new Vehiculo();

            Console.Write("Patente: ");
            vehiculoNuevo.Patente = Console.ReadLine();
            Console.Write("Marca: ");
            vehiculoNuevo.Marca = Console.ReadLine();
            Console.Write("Modelo: ");
            vehiculoNuevo.Modelo = Console.ReadLine();
            Console.Write("Color: ");
            vehiculoNuevo.Color = Console.ReadLine();
            Console.Write("Pertenece a: ");
            dueñoMomentaneo = Console.ReadLine();

            foreach (var item in listadoClientes)
            {
                if (dueñoMomentaneo == item.Nombre)
                {
                    vehiculoNuevo.Cliente = item;
                }

            }

            vehiculoControlador.CargarVehiculo(vehiculoNuevo);

        }

        void MostrarVehiculosRegistrados()
        {
            List<Vehiculo> listadoVehiculos = new List<Vehiculo>();

            Console.WriteLine("Lista de vehiculos registrados");


            foreach (var item in listadoVehiculos)
            {
                if (item.Cliente.Nombre != null)
                {
                    Console.WriteLine($">Dueño: {item.Cliente.Nombre} - Patente: {item.Patente} - Marca: {item.Marca} - Modelo: {item.Modelo} - Color: {item.Color}");
                }

            }

            vehiculoControlador.ObtenerVehiculos();

        }

    }
}
