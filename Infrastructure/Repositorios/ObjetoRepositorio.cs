using Core.Entidades;

namespace Infrastructure.Repositorios
{
    public class ObjetoRepositorio : BaseRepositorio<Objeto>
    {
        public ObjetoRepositorio(AppDbContext context) : base(context) {
            
        }
    }
}