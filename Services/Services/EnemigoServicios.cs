using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Servicios;

namespace Services.Services
{
    public class EnemigoServicios : IEnemigoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EnemigoServicios(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Enemigo> CreateEnemigo(Enemigo newEnemigo)
        {
            EnemigoValidacion validator = new();

            var validationResult = await validator.ValidateAsync(newEnemigo);
            if (validationResult.IsValid)
            {
                await _unitOfWork.EnemigoRepositorio.AddAsync(newEnemigo);
                await _unitOfWork.CommitAsync();
            }
            else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return newEnemigo;
        }

        public async Task DeleteEnemigo(int EnemigoId)
        {
            Enemigo Enemigo = await _unitOfWork.EnemigoRepositorio.GetByIdAsync(EnemigoId);
            _unitOfWork.EnemigoRepositorio.Remove(Enemigo);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Enemigo>> GetAll()
        {
            return await _unitOfWork.EnemigoRepositorio.GetAllAsync();
        }

        public async Task<Enemigo> GetEnemigoById(int id)
        {
            return await _unitOfWork.EnemigoRepositorio.GetByIdAsync(id);
        }

        public async Task<Enemigo> UpdateEnemigo(int EnemigoToBeUpdatedId, Enemigo newEnemigoValues)
        {
            EnemigoValidacion EnemigoValidator = new();
            
            var validationResult = await EnemigoValidacion.ValidateAsync(newEnemigoValues);
            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.ToString());

            Enemigo EnemigoToBeUpdated = await _unitOfWork.EnemigoRepositorio.GetByIdAsync(EnemigoToBeUpdatedId);

            if (EnemigoToBeUpdated == null)
                throw new ArgumentException("Invalid Enemigo ID while updating");

            EnemigoToBeUpdated.tipo = newEnemigoValues.tipo;
            EnemigoToBeUpdated.nombre = newEnemigoValues.tipo;

            await _unitOfWork.CommitAsync();

            return await _unitOfWork.EnemigoRepositorio.GetByIdAsync(EnemigoToBeUpdatedId);
        }

        public async Task<Enemigo> Attacking(Enemigo enemigo, Personaje personaje) {
            
        }
    }
}