using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Servicios;

namespace Services.Services
{
    public class BancoServicios : IBancoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BancoServicios(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Banco> CreateBanco(Banco newBanco)
        {
            BancoValidacion validator = new();

            var validationResult = await validator.ValidateAsync(newBanco);
            if (validationResult.IsValid)
            {
                await _unitOfWork.BancoRepositorio.AddAsync(newBanco);
                await _unitOfWork.CommitAsync();
            }
            else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return newBanco;
        }

        public async Task DeleteBanco(int BancoId)
        {
            Banco Banco = await _unitOfWork.BancoRepositorio.GetByIdAsync(BancoId);
            _unitOfWork.BancoRepositorio.Remove(Banco);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Banco>> GetAll()
        {
            return await _unitOfWork.BancoRepositorio.GetAllAsync();
        }

        public async Task<Banco> GetBancoById(int id)
        {
            return await _unitOfWork.BancoRepositorio.GetByIdAsync(id);
        }

        public async Task<Banco> UpdateBanco(int BancoToBeUpdatedId, Banco newBancoValues)
        {
            BancoValidacion BancoValidator = new();
            
            var validationResult = await BancoValidacion.ValidateAsync(newBancoValues);
            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.ToString());

            Banco BancoToBeUpdated = await _unitOfWork.BancoRepositorio.GetByIdAsync(BancoToBeUpdatedId);

            if (BancoToBeUpdated == null)
                throw new ArgumentException("Invalid Banco ID while updating");

            BancoToBeUpdated.tipo = newBancoValues.tipo;
            BancoToBeUpdated.nombre = newBancoValues.tipo;

            await _unitOfWork.CommitAsync();

            return await _unitOfWork.BancoRepositorio.GetByIdAsync(BancoToBeUpdatedId);
        }

    }
}