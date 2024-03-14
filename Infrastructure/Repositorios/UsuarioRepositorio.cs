using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces.Repositorios;
using Infrastructure.Data;

namespace Infrastructure.Repositorios
{
    public class UsuarioRepositorio : BaseRepositorio<Sesion>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(AppDbContext context) : base(context)
        {

        }

        public Task AddAsync(Usuario entidad)
        {
            throw new NotImplementedException();
        }

        public void Remove(Usuario entidad)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Usuario> entidades)
        {
            throw new NotImplementedException();
        }

        public Task Update(Usuario entidad)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Usuario>> IBaseRepositorio<Usuario>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        ValueTask<Usuario> IBaseRepositorio<Usuario>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}