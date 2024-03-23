using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Core.Entidades;
using Core.Interfaces.Servicios;
using Services.validators;
using Core.Interfaces;
using System.Text;

namespace Services.Services
{
    public class SesionServicios : ISesionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SesionServicios(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string Cerrar_Sesion(Sesion sesion)
        {
            _unitOfWork.SesionRepositorio.Remove(sesion);
            return "";
        }

        public async Task<Sesion> Iniciar_Sesion(string cedula, string contraseña)
        {
            var lista = await _unitOfWork.UsuarioRepositorio.GetAllAsync();
            if (lista.Any(x => x.Cedula == cedula && x.Contraseña == contraseña))
            {
                Usuario usuario = await _unitOfWork.UsuarioRepositorio.GetByIdAsync(cedula);
                if (usuario == null) return null;
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("c2c3111663e00afe901d9c00ab169d36");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, (usuario.Apodo != "") ? 
                            usuario.Apodo : $"{usuario.Nombres} {usuario.Apellidos}"),
                        new Claim("cedula", usuario.Cedula)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(15),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                string tokenFinal = tokenHandler.WriteToken(token);
                Sesion sesion = new Sesion
                {
                    Cedula_usuario = usuario.Cedula,
                    Token = tokenFinal
                };
                await _unitOfWork.SesionRepositorio.AddAsync(sesion);
                return sesion;
            } else return null;

        }

        public string Validar(string cedula, string token)
        {
            throw new NotImplementedException();
        }
    }
}