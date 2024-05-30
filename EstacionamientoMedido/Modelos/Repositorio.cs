using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Modelos
{
    public class Repositorio
    {
        /*
         * SINGLETON
         * 1- Constructor Privado
         * 2- Metodo para obtener instancia
         * 3- El metodo y la instancia deben ser estatico
         */

        public List<Cliente> Clientes = new List<Cliente>();
        public List<Vehiculo> Vehiculos = new List<Vehiculo>();
        public List<PlazaEstacionamiento> PlazasEstacionamiento = new List<PlazaEstacionamiento>();
        public List<Estacionamiento> Estacionamientos = new List<Estacionamiento>();

        private static Repositorio Instancia;
        private Repositorio()
        {
            PrecargarDatos();
        }

        //Patron de diseño SINGLETON
        public static Repositorio GetInstance()
        {
            if(Instancia == null)
            {
                Instancia = new Repositorio();
                return Instancia;
            }
            else
            {
                return Instancia;
            }
        }
        private void PrecargarDatos()
        {
            Clientes.Add(new Cliente()
            {
                Nombre = "Pepe",
                Apellido = "Gonzales",
                DNI = "123123123",
                Telefono = "123456",
                Email = "notiene@gmail.com",
            });
            Clientes.Add(new Cliente()
            {
                Nombre = "Juan",
                Apellido = "Fernandez",
                DNI = "987654321",
                Telefono = "654321",
                Email = "estesitiene@gmail.com",
            });
      


        }
    }
}
