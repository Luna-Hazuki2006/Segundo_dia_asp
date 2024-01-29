using Core.Entidades;

namespace Core.Repositorios {
    public interface IPersonajeRepositorio : IBaseRepositorio<Personaje>
    {
        Task LeveUp(Personaje personaje);
        Task LosingLife(Personaje personaje, double vida_perdida);
        Task GainingLife(Personaje personaje, double vida_ganada);
        Task UsarMagia(Personaje personaje, double magia);
        Task GanarMagia(Personaje personaje, double magia);
        
    }
}
