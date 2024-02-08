using Core.Interfaces.Repositorios;

namespace Core.Interfaces {
    public interface IUnitOfWork : IDisposable
    {
        IPersonajeRepositorio PersonajeRepositorio { get; }
        ITiendaRepositorio TiendaRepositorio {get;}
        IObjetoRepositorio ObjetoRepositorio {get;}
        IMisionRepositorio MisionRepositorio {get;}
        IInventarioRepositorio InventarioRepositorio {get;}
        IEnemigoRepositorio EnemigoRepositorio {get;}
        IBancoRepositorio BancoRepositorio {get;}
        Task<int> CommitAsync();
    }
}

