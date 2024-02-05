using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces;
using Core.Servicios;
using Services.validators;

namespace Services.Services
{
    public class PersonajeServicios : IPersonajeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersonajeServicios(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Personaje> CreatePersonaje(Personaje newPersonaje)
        {
            PersonajeValidacion validator = new();

            var validationResult = await validator.ValidateAsync(newPersonaje);
            if (validationResult.IsValid)
            {
                await _unitOfWork.PersonajeRepositorio.AddAsync(newPersonaje);
                await _unitOfWork.CommitAsync();
            }
            else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return newPersonaje;
        }

        public async Task DeletePersonaje(int PersonajeId)
        {
            Personaje Personaje = await _unitOfWork.PersonajeRepositorio.GetByIdAsync(PersonajeId);
            _unitOfWork.PersonajeRepositorio.Remove(Personaje);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Personaje>> GetAll()
        {
            return await _unitOfWork.PersonajeRepositorio.GetAllAsync();
        }

        public async Task<Personaje> GetPersonajeById(int id)
        {
            return await _unitOfWork.PersonajeRepositorio.GetByIdAsync(id);
        }

        public async Task<Personaje> UpdatePersonaje(int PersonajeToBeUpdatedId, Personaje newPersonajeValues)
        {
            PersonajeValidacion PersonajeValidator = new();
            
            var validationResult = await PersonajeValidacion.ValidateAsync(newPersonajeValues);
            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.ToString());

            Personaje PersonajeToBeUpdated = await _unitOfWork.PersonajeRepositorio.GetByIdAsync(PersonajeToBeUpdatedId);

            if (PersonajeToBeUpdated == null)
                throw new ArgumentException("Invalid Personaje ID while updating");

            PersonajeToBeUpdated.tipo = newPersonajeValues.tipo;
            PersonajeToBeUpdated.nombre = newPersonajeValues.tipo;

            await _unitOfWork.CommitAsync();

            return await _unitOfWork.PersonajeRepositorio.GetByIdAsync(PersonajeToBeUpdatedId);
        }

        public async Task<Personaje> LevelUp(int PersonajeToBeUpdatedId, Personaje personaje)
        {
            PersonajeValidacion PersonajeValidator = new();
            
            var validationResult = await PersonajeValidator.ValidateAsync(personaje);
            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.ToString());

            Personaje PersonajeToBeUpdated = await _unitOfWork.PersonajeRepositorio.GetByIdAsync(PersonajeToBeUpdatedId);

            if (PersonajeToBeUpdated == null)
                throw new ArgumentException("Invalid Personaje ID while updating");

            if (personaje.Experiencia >= (personaje.Nivel * 10))
            {
                PersonajeToBeUpdated.Nivel = personaje.Nivel + 1;
            }

            // PersonajeToBeUpdated.Defensa = personaje.Defensa;
            // PersonajeToBeUpdated.Resistencia = personaje.Resistencia;
            // PersonajeToBeUpdated.Experiencia = personaje.Experiencia;
            // PersonajeToBeUpdated.estamina = personaje.estamina;
            // PersonajeToBeUpdated.Fuerza = personaje.Fuerza;
            // PersonajeToBeUpdated.Inteligencia = personaje.Inteligencia;
            // PersonajeToBeUpdated.Nivel = personaje.Nivel;

            await _unitOfWork.CommitAsync();

            return await _unitOfWork.PersonajeRepositorio.GetByIdAsync(PersonajeToBeUpdatedId);
        }
    }
}