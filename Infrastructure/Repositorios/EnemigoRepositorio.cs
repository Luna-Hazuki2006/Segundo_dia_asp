using Core.Entidades;

namespace Infrastructure.Repositorios
{
    public class EnemigoRepositorio : BaseRepositorio<Enemigo>
    {
        public EnemigoRepositorio(AppDbContext context) : base(context) {
            
        }
    }
}