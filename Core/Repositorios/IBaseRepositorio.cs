namespace Core.Repositorios {
    public interface IBaseRepositorio<TEntity> where TEntity : class
    {
        ValueTask<TEntity> GetByIdAsync();
        Task<IEnumerable<TEntity>> GetAllAsync();
        void Remove(TEntity entidad);
        void RemoveRange(IEnumerable<TEntity> entidades);
        Task Update(TEntity entidad);
        Task AddAsync(TEntity entidad);
    }
}