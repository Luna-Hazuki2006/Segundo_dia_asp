using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces.Servicios;

namespace Services.Services
{
    public class ObjetivoServicios : IObjetivoService
    {
        public Task<Objetivo> CreateObjetivo(Objetivo objetivo)
        {
            throw new NotImplementedException();
        }

        public Task DeleteObjetivo(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Objetivo>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Objetivo> GetObjetivoById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Objetivo> UpdateObjetivo(int id, Objetivo objetivo)
        {
            throw new NotImplementedException();
        }
    }
}