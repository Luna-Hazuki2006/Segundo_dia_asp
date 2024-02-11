using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;

namespace Core.Interfaces.Servicios
{
    public interface IRecompensaService
    {
        Task<Recompensa> GetRecompensaById(int id);
        Task<IEnumerable<Recompensa>> GetAll();
        Task<Recompensa> CreateRecompensa(Recompensa recompensa);
        Task<Recompensa> UpdateRecompensa(int id, Recompensa recompensa);
        Task DeleteRecompensa(int id);
    }
}