using EstacionamientoMedido.Controladores;
using EstacionamientoMedido.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Vistas
{
    public class EstacionamientoView
    {
        EstacionamientoController controladorEstacionamiento = new EstacionamientoController();
        VehiculoController controladorVehiculo = new VehiculoController();
        VehiculoView vistaVehiculo = new VehiculoView();
        public void IniciarEstacionamiento()
        {
            Console.Write("Ingrese patente de entrada: ");
            string patente = Console.ReadLine();

            if (!controladorVehiculo.ExistePatente(patente))
            {
                Console.WriteLine("Vehiculo no registrado, hagalo a continuacion");
                vistaVehiculo.CargarDatosVehiculo();
            }

            if (controladorEstacionamiento.YaEstaEstacionado(patente))
            {
                Console.WriteLine();
                Console.WriteLine("El vehiculo ya esta estacionado");
                Console.WriteLine();
            }
            else
            {
                controladorEstacionamiento.IniciarEstacionmiento(patente);
                Console.WriteLine("Estacionamiento iniciado con exito");
            }
           

            
        }

        public void FinalizarEstacionamiento()
        {
            Console.WriteLine("Ingrese patente de salida: ");
            string patente = Console.ReadLine();

            Estacionamiento finalizado = controladorEstacionamiento.FinalizarEstacionamiento(patente);
            
            Console.WriteLine(" ************ Estacionamiento finalizado con exito ************");
            Console.WriteLine("Datos:");
            Console.WriteLine($"Patente: {finalizado.VehiculoEstacionado.Patente} - Dueño: {finalizado.VehiculoEstacionado.Cliente.Apellido}, {finalizado.VehiculoEstacionado.Cliente.Nombre} " +
                $" - DNI: {finalizado.VehiculoEstacionado.Cliente.DNI}");
            Console.WriteLine($"Hora ingreso: {finalizado.Entrada} - Hora salida: {finalizado.Salida} - Precio por hora: {finalizado.PrecioHora}");
            Console.WriteLine($"Precio total estacionamiento: ${finalizado.TotalEstacionamiento}");

        }

        public void VerEstacionamientos()
        {
            List<Estacionamiento>estacionamientos = controladorEstacionamiento.ObtenerEstacionamientos();

            if(estacionamientos.Count == 0) 
            {
                Console.WriteLine("No hay estacionamientos");
            }
            else
            {
                Console.WriteLine("Lista de estacionamientos");
                foreach (var item in estacionamientos)
                {
                    if(item.Estado == Enumeraciones.EnumEstacionamiento.Activo)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.WriteLine($"Patente: {item.VehiculoEstacionado.Patente} - {item.Entrada}/{item.Salida}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        public void VerEstacionamientosFiltrados()
        {
            string patenteMomentanea;
            Console.Write("Ingrese patente del vehiculo estacionado:");
            patenteMomentanea = Console.ReadLine();

            List<Estacionamiento> estacionamientosFiltrados = controladorEstacionamiento.ObtenerEstacionamientosPorPatente(patenteMomentanea);

            foreach(var item in estacionamientosFiltrados)
            {
                Console.WriteLine($"Marca: {item.VehiculoEstacionado.Marca} - Modelo: {item.VehiculoEstacionado.Modelo} - Entrada: {item.Entrada}/ Salida: {item.Salida}");
            }
            
        }
    }
}
