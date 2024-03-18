using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces.Repositorios;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositorios
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(AppDbContext context) : base(context)
        {
            Context = context;
        }

        public async Task<Usuario> AddAsync(Usuario entidad)
        {
            await dbSet.AddAsync(entidad);
            return entidad;
        }

        public void Remove(Usuario entidad)
        {
            dbSet.Remove(entidad);
        }

        public void RemoveRange(IEnumerable<Usuario> entidades)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> Update(Usuario entidad)
        {
            dbSet.Update(entidad);
            return entidad;

        }

        async Task<IEnumerable<Usuario>> IBaseRepositorio<Usuario>.GetAllAsync()
        {
            var todos = await dbSet.ToListAsync();
            return todos;
        }

        async ValueTask<Usuario> IUsuarioRepositorio.GetByIdAsync(string id)
        {
            var valor = await dbSet.FindAsync(id);
            return valor;
        }
    }
}