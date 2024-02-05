using Core.Interfaces.Repositorios;

namespace Core.Interfaces {
    public interface IUnitOfWork : IDisposable
    {
        IPersonajeRepositorio PersonajeRepositorio { get; }
        Task<int> CommitAsync();
    }
}

