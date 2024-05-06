using EstacionamientoMedido.Controladores;
using EstacionamientoMedido.Modelos;
using EstacionamientoMedido.Vistas;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;


Menu menuApp = new Menu();
menuApp.MenuAMostrar();

   
    //void CalcularPrecioTotal(Estacionamiento estacionamiento)
    //{


    //    estacionamiento.Salida = DateTime.Now;
    //    TimeSpan diferenciaHorario = estacionamiento.Salida - estacionamiento.Entrada;
    //    double diferenciaHoras = diferenciaHorario.TotalHours;
    //    Console.WriteLine();

    //    if(diferenciaHoras >= 1)
    //    {
    //        estacionamiento.TotalEstacionamiento = (int)(diferenciaHoras * estacionamiento.PrecioHora);
    //    }
    //    else if(diferenciaHoras < 1)
    //    {
    //        estacionamiento.TotalEstacionamiento = (int)(1 * estacionamiento.PrecioHora);
    //    }

    //    Console.WriteLine($"El cliente {estacionamiento.VehiculoEstacionado.Cliente.Apellido.ToUpper()}, {estacionamiento.VehiculoEstacionado.Cliente.Nombre.ToUpper()} estacionó el vehiculo patente {estacionamiento.VehiculoEstacionado.Patente.ToUpper()}.");
    //    Console.WriteLine(($"Ingreso: {estacionamiento.Entrada}"));
    //    Console.WriteLine($"Egreso: {estacionamiento.Salida}");
    //    Console.WriteLine($"Tiempo estacionado: {diferenciaHoras}");
    //    Console.WriteLine($"---- A PAGAR ----");
    //    if (diferenciaHoras < 1)
    //    {
    //        Console.WriteLine("Usted estacionó por menos de 1hs que es el tiempo minimo, se le cobrara el basico de 1hs");
    //        Console.WriteLine($"Precio por hora: {estacionamiento.PrecioHora} x 1 = ${estacionamiento.TotalEstacionamiento}");
    //    }
    //    else
    //    {
    //        Console.WriteLine($"Precio por hora: {estacionamiento.PrecioHora} x {diferenciaHoras} = ${estacionamiento.TotalEstacionamiento}");
    //    }
        
    //    Console.WriteLine("********** ESTACIONAMIENTO FINALIZADO **********");
    //}
             
 


