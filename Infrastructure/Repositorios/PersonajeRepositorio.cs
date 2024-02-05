using Core.Entidades;
using Core.Interfaces.Repositorios;
using Infrastructure.Data;

namespace Infrastructure.Repositorios
{
    public class PersonajeRepositorio : BaseRepositorio<Personaje>, IPersonajeRepositorio
    {
        public PersonajeRepositorio(AppDbContext context) : base(context) {

        }
    }
}