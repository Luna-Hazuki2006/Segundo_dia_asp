using Core.Entidades;

namespace Core.Repositorios
{
    public interface ITiendaRepositorio : IBaseRepositorio<Tienda>
    {
        Task BuyingObjects(Tienda tienda, Personaje personaje, Objeto objeto);
    }
}