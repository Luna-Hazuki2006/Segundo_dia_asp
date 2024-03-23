using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;

namespace Core.Interfaces.Servicios
{
    public interface ISesionService
    {
        Task<Sesion> Iniciar_Sesion(string cedula, string contraseña);
        string Cerrar_Sesion(Sesion sesion);
        string Validar(string cedula, string token);
    }
}