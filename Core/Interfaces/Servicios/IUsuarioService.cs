using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;

namespace Core.Interfaces.Servicios
{
    public interface IUsuarioService
    {
        Task<Usuario> Registrar(Usuario usuario);
        Task<Usuario> ActualizarDatos(Usuario usuario);
        Task<Usuario> Consultar(string cedula);
    }
}