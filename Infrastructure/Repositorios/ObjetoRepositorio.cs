using Core.Entidades;
using Core.Interfaces.Repositorios;

namespace Infrastructure.Repositorios
{
    public class ObjetoRepositorio : BaseRepositorio<Objeto>, IObjetoRepositorio
    {
        public ObjetoRepositorio(AppDbContext context) : base(context) {
            
        }
    }
}