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
            Console.Write("DNI: ");
            clienteNuevo.DNI = Console.ReadLine();
            Console.Write("Telefono: ");
            clienteNuevo.Telefono = Console.ReadLine();
            Console.Write("Email: ");
            clienteNuevo.Email = Console.ReadLine();

            clienteControlador.GuardarCliente(clienteNuevo);
        }

        public void MostrarClientesRegistrados()
        {
            
            List<Cliente> listadoClientes = clienteControlador.ObtenerClientes();
            Console.WriteLine("Lista de clientes registrados: ");

            foreach (var item in listadoClientes)
            {
                Console.WriteLine($"> Nombre: {item.Nombre} {item.Apellido} - DNI: {item.DNI} - Tel: {item.Telefono} - Email: {item.Email}");
            }

        }

        public void MostrarUnCliente(Cliente c)
        {
            Console.WriteLine("Resultado");
            Console.WriteLine($"> Nombre: {c.Nombre} {c.Apellido} - DNI: {c.DNI} - Tel: {c.Telefono} - Email: {c.Email}");
        }

        public void ModificarClienteRegistrado()
        {
            Cliente Nuevo = new Cliente();

            Console.WriteLine("DNI del cliente a modificar: ");
            Nuevo.DNI = Console.ReadLine();
            clienteControlador.Modificar(Nuevo);
            CargarDatosCliente();
            Console.WriteLine("Cliente modificado con exito");

        }

        public void EliminarClienteRegistrado()
        {
            Cliente AEliminar = new Cliente();
            Console.WriteLine("Eliminar cliente");
            Console.Write("DNI: ");
            AEliminar.DNI = Console.ReadLine();
            clienteControlador.Eliminar(AEliminar);
            Console.WriteLine("Cliente eliminado con exito");
        }

        public void ObtenerClientePorDNI()
        {
            Cliente AObtener = new Cliente();
            Console.WriteLine("Buscar cliente por DNI");
            Console.Write("DNI: ");
            AObtener.DNI = Console.ReadLine();
            ResponseWrapper<Cliente> obtenido = clienteControlador.ObtenerClientePorDNI(AObtener.DNI);
            if(obtenido.Respuesta != null) 
            {
                MostrarUnCliente(obtenido.Respuesta);
            }
            else
            {
                Console.WriteLine(obtenido.Error.ToString()); 
            }
                        
      
        }

        public void ObtenerPorApellido()
        {
            Cliente aObtener = new Cliente();
            Console.WriteLine("Buscar cliente por Apellido");
            Console.Write("Apellido: ");
            aObtener.Apellido = Console.ReadLine();

            ResponseWrapper<List<Cliente>> obtenido = clienteControlador.ObtenerClientesPorApellido(aObtener.Apellido);
            if(obtenido.Respuesta != null)
            {
                foreach(var obt in obtenido.Respuesta)
                MostrarUnCliente(obt);
            }
            else
            {
                Console.WriteLine(obtenido.Error.ToString());
            }
            
        }
    }
}
