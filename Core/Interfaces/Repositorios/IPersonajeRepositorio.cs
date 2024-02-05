using Core.Entidades;

namespace Core.Interfaces.Repositorios {
    public interface IPersonajeRepositorio : IBaseRepositorio<Personaje>
    {
        Task ModifyLevel(Personaje personaje);
        Task ModifyLife(Personaje personaje);
        Task ModifyMagic(Personaje personaje);
        Task ModifyStrenght(Personaje personaje);
        Task ModifyAgility(Personaje personaje);
        Task ModifyInteligence(Personaje personaje);

    }
}
