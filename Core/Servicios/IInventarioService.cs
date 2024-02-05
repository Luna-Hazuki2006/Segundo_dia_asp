using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;

namespace Core.Servicios
{
    public interface IInventarioService
    {
        Task<Inventario> GetInventarioById(int id);
        Task<IEnumerable<Inventario>> GetAll();
        Task ObtainingObject(Personaje personaje, Objeto objeto);
        Task UsingObject(Personaje personaje, Objeto objeto);
    }
}