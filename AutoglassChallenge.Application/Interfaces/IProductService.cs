using AutoglassChallenge.Application.DTOs;

namespace AutoglassChallenge.Application.Interfaces
{
    public interface IProductService
    {
        long CreateProduct(ProductDto productDto);
        ProductDto GetProductById(long productId);
        IEnumerable<ProductDto> GetProductsFromPagination(int pageNumber, int pageSize);
        void UpdateProduct(long productId, ProductDto productDto);
        void DeleteProduct(long productId);
    }
}
