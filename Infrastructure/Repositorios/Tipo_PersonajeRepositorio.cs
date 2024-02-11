using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces.Repositorios;
using Infrastructure.Data;

namespace Infrastructure.Repositorios
{
    public class Tipo_PersonajeRepositorio : BaseRepositorio<Tipo_Personaje>, ITipo_PersonajeRepositorio
    {
        public Tipo_PersonajeRepositorio(AppDbContext context) : base(context)
        {
        }
    }
}