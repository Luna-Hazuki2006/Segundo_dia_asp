using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces.Repositorios;
using Infrastructure.Data;

namespace Infrastructure.Repositorios
{
    public class RecompensaRepositorio : BaseRepositorio<Recompensa>, IRecompensaRepositorio
    {
        public RecompensaRepositorio(AppDbContext context) : base(context)
        {
        }
    }
}