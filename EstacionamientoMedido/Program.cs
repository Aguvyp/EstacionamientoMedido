using EstacionamientoMedido.Controladores;
using EstacionamientoMedido.Modelos;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

ClienteController clienteControlador = new ClienteController();
VehiculoController vehiculoControlador = new VehiculoController();
Repositorio repo = new Repositorio();

Menu();
void Menu()
{
    int eleccion;
    Console.WriteLine("1. Cargar cliente");
    Console.WriteLine("2. Mostrar clientes cargados");
    Console.WriteLine("3. Registrar vehiculo nuevo");
    Console.WriteLine("4. Mostrar vehiculos registrados");
    Console.WriteLine("5. Cerrar");
    Console.WriteLine();
    Console.Write("Opcion: ");
    eleccion = int.Parse(Console.ReadLine());

    
    switch (eleccion)
    {
        case 1:
            
            Cliente clienteTemporal1 = CargarDatosCliente();  // ------>Cargar cliente nuevo al sistema
            clienteControlador.GuardarCliente(clienteTemporal1);  // -----> Agregamos el cliente nuevo a la lista
            Console.WriteLine();
            Menu();
            break;

        case 2:

            MostrarClientesRegistrados(clienteControlador.ObtenerClientes());
            Console.WriteLine();
            Menu();
            break;

        case 3:
            Vehiculo vehiculoTemporal = CargarDatosVehiculo(repo.Clientes);
            vehiculoControlador.CargarVehiculo(vehiculoTemporal);
            Console.WriteLine();
            Menu();
            break;

        case 4:
            MostrarVehiculosRegistrados(vehiculoControlador.ObtenerVehiculos());
            Console.WriteLine();
            Menu();
            break;

        default:
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

    Vehiculo CargarDatosVehiculo(List<Cliente>listadoClientes)
    {
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

        foreach(var item in listadoClientes)
        {
            if(item.Nombre == dueñoMomentaneo)
            {
                vehiculoNuevo.Cliente = item;
            }
        }

        return vehiculoNuevo;

    }

    void MostrarVehiculosRegistrados(List<Vehiculo> listadoVehiculos)
    {
        Console.WriteLine("Lista de vehiculos registrados");

        foreach( var item in listadoVehiculos)
        {
            Console.Write($">Dueño: {item.Cliente.Nombre} - Patente: {item.Patente} - Marca: {item.Marca} - Modelo: {item.Modelo} - Color: {item.Color}");
        }
    }

}
