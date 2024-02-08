using Core.Entidades;
using Core.Interfaces.Repositorios;
using Infrastructure.Data;

namespace Infrastructure.Repositorios
{
    public class TiendaRepositorio : BaseRepositorio<Tienda>, ITiendaRepositorio
    {
        public TiendaRepositorio(AppDbContext context) : base(context) {
            
        }
    }
}