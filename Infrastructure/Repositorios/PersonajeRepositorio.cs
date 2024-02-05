using Core.Entidades;
using Infrastructure.Data;

namespace Infrastructure.Repositorios
{
    public class PersonajeRepositorio : BaseRepositorio<Personaje>
    {
        public PersonajeRepositorio(AppDbContext context) : base(context) {
            
        }
    }
}