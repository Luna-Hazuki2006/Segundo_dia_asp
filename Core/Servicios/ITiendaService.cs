using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;

namespace Core.Servicios
{
    public interface ITiendaService
    {
        Task<Tienda> GetTiendaById(int id);
        Task<IEnumerable<Tienda>> GetAll();
        Task BuyingObjects(Tienda tienda, Personaje personaje, Objeto objeto);
    }
}