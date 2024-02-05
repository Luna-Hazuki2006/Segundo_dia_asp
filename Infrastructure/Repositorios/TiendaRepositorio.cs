using Core.Entidades;

namespace Infrastructure.Repositorios
{
    public class TiendaRepositorio : BaseRepositorio<Tienda>
    {
        public TiendaRepositorio(AppDbContext context) : base(context) {
            
        }
    }
}