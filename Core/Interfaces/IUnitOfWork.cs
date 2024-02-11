using Core.Interfaces.Repositorios;

namespace Core.Interfaces {
    public interface IUnitOfWork : IDisposable
    {
        IPersonajeRepositorio PersonajeRepositorio { get; }
        ITiendaRepositorio TiendaRepositorio {get;}
        IObjetoRepositorio ObjetoRepositorio {get;}
        IMisionRepositorio MisionRepositorio {get;}
        IObjetivoRepositorio ObjetivoRepositorio {get;}
        IRecompensaRepositorio RecompensaRepositorio {get;}
        ITipo_PersonajeRepositorio Tipo_PersonajeRepositorio {get;}
        IInventarioRepositorio InventarioRepositorio {get;}
        IEnemigoRepositorio EnemigoRepositorio {get;}
        IBancoRepositorio BancoRepositorio {get;}

        Task<int> CommitAsync();
    }
}

