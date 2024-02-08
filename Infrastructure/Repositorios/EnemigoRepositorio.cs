using Core.Entidades;
using Core.Interfaces.Repositorios;
using Infrastructure.Data;

namespace Infrastructure.Repositorios
{
    public class EnemigoRepositorio : BaseRepositorio<Enemigo>, IEnemigoRepositorio
    {
        public EnemigoRepositorio(AppDbContext context) : base(context) {
            
        }
    }
}