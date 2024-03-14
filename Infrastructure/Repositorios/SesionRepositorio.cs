using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces.Repositorios;
using Infrastructure.Data;

namespace Infrastructure.Repositorios
{
    public class SesionRepositorio : BaseRepositorio<Sesion>, ISesionRepositorio
    {
        public SesionRepositorio(AppDbContext context) : base(context)
        {
        }
    }
}