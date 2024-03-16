using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces;
using Core.Interfaces.Servicios;
using Services.validators;

namespace Services.Services
{
    public class UsuarioServicios : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsuarioServicios(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
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

        public async Task<Usuario> Registrar(Usuario usuario)
        {
            UsuarioValidacion validator = new();

            var validationResult = await validator.ValidateAsync(usuario);
            if (validationResult.IsValid)
            {
                await _unitOfWork.UsuarioRepositorio.AddAsync(usuario);
                await _unitOfWork.CommitAsync();
            }
            else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return newUsuario;
        }
    }
}