using EstacionamientoMedido.Controladores;
using EstacionamientoMedido.Helpers;
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
        ClienteController clienteController = new ClienteController();

        public void CargarDatosVehiculo()
        {
            Vehiculo vehiculoNuevo = new Vehiculo();

            string dueñoMomentaneo;

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

            List<Cliente>listadoClientes = clienteController.ObtenerClientes();

            foreach (var item in listadoClientes)
            {
                if (item.Nombre == dueñoMomentaneo)
                {
                    vehiculoNuevo.Cliente = item;
                }

            }

            vehiculoControlador.CargarVehiculo(vehiculoNuevo);

        }

        public void MostrarVehiculosRegistrados()
        {
            List<Vehiculo> listadoVehiculos = vehiculoControlador.ObtenerVehiculos();

            Console.WriteLine("Lista de vehiculos registrados");

            foreach (var v in listadoVehiculos)
            {
                Console.WriteLine($">Dueño: {v.Cliente.Nombre} - Patente: {v.Patente} - Marca: {v.Marca} - Modelo: {v.Modelo} - Color: {v.Color}");
            }

        }

        public void MostrarUnVehiculo(Vehiculo v)
        {
            Console.WriteLine("Vehiculo encontrado");
            Console.WriteLine($">Dueño: {v.Cliente.Nombre} - Patente: {v.Patente} - Marca: {v.Marca} - Modelo: {v.Modelo} - Color: {v.Color}");
        }

        public void ModificarVehiculo()
        {
            Vehiculo vehiculoNuevo = new Vehiculo();

            Console.WriteLine("Patente del vehiculo a modificar: ");
            vehiculoNuevo.Patente = Console.ReadLine();
            vehiculoControlador.Modificar(vehiculoNuevo);
            CargarDatosVehiculo();
            Console.WriteLine("Vehiculo modificado con exito");

        }

        public void EliminarVehiculo()
        {
            Vehiculo vehiculoEliminar = new Vehiculo();

            Console.WriteLine("Eliminar vehiculo por patente");
            Console.Write("Patente: ");
            vehiculoEliminar.Patente = Console.ReadLine();
            vehiculoControlador.Eliminar(vehiculoEliminar);
            Console.WriteLine("Vehiculo eliminado con exito");
        }

        public void BuscarVehiculoPorPatente()
        {
            Vehiculo buscado = new Vehiculo();
            Console.WriteLine("Buscar vehiculo por patente");
            Console.Write("Patente: ");
            buscado.Patente = Console.ReadLine();
            ResponseWrapper<Vehiculo> encontrado = vehiculoControlador.ObtenerVehiculoPorPatente(buscado.Patente);
            MostrarUnVehiculo(encontrado.Respuesta);

        }

    }
}
