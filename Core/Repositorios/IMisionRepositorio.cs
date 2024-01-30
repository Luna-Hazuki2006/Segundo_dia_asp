using Core.Entidades;

namespace Core.Repositorios
{
    public interface IMisionRepositorio : IBaseRepositorio<Mision>
    {
        Task WinningMision(Personaje personaje, Mision mision);
    }
}