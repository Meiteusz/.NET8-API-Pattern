using AutoglassChallenge.Application.CustomExceptions;
using AutoglassChallenge.Application.DTOs;
using AutoglassChallenge.Application.Interfaces;
using AutoglassChallenge.Domain.Entities;
using AutoglassChallenge.Domain.Repositories;
using AutoglassChallenge.Utils;
using AutoMapper;

namespace AutoglassChallenge.Application.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public SupplierService(ISupplierRepository supplierRepository, IProductRepository productRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public long CreateSupplier(SupplierDto supplierDto)
        {
            try
            {
                var supplierEntity = _mapper.Map<Supplier>(supplierDto);

                return _supplierRepository.Create(supplierEntity);
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao criar o fornecedor: {ex.Message}");
            }
        }

        public SupplierDto GetSupplierById(long supplierId)
        {
            try
            {
                var supplier = _supplierRepository.GetById(supplierId);

                if (supplier == null)
                    throw new RecordNotFoundException("Fornecedor não encontrado");

                var supplierDto = _mapper.Map<SupplierDto>(supplier);

                return supplierDto;

            }
            catch (RecordNotFoundException ex)
            {
                throw new RecordNotFoundException($"Falha ao obter fornecedor: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao obter fornecedor: {ex.Message}");
            }
        }

        public IEnumerable<SupplierDto> GetSuppliersFromPagination(int pageNumber, int pageSize)
        {
            try
            {
                var suppliers = _supplierRepository.GetFromPagination(pageNumber, pageSize);

                var supplierDtoList = _mapper.Map<IList<SupplierDto>>(suppliers);

                return supplierDtoList;

            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao obter fornecedor: {ex.Message}");
            }
        }

        public void UpdateSupplier(long supplierId, SupplierDto supplierDto)
        {
            try
            {
                if (supplierId.IsIdInvalid())
                    throw new Exception("ID do fornecedor informado é inválido.");

                if (_supplierRepository.GetById(supplierId) == null)
                    throw new RecordNotFoundException($"Fornecedor com ID {supplierId} não encontrado.");

                supplierDto.Id = supplierId;

                var supplierEntity = _mapper.Map<Supplier>(supplierDto);

                _supplierRepository.Update(supplierEntity);
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao atualizar o fornecedor: {ex.Message}");
            }
        }

        public void DeleteSupplier(long supplierId)
        {
            try
            {
                if (supplierId.IsIdInvalid())
                    throw new Exception("ID do fornecedor informado é inválido.");

                if (_supplierRepository.GetById(supplierId) == null)
                    throw new RecordNotFoundException($"Fornecedor com ID {supplierId} não encontrado.");

                if (_productRepository.ExistsProductBySupplierId(supplierId))
                    throw new Exception("O fornecedor com ID informado já está cadastrado em um produto.");

                _supplierRepository.Delete(supplierId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao remover o fornecedor: {ex.Message}");
            }
        }
    }
}
