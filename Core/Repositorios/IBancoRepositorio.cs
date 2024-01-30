using Core.Entidades;

namespace Core.Repositorios
{
    public interface IBancoRepositorio : IBaseRepositorio<Banco>
    {
        Task DepositingMoney(Personaje personaje, Banco banco, double cantidad);
        Task TakingMoney(Personaje personaje, Banco banco, double cantidad);
    }
}