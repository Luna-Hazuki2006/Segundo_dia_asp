using Core.Entidades;

namespace Infrastructure.Repositorios
{
    public class MisionRepositorio : BaseRepositorio<Mision>
    {
        public MisionRepositorio(AppDbContext context) : base(context) {
            
        }
    }
}