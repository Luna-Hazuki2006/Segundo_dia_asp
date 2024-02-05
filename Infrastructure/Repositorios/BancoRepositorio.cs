using Core.Entidades;
using Core.Interfaces.Repositorios;

namespace Infrastructure.Repositorios
{
    public class BancoRepositorio : BaseRepositorio<Banco>, IBancoRepositorio
    {
        public BancoRepositorio(AppDbContext context) : base(context) {
            
        }
    }
}