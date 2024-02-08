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
        Task<Banco> CreateBanco(Banco Banco);
        Task<Banco> UpdateBanco(int id, Banco Banco);
        Task DeleteBanco(int id);
        Task<Banco> DepositingMoney(Personaje personaje, Banco banco, double cantidad);
        Task<Banco> TakingMoney(Personaje personaje, Banco banco, double cantidad);
    }
}

// todo esto es fácil solo has en 3 horas lo que no hiciste en 3 días ¯\_(ツ)_/¯