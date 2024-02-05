using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;

namespace Core.Servicios
{
    public interface IEnemigoService
    {
        Task<Enemigo> GetEnemigoById(int id);
        Task<IEnumerable<Enemigo>> GetAll();
        Task<Enemigo> CreateEnemigo(Enemigo Enemigo);
        Task<Enemigo> UpdateEnemigo(int id, Enemigo Enemigo);
        Task DeleteEnemigo(int id);
        Task Attacking(Enemigo enemigo, Personaje personaje);
        Task GettingAttacked(Enemigo enemigo, Personaje personaje);
        Task Killing(Enemigo enemigo, Personaje personaje);
        Task Dying(Enemigo enemigo, Personaje personaje);
    }
}