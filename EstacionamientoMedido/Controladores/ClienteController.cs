﻿using EstacionamientoMedido.Modelos;
using EstacionamientoMedido.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Controladores
{
    public class ClienteController
    {
        Repositorio repo = new Repositorio();

        public void GuardarCliente(Cliente c)
        {
            repo.Clientes.Add(c);
        }

        public List<Cliente> ObtenerClientes()
        {
            return repo.Clientes;
        }
        
        public Cliente Modificar(Cliente c)
        {
            Cliente clienteDelete = repo.Clientes.Find(x => x.DNI == c.DNI); //Busco cliente con ese dni
            
            repo.Clientes.Remove(clienteDelete); //Lo elimino
            
            repo.Clientes.Add(c); //Cargo el nuevo


            return c;
        }

        public void Elimianr(Cliente c) //No es conveniente borrar informacion, si deshabilitarlo.
        {
            Cliente clienteDelete = repo.Clientes.Find(x => x.DNI == c.DNI); //Busco cliente con ese dni
            repo.Clientes.Remove(c);

        }

        public ResponseWrapper<Cliente> ObtenerClientePorDNI(string dni)
        {
            Cliente clienteABuscar = repo.Clientes
                .Where(x => x.DNI ==  dni)
                .SingleOrDefault();

            if(clienteABuscar == null)
            {
                return new ResponseWrapper<Cliente>("Cliente no encontrado", true);
                
            }
            else
            {
                return new ResponseWrapper<Cliente>(clienteABuscar, false);
            }
            
        }
            
        public ResponseWrapper<List<Cliente>>ObtenerClientesPorApellido(string apellido)
        {
            List<Cliente> respuesta = repo.Clientes
                .Where(x => x.Apellido.Contains(apellido))
                .ToList();


            if(respuesta != null)
            {
                return new ResponseWrapper<List<Cliente>>(respuesta, false);
                
            }
            else
            {
                return new ResponseWrapper<List<Cliente>>("No hay cliente con ese apellido", true);
            }
  
        }
    }
}
