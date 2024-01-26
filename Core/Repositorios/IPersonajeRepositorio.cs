using Core.Entidades;

namespace Core.Repositorios {
    public interface IPersonajeRepositorio : IBaseRepositorio<Personaje>
    {
        Task LeveUp(Personaje personaje);
    }
}
