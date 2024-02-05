using Core.Entidades;

namespace Infrastructure.Repositorios
{
    public class BancoRepositorio : BaseRepositorio<Banco>
    {
        public BancoRepositorio(AppDbContext context) : base(context) {
            
        }
    }
}