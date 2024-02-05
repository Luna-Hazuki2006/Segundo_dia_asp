using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Servicios;

namespace Services.Services
{
    public class MisionServicios : IMisionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MisionServicios(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Mision> CreateMision(Mision newMision)
        {
            MisionValidacion validator = new();

            var validationResult = await validator.ValidateAsync(newMision);
            if (validationResult.IsValid)
            {
                await _unitOfWork.MisionRepositorio.AddAsync(newMision);
                await _unitOfWork.CommitAsync();
            }
            else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return newMision;
        }

        public async Task DeleteMision(int MisionId)
        {
            Mision Mision = await _unitOfWork.MisionRepositorio.GetByIdAsync(MisionId);
            _unitOfWork.MisionRepositorio.Remove(Mision);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Mision>> GetAll()
        {
            return await _unitOfWork.MisionRepositorio.GetAllAsync();
        }

        public async Task<Mision> GetMisionById(int id)
        {
            return await _unitOfWork.MisionRepositorio.GetByIdAsync(id);
        }

        public async Task<Mision> UpdateMision(int MisionToBeUpdatedId, Mision newMisionValues)
        {
            MisionValidacion MisionValidator = new();
            
            var validationResult = await MisionValidacion.ValidateAsync(newMisionValues);
            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.ToString());

            Mision MisionToBeUpdated = await _unitOfWork.MisionRepositorio.GetByIdAsync(MisionToBeUpdatedId);

            if (MisionToBeUpdated == null)
                throw new ArgumentException("Invalid Mision ID while updating");

            MisionToBeUpdated.tipo = newMisionValues.tipo;
            MisionToBeUpdated.nombre = newMisionValues.tipo;

            await _unitOfWork.CommitAsync();

            return await _unitOfWork.MisionRepositorio.GetByIdAsync(MisionToBeUpdatedId);
        }
    }
}