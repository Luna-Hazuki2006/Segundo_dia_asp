using Core.Entidades;

namespace Core.Repositorios
{
    public interface IEnemigoRepositorio : IBaseRepositorio<Enemigo>
    {
        Task Attacking(Enemigo enemigo, Personaje personaje);
        Task GettingAttacked(Enemigo enemigo, Personaje personaje);
        Task Killing(Enemigo enemigo, Personaje personaje);
        Task Dying(Enemigo enemigo, Personaje personaje);
    }
}