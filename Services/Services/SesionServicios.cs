using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces.Servicios;

namespace Services.Services
{
    public class SesionServicios : ISesionService
    {
        public Task Cerrar_Sesion(Sesion sesion)
        {
            throw new NotImplementedException();
        }

        public Task<Sesion> Iniciar_Sesion(string cedula, string contraseña)
        {
            throw new NotImplementedException();
        }
    }
}