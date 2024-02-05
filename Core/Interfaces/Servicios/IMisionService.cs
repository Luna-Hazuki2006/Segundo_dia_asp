using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;

namespace Core.Servicios
{
    public interface IMisionService
    {
        Task<Mision> GetMisionById(int id);
        Task<IEnumerable<Mision>> GetAll();
        Task<Mision> CreateMision(Mision Mision);
        Task<Mision> UpdateMision(int id, Mision Mision);
        Task DeleteMision(int id);
        Task WinningMision(Personaje personaje, Mision mision);
        Task LosingMision(Personaje personaje, Mision mision);
    }
}