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
            Personaje personaje = await _unitOfWork.PersonajeRepositorio.GetByIdAsync(PersonajeId);
            _unitOfWork.PersonajeRepositorio.Remove(personaje);
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
            
            var validationResult = await PersonajeValidator.ValidateAsync(newPersonajeValues);
            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.ToString());

            Personaje PersonajeToBeUpdated = await _unitOfWork.PersonajeRepositorio.GetByIdAsync(PersonajeToBeUpdatedId);

            if (PersonajeToBeUpdated == null)
                throw new ArgumentException("Invalid Personaje ID while updating");

            PersonajeToBeUpdated.Nombre = newPersonajeValues.Nombre;

            await _unitOfWork.CommitAsync();

            return await _unitOfWork.PersonajeRepositorio.GetByIdAsync(PersonajeToBeUpdatedId);
        }

        
        public async Task<Personaje> LevelUp(Personaje personaje)
        {
            PersonajeValidacion PersonajeValidator = new();
            
            var validationResult = await PersonajeValidator.ValidateAsync(personaje);
            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.ToString());

            Personaje PersonajeToBeUpdated = await _unitOfWork.PersonajeRepositorio.GetByIdAsync(personaje.Id);

            if (PersonajeToBeUpdated == null)
                throw new ArgumentException("Invalid Personaje ID while updating");

            if (personaje.Experiencia >= (personaje.Nivel * 10))
            {
                PersonajeToBeUpdated.Nivel = personaje.Nivel + 1;
                PersonajeToBeUpdated.Fuerza = personaje.Fuerza + 10;
                PersonajeToBeUpdated.Inteligencia = personaje.Inteligencia + 10.5;
                PersonajeToBeUpdated.Agilidad = personaje.Agilidad + 7.5;
            }

            await _unitOfWork.CommitAsync();

            return await _unitOfWork.PersonajeRepositorio.GetByIdAsync(personaje.Id);
        }

        public Task<Personaje> LosingLife(Personaje personaje, double vida_perdida)
        {
            throw new NotImplementedException();
        }

        public Task<Personaje> GainingLife(Personaje personaje, double vida_ganada)
        {
            throw new NotImplementedException();
        }

        public Task<Personaje> UsingMagic(Personaje personaje, double magia)
        {
            throw new NotImplementedException();
        }

        public Task<Personaje> LosingMagic(Personaje personaje, double magia)
        {
            throw new NotImplementedException();
        }

        public Task<Personaje> GainingStrenght(Personaje personaje, double puntos)
        {
            throw new NotImplementedException();
        }

        public Task<Personaje> LosingStrenght(Personaje personaje, double puntos)
        {
            throw new NotImplementedException();
        }

        public Task<Personaje> GainingAgility(Personaje personaje, double puntos)
        {
            throw new NotImplementedException();
        }

        public Task<Personaje> LosingAgility(Personaje personaje, double puntos)
        {
            throw new NotImplementedException();
        }

        public Task<Personaje> GainingInteligence(Personaje personaje, double puntos)
        {
            throw new NotImplementedException();
        }

        public Task<Personaje> LosingInteligence(Personaje personaje, double puntos)
        {
            throw new NotImplementedException();
        }
    }
}