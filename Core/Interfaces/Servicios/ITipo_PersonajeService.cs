using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;

namespace Core.Interfaces.Servicios
{
    public interface ITipo_PersonajeService
    {
        Task<Tipo_Personaje> GetTipo_PersonajeById(int id);
        Task<IEnumerable<Tipo_Personaje>> GetAll();
        Task<Tipo_Personaje> CreateTipo_Personaje(Tipo_Personaje tipo_personaje);
        Task<Tipo_Personaje> UpdateTipo_Personaje(int id, Tipo_Personaje tipo_personaje);
        Task DeleteTipo_Personaje(int id);
    }
}