using EstacionamientoMedido.Modelos;
using EstacionamientoMedido.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstacionamientoMedido.Validations;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Results;
using ValidationResult = FluentValidation.Results.ValidationResult;
using System.Security.Cryptography.X509Certificates;


namespace EstacionamientoMedido.Controladores
{
    public class ClienteController
    {
        Repositorio repo = Repositorio.GetInstance();

        public void GuardarCliente(Cliente c)
        {
            ClienteValidator validator = new ClienteValidator();
            ValidationResult result = validator.Validate(c);
            if(result.IsValid)
            {
                repo.Clientes.Add(c);
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    Console.WriteLine(item.ErrorMessage);
                }
            }


        }

        public List<Cliente> ObtenerClientes()
        {
            return repo.Clientes;
        }

        public bool ExisteCliente(string dni)
        {
            bool resultado;

            resultado = repo.Clientes
                .Where(x => x.DNI.Equals(dni))
                .Any();

            return resultado;
        }
        public Cliente Modificar(Cliente c)
        {
            Cliente clienteDelete = repo.Clientes
                .Where(x => x.DNI == c.DNI)
                .SingleOrDefault(); //Busco cliente con ese dni
            
            repo.Clientes.Remove(clienteDelete); //Lo elimino


            ClienteValidator validator = new ClienteValidator();
            ValidationResult result = validator.Validate(c);
            if (result.IsValid)
            {
                repo.Clientes.Add(c);
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    Console.WriteLine(item.ErrorMessage);
                }
            } //Cargo el nuevo


            return c;
        }

        public void Eliminar(Cliente c) //No es conveniente borrar informacion, si deshabilitarlo.
        {
            Cliente clienteDelete = repo.Clientes.Find(x => x.DNI == c.DNI); //Busco cliente con ese dni
            repo.Clientes.Remove(clienteDelete);

        }

        public ResponseWrapper<Cliente> ObtenerClientePorDNI(string dni)
        {
            Cliente clienteABuscar = repo.Clientes
                .Where(x => x.DNI ==  dni)
                .SingleOrDefault();

            if(clienteABuscar == null || dni == "")
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


            if(respuesta == null || apellido == "" || respuesta.Count == 0)
            {
                return new ResponseWrapper<List<Cliente>>("No hay cliente con ese apellido", true);
            }
            else
            {
                return new ResponseWrapper<List<Cliente>>(respuesta, false);
                
            }
  
        }
    }
}
