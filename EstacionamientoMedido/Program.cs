using EstacionamientoMedido.Controladores;
using EstacionamientoMedido.Modelos;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;



EstacionamientoController estacionamientoController = new EstacionamientoController();

Repositorio repo = new Repositorio();
MenuAMostrar();

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

    Estacionamiento FinalizarEstacionamiento(List<Estacionamiento> listaEstacionamiento)
    {
        Estacionamiento estacionamiento = new Estacionamiento();
        string patenteProvisoria;
        
        Console.Write("Patente del auto a finalziar estacionamiento: ");
        patenteProvisoria = Console.ReadLine();

        if( patenteProvisoria != null)
        {

            foreach( var item in listaEstacionamiento)
            {
                if(patenteProvisoria == item.VehiculoEstacionado.Patente)
                {
                    
                    CalcularPrecioTotal(item);
                }
            }
        }

        return estacionamiento; 

    }

    void CalcularPrecioTotal(Estacionamiento estacionamiento)
    {


        estacionamiento.Salida = DateTime.Now;
        TimeSpan diferenciaHorario = estacionamiento.Salida - estacionamiento.Entrada;
        double diferenciaHoras = diferenciaHorario.TotalHours;
        Console.WriteLine();

        if(diferenciaHoras >= 1)
        {
            estacionamiento.TotalEstacionamiento = (int)(diferenciaHoras * estacionamiento.PrecioHora);
        }
        else if(diferenciaHoras < 1)
        {
            estacionamiento.TotalEstacionamiento = (int)(1 * estacionamiento.PrecioHora);
        }

        Console.WriteLine($"El cliente {estacionamiento.VehiculoEstacionado.Cliente.Apellido.ToUpper()}, {estacionamiento.VehiculoEstacionado.Cliente.Nombre.ToUpper()} estacionó el vehiculo patente {estacionamiento.VehiculoEstacionado.Patente.ToUpper()}.");
        Console.WriteLine(($"Ingreso: {estacionamiento.Entrada}"));
        Console.WriteLine($"Egreso: {estacionamiento.Salida}");
        Console.WriteLine($"Tiempo estacionado: {diferenciaHoras}");
        Console.WriteLine($"---- A PAGAR ----");
        if (diferenciaHoras < 1)
        {
            Console.WriteLine("Usted estacionó por menos de 1hs que es el tiempo minimo, se le cobrara el basico de 1hs");
            Console.WriteLine($"Precio por hora: {estacionamiento.PrecioHora} x 1 = ${estacionamiento.TotalEstacionamiento}");
        }
        else
        {
            Console.WriteLine($"Precio por hora: {estacionamiento.PrecioHora} x {diferenciaHoras} = ${estacionamiento.TotalEstacionamiento}");
        }
        
        Console.WriteLine("********** ESTACIONAMIENTO FINALIZADO **********");
    }
             
 


