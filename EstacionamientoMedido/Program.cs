using EstacionamientoMedido.Controladores;
using EstacionamientoMedido.Modelos;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

ClienteController clienteControlador = new ClienteController();
VehiculoController vehiculoControlador = new VehiculoController();
EstacionamientoController estacionamientoController = new EstacionamientoController();

Repositorio repo = new Repositorio();

Menu();
void Menu()
{
    int eleccion;
    Console.WriteLine("1. Cargar cliente");
    Console.WriteLine("2. Mostrar clientes cargados");
    Console.WriteLine("3. Registrar vehiculo nuevo");
    Console.WriteLine("4. Mostrar vehiculos registrados");
    Console.WriteLine("-----------------------------------");
    Console.WriteLine("5. Iniciar estacionamiento");
    Console.WriteLine("6. Cerrar");
    Console.WriteLine();
    Console.Write("Opcion: ");
    eleccion = int.Parse(Console.ReadLine());

    
    switch (eleccion)
    {
        case 1:
            
            Cliente clienteNuevo = CargarDatosCliente();  // ------>Cargar cliente nuevo al sistema
            clienteControlador.GuardarCliente(clienteNuevo);  // -----> Agregamos el cliente nuevo a la lista
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

        case 5:
            List<Vehiculo> vehiculosCargados = vehiculoControlador.ObtenerVehiculos();
            Estacionamiento estacionamientoTemporal = IniciarEstacionamiento(vehiculosCargados, repo.PlazasEstacionamiento);
            estacionamientoController.GuardarEstacionamiento(estacionamientoTemporal);
           // Console.WriteLine($"Plaza: {estacionamientoTemporal.PlazaEstacionamiento.Nombre} | Patente: {estacionamientoTemporal.VehiculoEstacionado.Patente} | Dueño: {estacionamientoTemporal.VehiculoEstacionado.Cliente.Apellido}, {estacionamientoTemporal.VehiculoEstacionado.Cliente.Nombre} | Telefono: {estacionamientoTemporal.VehiculoEstacionado.Cliente.Telefono} \n" +
           //$"Marca: {estacionamientoTemporal.VehiculoEstacionado.Marca} | Modelo: {estacionamientoTemporal.VehiculoEstacionado.Modelo} | Color: {estacionamientoTemporal.VehiculoEstacionado.Color}");
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
            Console.WriteLine($">Dueño: {item.Cliente.Nombre} - Patente: {item.Patente} - Marca: {item.Marca} - Modelo: {item.Modelo} - Color: {item.Color}");
        }
    }

    Estacionamiento IniciarEstacionamiento(List<Vehiculo> listadoVehiculos, List<PlazaEstacionamiento>listadoPlazaEstacionamiento)
    {
        Estacionamiento estacionamiento = new Estacionamiento();
        
        
        Console.WriteLine(" ---------------- ESTACIONAMIENTO MEDIDO ----------------");
        Console.WriteLine($"Precio por hora: ${estacionamiento.PrecioHora}");

        //Ver plazas disponibles
        List<PlazaEstacionamiento> plazasDisponibles = listadoPlazaEstacionamiento.Where(p => p.Disponible).ToList();
        if (plazasDisponibles.Any())
        {
            PlazaEstacionamiento plazaAsignada = plazasDisponibles.First();
            plazaAsignada.Disponible = false;
            estacionamiento.PlazaEstacionamiento = plazaAsignada; // Asignar la plaza de estacionamiento al estacionamiento
            Console.WriteLine($"Plaza: {estacionamiento.PlazaEstacionamiento.Nombre}");
            
        }
        else
        {
            Console.WriteLine("No hay plazas de estacionamiento disponibles.");
        }

        string autoTemporal;
        Console.Write("Patente del vehiculo a estacionar: ");
        autoTemporal = Console.ReadLine();

        if (autoTemporal != null || autoTemporal != "")
        {
            
            foreach (var item in listadoVehiculos)
            {
                if (autoTemporal == item.Patente)
                {
                    estacionamiento.VehiculoEstacionado = item;
                    Console.WriteLine();
                    Console.WriteLine(">>>>>>>>>>>>> Estacionamiento corriendo <<<<<<<<<<<<< ");
                    Console.WriteLine("************* INFO DEL ESTACIONAMIENTO *************");
                    Console.WriteLine($"Horario de entrada: {estacionamiento.Entrada} --------- Plaza: {estacionamiento.PlazaEstacionamiento.Nombre}");
                    Console.WriteLine($"Patente: {estacionamiento.VehiculoEstacionado.Patente} ------ Cliente: {estacionamiento.VehiculoEstacionado.Cliente.Nombre}, {estacionamiento.VehiculoEstacionado.Cliente.Apellido} ------ Telefono: {estacionamiento.VehiculoEstacionado.Cliente.Telefono}");
                    Console.WriteLine($"Marca: {estacionamiento.VehiculoEstacionado.Marca} ------ Modelo: {estacionamiento.VehiculoEstacionado.Modelo} ------ Color: {estacionamiento.VehiculoEstacionado.Color}");
                    Console.WriteLine("*****************************************************");
                }
                else
                {
                    Console.WriteLine("Vehiculo no registrado");
                }
            }
        }
        else Console.WriteLine("La patente es nula");
        
        return estacionamiento;
   
    }
}
