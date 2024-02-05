using Core.Entidades;

namespace Infrastructure.Repositorios
{
    public class InventarioRepositorio : BaseRepositorio<Inventario>
    {
        public InventarioRepositorio(AppDbContext context) : base(context) {
            
        }
    }
}