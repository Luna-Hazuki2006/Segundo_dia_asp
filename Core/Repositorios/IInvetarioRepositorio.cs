using Core.Entidades;

namespace Core.Repositorios
{
    public interface IInvetarioRepositorio : IBaseRepositorio<Inventario>
    {
        Task ObtainingObject(Personaje personaje, Objeto objeto);
        Task UsingObject(Personaje personaje, Objeto objeto);
    }
}