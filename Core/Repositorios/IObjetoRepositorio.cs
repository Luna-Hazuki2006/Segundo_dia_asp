using Core.Entidades;

namespace Core.Repositorios
{
    public interface IObjetoRepositorio : IBaseRepositorio<Objeto>
    {
        Task ChangingValue(Objeto objeto, double valor);
    }
}