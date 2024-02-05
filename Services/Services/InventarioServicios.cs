using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Servicios;

namespace Services.Services
{
    public class InventarioServicios : IInventarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        public InventarioServicios(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Inventario> CreateInventario(Inventario newInventario)
        {
            InventarioValidacion validator = new();

            var validationResult = await validator.ValidateAsync(newInventario);
            if (validationResult.IsValid)
            {
                await _unitOfWork.InventarioRepositorio.AddAsync(newInventario);
                await _unitOfWork.CommitAsync();
            }
            else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return newInventario;
        }

        public async Task DeleteInventario(int InventarioId)
        {
            Inventario Inventario = await _unitOfWork.InventarioRepositorio.GetByIdAsync(InventarioId);
            _unitOfWork.InventarioRepositorio.Remove(Inventario);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Inventario>> GetAll()
        {
            return await _unitOfWork.InventarioRepositorio.GetAllAsync();
        }

        public async Task<Inventario> GetInventarioById(int id)
        {
            return await _unitOfWork.InventarioRepositorio.GetByIdAsync(id);
        }

        public async Task<Inventario> UpdateInventario(int InventarioToBeUpdatedId, Inventario newInventarioValues)
        {
            InventarioValidacion InventarioValidator = new();
            
            var validationResult = await InventarioValidacion.ValidateAsync(newInventarioValues);
            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.ToString());

            Inventario InventarioToBeUpdated = await _unitOfWork.InventarioRepositorio.GetByIdAsync(InventarioToBeUpdatedId);

            if (InventarioToBeUpdated == null)
                throw new ArgumentException("Invalid Inventario ID while updating");

            InventarioToBeUpdated.tipo = newInventarioValues.tipo;
            InventarioToBeUpdated.nombre = newInventarioValues.tipo;

            await _unitOfWork.CommitAsync();

            return await _unitOfWork.InventarioRepositorio.GetByIdAsync(InventarioToBeUpdatedId);
        }
    }
}