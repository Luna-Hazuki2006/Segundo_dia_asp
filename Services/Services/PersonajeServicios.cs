using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Servicios;

namespace Services.Services
{
    public class PersonajeServicios : IPersonajeService
    {
        public Task<IEnumerable<Personaje>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Personaje> GetPersonajeById(int id)
        {
            throw new NotImplementedException();
        }
    }
}