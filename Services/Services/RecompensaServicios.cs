using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces.Servicios;

namespace Services.Services
{
    public class RecompensaServicios : IRecompensaService
    {
        public Task<Recompensa> CreateRecompensa(Recompensa recompensa)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRecompensa(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Recompensa>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Recompensa> GetRecompensaById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Recompensa> UpdateRecompensa(int id, Recompensa recompensa)
        {
            throw new NotImplementedException();
        }
    }
}