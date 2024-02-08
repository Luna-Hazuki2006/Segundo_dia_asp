using Core.Entidades;
using Core.Interfaces.Repositorios;
using Infrastructure.Data;

namespace Infrastructure.Repositorios
{
    public class MisionRepositorio : BaseRepositorio<Mision>, IMisionRepositorio
    {
        public MisionRepositorio(AppDbContext context) : base(context) {
            
        }
    }
}