using Core.Entidades;
using Core.Interfaces.Repositorios;
using Infrastructure.Data;

namespace Infrastructure.Repositorios
{
    public class BancoRepositorio : BaseRepositorio<Banco>, IBancoRepositorio
    {
        public BancoRepositorio(AppDbContext context) : base(context) {
            
        }
    }
}

// https://www.bilibili.com/404#up