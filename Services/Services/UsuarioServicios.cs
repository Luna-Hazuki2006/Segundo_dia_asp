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
        public async Task<Usuario> ActualizarDatos(string cedula, Usuario usuario)
        {
            UsuarioValidacion validaciones = new();
            var validationResult = await validaciones.ValidateAsync(usuario);
            if (validationResult.IsValid)
            {
                var muchos = await _unitOfWork.UsuarioRepositorio.GetAllAsync();
                if (muchos.Any(x => x.Cedula == cedula))
                {
                    await _unitOfWork.UsuarioRepositorio.Update(usuario);
                    await _unitOfWork.CommitAsync();
                } else throw new ArgumentException("No se pudo actualizar los datos");
            } else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return usuario;
        }

        public async Task<Usuario> Consultar(string cedula)
        {
            var muchos = await _unitOfWork.UsuarioRepositorio.GetAllAsync();
            var usuario = 
                muchos.FirstOrDefault(x => x.Cedula == cedula) ?? 
                throw new ArgumentException("No se pudo encontrar el usuario");
            return usuario;
        }

        public async Task<IEnumerable<Usuario>> Listar()
        {
            return await _unitOfWork.UsuarioRepositorio.GetAllAsync();
        }

        public async Task<Usuario> Registrar(Usuario usuario)
        {
            UsuarioValidacion validator = new();

            var validationResult = await validator.ValidateAsync(usuario);
            if (validationResult.IsValid)
            {
                var muchos = await _unitOfWork.UsuarioRepositorio.GetAllAsync();
                if (!muchos.Any(x => x.Cedula == usuario.Cedula))
                {
                    await _unitOfWork.UsuarioRepositorio.AddAsync(usuario);
                    await _unitOfWork.CommitAsync();
                } else throw new ArgumentException("La cédula no puede estar repetida");
            }
            else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return usuario;
        }
    }
}