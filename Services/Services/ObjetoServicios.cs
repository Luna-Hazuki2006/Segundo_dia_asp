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
    public class ObjetoServicios : IObjetoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ObjetoServicios(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Objeto> ChangingValue(Objeto objeto, double valor)
        {
            throw new NotImplementedException();
        }

        public async Task<Objeto> CreateObjeto(Objeto newObjeto)
        {
            ObjetoValidacion validator = new();

            var validationResult = await validator.ValidateAsync(newObjeto);
            if (validationResult.IsValid)
            {
                await _unitOfWork.ObjetoRepositorio.AddAsync(newObjeto);
                await _unitOfWork.CommitAsync();
            }
            else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return newObjeto;
        }

        public async Task DeleteObjeto(int ObjetoId)
        {
            Objeto Objeto = await _unitOfWork.ObjetoRepositorio.GetByIdAsync(ObjetoId);
            _unitOfWork.ObjetoRepositorio.Remove(Objeto);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Objeto>> GetAll()
        {
            return await _unitOfWork.ObjetoRepositorio.GetAllAsync();
        }

        public async Task<Objeto> GetObjetoById(int id)
        {
            return await _unitOfWork.ObjetoRepositorio.GetByIdAsync(id);
        }

        public async Task<Objeto> UpdateObjeto(int ObjetoToBeUpdatedId, Objeto newObjetoValues)
        {
            ObjetoValidacion ObjetoValidator = new();
            
            var validationResult = await ObjetoValidator.ValidateAsync(newObjetoValues);
            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.ToString());

            Objeto ObjetoToBeUpdated = await _unitOfWork.ObjetoRepositorio.GetByIdAsync(ObjetoToBeUpdatedId);

            if (ObjetoToBeUpdated == null)
                throw new ArgumentException("Invalid Objeto ID while updating");

            // ObjetoToBeUpdated.tipo = newObjetoValues.tipo;
            // ObjetoToBeUpdated.nombre = newObjetoValues.tipo;

            await _unitOfWork.CommitAsync();

            return await _unitOfWork.ObjetoRepositorio.GetByIdAsync(ObjetoToBeUpdatedId);
        }

        Task<IEnumerable<Objeto>> IObjetoService.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}