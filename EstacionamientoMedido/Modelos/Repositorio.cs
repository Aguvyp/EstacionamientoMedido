using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Modelos
{
    public class Repositorio
    {
        public List<Cliente> Clientes = new List<Cliente>();
        public List<Vehiculo> Vehiculos = new List<Vehiculo>();
        public List<PlazaEstacionamiento> PlazasEstacionamiento = new List<PlazaEstacionamiento>();
        public List<Estacionamiento> Estacionamientos = new List<Estacionamiento>();

        public Repositorio()
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

            PlazasEstacionamiento.Add(new PlazaEstacionamiento()
            {
                Nombre = "A",
                Disponible = true
            }); 
            PlazasEstacionamiento.Add(new PlazaEstacionamiento()
            {
                Nombre = "B",
                Disponible = true
            });
            PlazasEstacionamiento.Add(new PlazaEstacionamiento()
            {
                Nombre = "C",
                Disponible = true
            });
            PlazasEstacionamiento.Add(new PlazaEstacionamiento()
            {
                Nombre = "D",
                Disponible = true
            });
            PlazasEstacionamiento.Add(new PlazaEstacionamiento()
            {
                Nombre = "E",
                Disponible = true
            });
            


        }
    }
}
