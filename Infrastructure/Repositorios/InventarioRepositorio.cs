using Core.Entidades;
using Core.Interfaces.Repositorios;

namespace Infrastructure.Repositorios
{
    public class InventarioRepositorio : BaseRepositorio<Inventario>, IInvetarioRepositorio
    {
        public InventarioRepositorio(AppDbContext context) : base(context) {
            
        }
    }
}