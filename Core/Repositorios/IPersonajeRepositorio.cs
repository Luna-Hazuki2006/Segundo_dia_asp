using Core.Entidades;

namespace Core.Repositorios {
    public interface IPersonajeRepositorio : IBaseRepositorio<Personaje>
    {
        Task ModifyLevel(Personaje personaje);
        Task LosingLife(Personaje personaje, double vida_perdida);
        Task GainingLife(Personaje personaje, double vida_ganada);
        Task UsingMagic(Personaje personaje, double magia);
        Task LosingMagic(Personaje personaje, double magia);
        Task GainingStrenght(Personaje personaje, double puntos);
        Task LosingStrenght(Personaje personaje, double puntos);
        Task GainingAgility(Personaje personaje, double puntos);
        Task LosingAgility(Personaje personaje, double puntos);
        Task GainingInteligence(Personaje personaje, double puntos);
        Task LosingInteligence(Personaje personaje, double puntos);

    }
}
