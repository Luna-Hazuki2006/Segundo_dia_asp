using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces.Servicios;

namespace Services.Services
{
    public class UsuarioServicios : IUsuarioService
    {
        public Task<Usuario> ActualizarDatos(string cedula, Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Consultar(string cedula)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> Listar()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Registrar(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}