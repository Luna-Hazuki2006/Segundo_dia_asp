using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces;
using Core.Interfaces.Servicios;
using Services.validators;

namespace Services.Services
{
    public class Tipo_PersonajeServicios : ITipo_PersonajeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public Tipo_PersonajeServicios(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Tipo_Personaje> CreateTipo_Personaje(Tipo_Personaje tipo_personaje)
        {
            Tipo_PersonajeValidacion validator = new();

            var validationResult = await validator.ValidateAsync(tipo_personaje);
            if (validationResult.IsValid)
            {
                await _unitOfWork.Tipo_PersonajeRepositorio.AddAsync(tipo_personaje);
                await _unitOfWork.CommitAsync();
            }
            else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return tipo_personaje;
        }

        public async Task DeleteTipo_Personaje(int id)
        {
            Tipo_Personaje tipo = await _unitOfWork.Tipo_PersonajeRepositorio.GetByIdAsync(id);
            _unitOfWork.Tipo_PersonajeRepositorio.Remove(tipo);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Tipo_Personaje>> GetAll()
        {
            return await _unitOfWork.Tipo_PersonajeRepositorio.GetAllAsync();
        }

        public async Task<Tipo_Personaje> GetTipo_PersonajeById(int id)
        {
            return await _unitOfWork.Tipo_PersonajeRepositorio.GetByIdAsync(id);
        }

        public async Task<Tipo_Personaje> UpdateTipo_Personaje(int id, Tipo_Personaje tipo_personaje)
        {
            Tipo_PersonajeValidacion Validator = new();
            
            var validationResult = await Validator.ValidateAsync(tipo_personaje);
            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.ToString());

            Tipo_Personaje TipoToBeUpdated = await _unitOfWork.Tipo_PersonajeRepositorio.GetByIdAsync(id);

            if (TipoToBeUpdated == null)
                throw new ArgumentException("Invalid Personaje ID while updating");

            TipoToBeUpdated.Nombre = tipo_personaje.Nombre;
            TipoToBeUpdated.Descripcion = tipo_personaje.Descripcion;

            await _unitOfWork.CommitAsync();

            return await _unitOfWork.Tipo_PersonajeRepositorio.GetByIdAsync(id);
        }
    }
}