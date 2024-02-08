using Core.Entidades;
using Core.Interfaces.Repositorios;
using Infrastructure.Data;

namespace Infrastructure.Repositorios
{
    public class InventarioRepositorio : BaseRepositorio<Inventario>, IInventarioRepositorio
    {
        public InventarioRepositorio(AppDbContext context) : base(context) {
            
        }
    }
}