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
        Task ChangingValue(Objeto objeto, double valor);
    }
}