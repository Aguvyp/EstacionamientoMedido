using EstacionamientoMedido.Controladores;
using EstacionamientoMedido.Modelos;
using System.Security.Cryptography.X509Certificates;

ClienteController clienteControlador = new ClienteController();
Repositorio repo = new Repositorio();
void Menu()
{
    int eleccion;
    Console.WriteLine("1. Cargar cliente");
    Console.WriteLine("2. Mostrar clientes cargados");
    Console.WriteLine();
    Console.Write("Opcion: ");
    eleccion = int.Parse(Console.ReadLine());

    string texto = Console.ReadLine();

    eleccion = int.Parse(texto);

    switch (eleccion)
    {
        case 1:
            //Cliente clienteTemporal1 = CargarDatosCliente(); ------> Cargar cliente nuevo al sistema
            //clienteControlador.GuardarCliente(clienteTemporal1); -----> Agregamos el cliente nuevo a la lista
            // es igual a hacer lo siguiente:
            repo.Clientes.Add(CargarDatosCliente());
            Console.WriteLine();
            Menu();
            break;

        case 2:

            MostrarClientesRegistrados(clienteControlador.ObtenerClientes());

            Console.WriteLine();
            Menu();
            break;
            
    }

    Cliente CargarDatosCliente()
    {
        Cliente clienteNuevo = new Cliente();

        Console.Write("Nombre: ");
        clienteNuevo.Nombre = Console.ReadLine();
        Console.Write("Apellido: ");
        clienteNuevo.Apellido = Console.ReadLine();
        Console.Write("Telefono: ");
        clienteNuevo.Telefono = Console.ReadLine();
        Console.Write("Email: ");
        clienteNuevo.Email = Console.ReadLine();

        return clienteNuevo;
    }

    void MostrarClientesRegistrados(List<Cliente> listadoClientes)
    {
        Console.WriteLine("Lista de clientes registrados: ");

        foreach(var item in listadoClientes)
        {
            Console.WriteLine($"> Nombre: {item.Nombre} {item.Apellido} - Tel: {item.Telefono} - Email: {item.Email}");
        }
    }
}