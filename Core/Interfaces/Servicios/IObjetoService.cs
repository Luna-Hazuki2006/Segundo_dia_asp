using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;

namespace Core.Servicios
{
    public interface IObjetoService
    {
        Task<Objeto> GetObjetoById(int id);
        Task<IEnumerable<Objeto>> GetAll();
        Task<Objeto> CreateObjeto(Objeto Objeto);
        Task<Objeto> UpdateObjeto(int id, Objeto Objeto);
        Task DeleteObjeto(int id);
        Task<Objeto> ChangingValue(Objeto objeto, double valor);
    }
}