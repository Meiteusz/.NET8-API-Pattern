using AutoglassChallenge.Application.CustomExceptions;
using AutoglassChallenge.Application.DTOs;
using AutoglassChallenge.Application.Interfaces;
using AutoglassChallenge.Domain.Entities;
using AutoglassChallenge.Domain.Repositories;
using AutoglassChallenge.Utils;
using AutoMapper;

namespace AutoglassChallenge.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, ISupplierRepository supplierRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        private void Validate(ProductDto productDto)
        {
            if (productDto.ManufacturingDate >= productDto.ExpirationDate)
                throw new Exception("Data de fabricação não pode ser maior ou igual a data de validade!");

            if (productDto.SupplierId.IsIdInvalid())
                throw new Exception("Informe o ID válido para o fornecedor");

            if (_supplierRepository.GetById(productDto.SupplierId) == null)
                throw new RecordNotFoundException("Fornecedor informado não foi encontrado");
        }

        public long CreateProduct(ProductDto productDto)
        {
            try
            {
                Validate(productDto);

                var productEntity = _mapper.Map<Product>(productDto);

                return _productRepository.Create(productEntity);
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao criar o produto: {ex.Message}");
            }
        }

        public ProductDto GetProductById(long productId)
        {
            try
            {
                var product = _productRepository.GetById(productId);

                if (product == null)
                    throw new RecordNotFoundException("Produto não encontrado");

                var productDto = _mapper.Map<ProductDto>(product);

                return productDto;

            }
            catch (RecordNotFoundException ex)
            {
                throw new RecordNotFoundException($"Falha ao obter produto: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao obter produto: {ex.Message}");
            }
        }

        public IEnumerable<ProductDto> GetProductsFromPagination(int pageNumber, int pageSize)
        {
            try
            {
                var products = _productRepository.GetFromPagination(pageNumber, pageSize);

                var productDtoList = _mapper.Map<IList<ProductDto>>(products);

                return productDtoList;

            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao obter produtos: {ex.Message}");
            }
        }

        public void UpdateProduct(long productId, ProductDto productDto)
        {
            try
            {
                if (productId.IsIdInvalid())
                    throw new Exception("ID do produto informado é inválido.");

                if (_productRepository.GetById(productId) == null)
                    throw new RecordNotFoundException($"Produto com ID {productId} não encontrado.");

                Validate(productDto);

                productDto.Id = productId;

                var productEntity = _mapper.Map<Product>(productDto);

                _productRepository.Update(productEntity);
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao atualizar o produto: {ex.Message}");
            }
        }

        public void DeleteProduct(long productId)
        {
            try
            {
                if (productId.IsIdInvalid())
                    throw new Exception("ID do produto informado é inválido.");

                if (_productRepository.GetById(productId) == null)
                    throw new RecordNotFoundException($"Produto com ID {productId} não encontrado.");

                _productRepository.Delete(productId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao remover o produto: {ex.Message}");
            }
        }
    }
}
