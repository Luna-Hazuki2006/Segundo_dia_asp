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
    public class TiendaServicios : ITiendaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TiendaServicios(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Tienda> CreateTienda(Tienda newTienda)
        {
            TiendaValidacion validator = new();

            var validationResult = await validator.ValidateAsync(newTienda);
            if (validationResult.IsValid)
            {
                await _unitOfWork.TiendaRepositorio.AddAsync(newTienda);
                await _unitOfWork.CommitAsync();
            }
            else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return newTienda;
        }

        public async Task DeleteTienda(int TiendaId)
        {
            Tienda Tienda = await _unitOfWork.TiendaRepositorio.GetByIdAsync(TiendaId);
            _unitOfWork.TiendaRepositorio.Remove(Tienda);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Tienda>> GetAll()
        {
            return await _unitOfWork.TiendaRepositorio.GetAllAsync();
        }

        public async Task<Tienda> GetTiendaById(int id)
        {
            return await _unitOfWork.TiendaRepositorio.GetByIdAsync(id);
        }

        public async Task<Tienda> UpdateTienda(int TiendaToBeUpdatedId, Tienda newTiendaValues)
        {
            TiendaValidacion TiendaValidator = new();
            
            var validationResult = await TiendaValidacion.ValidateAsync(newTiendaValues);
            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.ToString());

            Tienda TiendaToBeUpdated = await _unitOfWork.TiendaRepositorio.GetByIdAsync(TiendaToBeUpdatedId);

            if (TiendaToBeUpdated == null)
                throw new ArgumentException("Invalid Tienda ID while updating");

            TiendaToBeUpdated.tipo = newTiendaValues.tipo;
            TiendaToBeUpdated.nombre = newTiendaValues.tipo;

            await _unitOfWork.CommitAsync();

            return await _unitOfWork.TiendaRepositorio.GetByIdAsync(TiendaToBeUpdatedId);
        }
    }
}