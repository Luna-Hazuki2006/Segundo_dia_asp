using Core.Entidades;

namespace Core.Servicios
{
    public interface IPersonajeService
    {
        Task<Personaje> GetPersonajeById(int id);
        Task<IEnumerable<Personaje>> GetAll();
    }
}