using Core.Entidades;
using Core.Interfaces.Repositorios;
using Infrastructure.Data;

namespace Infrastructure.Repositorios
{
    public class PersonajeRepositorio : BaseRepositorio<Personaje>, IPersonajeRepositorio
    {
        public PersonajeRepositorio(AppDbContext context) : base(context) {

        }

        public virtual async Task LevelUp(Personaje personaje) {
            dbSet.Attach(personaje);
            // Context.Entry(personaje).State = personaje.Modified;
        }

        public Task ModifyAgility(Personaje personaje)
        {
            throw new NotImplementedException();
        }

        public Task ModifyInteligence(Personaje personaje)
        {
            throw new NotImplementedException();
        }

        public Task ModifyLevel(Personaje personaje)
        {
            throw new NotImplementedException();
        }

        public Task ModifyLife(Personaje personaje)
        {
            throw new NotImplementedException();
        }

        public Task ModifyMagic(Personaje personaje)
        {
            throw new NotImplementedException();
        }

        public Task ModifyStrenght(Personaje personaje)
        {
            throw new NotImplementedException();
        }
    }
}