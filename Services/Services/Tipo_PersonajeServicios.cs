using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces.Servicios;

namespace Services.Services
{
    public class Tipo_PersonajeServicios : ITipo_PersonajeService
    {
        public Task<Tipo_Personaje> CreateTipo_Personaje(Tipo_Personaje tipo_personaje)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTipo_Personaje(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tipo_Personaje>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Tipo_Personaje> GetTipo_PersonajeById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Tipo_Personaje> UpdateTipo_Personaje(int id, Tipo_Personaje tipo_personaje)
        {
            throw new NotImplementedException();
        }
    }
}