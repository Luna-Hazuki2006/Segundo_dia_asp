using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;

namespace Core.Servicios
{
    public interface IBancoService
    {
        Task<Banco> GetBancoById(int id);
        Task<IEnumerable<Banco>> GetAll();
        Task DepositingMoney(Personaje personaje, Banco banco, double cantidad);
        Task TakingMoney(Personaje personaje, Banco banco, double cantidad);
    }
}