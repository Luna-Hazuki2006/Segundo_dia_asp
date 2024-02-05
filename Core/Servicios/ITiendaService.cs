using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;

namespace Core.Servicios
{
    public interface ITiendaService
    {
        Task<Objeto> GetObjetoById(int id);
        Task<IEnumerable<Objeto>> GetAll();
        Task BuyingObjects(Tienda tienda, Personaje personaje, Objeto objeto);
    }
}