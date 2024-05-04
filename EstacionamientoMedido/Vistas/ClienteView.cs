using EstacionamientoMedido.Controladores;
using EstacionamientoMedido.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Vistas
{
    public class ClienteView
    {
        ClienteController clienteControlador = new ClienteController();

        public void CargarDatosCliente()
        {
            Cliente clienteNuevo = new Cliente();

            Console.Write("Nombre: ");
            clienteNuevo.Nombre = Console.ReadLine();
            Console.Write("Apellido: ");
            clienteNuevo.Apellido = Console.ReadLine();
            Console.WriteLine("DNI: ");
            clienteNuevo.DNI = Console.ReadLine();
            Console.Write("Telefono: ");
            clienteNuevo.Telefono = Console.ReadLine();
            Console.Write("Email: ");
            clienteNuevo.Email = Console.ReadLine();

            clienteControlador.GuardarCliente(clienteNuevo);
        }

        public void MostrarClientesRegistrados()
        {
            List<Cliente> listadoClientes = new List<Cliente> ();
            Console.WriteLine("Lista de clientes registrados: ");

            foreach (var item in listadoClientes)
            {
                Console.WriteLine($"> Nombre: {item.Nombre} {item.Apellido} - DNI: {item.DNI} - Tel: {item.Telefono} - Email: {item.Email}");
            }

            clienteControlador.ObtenerClientes();
        }
    }
}
