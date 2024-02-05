using Core.Entidades;
using Core.Interfaces.Repositorios;

namespace Infrastructure.Repositorios
{
    public class MisionRepositorio : BaseRepositorio<Mision>, IMisionRepositorio
    {
        public MisionRepositorio(AppDbContext context) : base(context) {
            
        }
    }
}