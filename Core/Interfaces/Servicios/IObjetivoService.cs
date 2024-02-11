using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;

namespace Core.Interfaces.Servicios
{
    public interface IObjetivoService
    {
        Task<Objetivo> GetObjetivoById(int id);
        Task<IEnumerable<Objetivo>> GetAll();
        Task<Objetivo> CreateObjetivo(Objetivo objetivo);
        Task<Objetivo> UpdateObjetivo(int id, Objetivo objetivo);
        Task DeleteObjetivo(int id);
    }
}