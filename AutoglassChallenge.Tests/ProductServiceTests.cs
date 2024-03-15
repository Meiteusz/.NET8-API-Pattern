using AutoglassChallenge.Application.DTOs;
using AutoglassChallenge.Application.Services;
using AutoglassChallenge.Domain.Entities;
using AutoglassChallenge.Domain.Repositories;
using AutoglassChallenge.Infra.Repositories;
using AutoMapper;
using NSubstitute;

namespace AutoglassChallenge.Tests
{
    [TestClass]
    public class ProductServiceTests
    {
        private IProductRepository _productRepositoryMock;
        private ISupplierRepository _supplierRepositoryMock;
        private IMapper _mapperMock;
        private ProductService _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _productRepositoryMock = Substitute.For<IProductRepository>();
            _supplierRepositoryMock = Substitute.For<ISupplierRepository>();
            _mapperMock = Substitute.For<IMapper>();

            _sut = new ProductService(_productRepositoryMock, _supplierRepositoryMock, _mapperMock);
        }

        [TestMethod]
        public void CreateProduct_ValidManufacturingDate_ReturnsProductId()
        {
            // Arrange
            var productDto = new ProductDto
            {
                ManufacturingDate = DateTime.Now.AddDays(-1),
                ExpirationDate = DateTime.Now.AddDays(10),
                SupplierId = 1
            };

            var supplierMock = new Supplier
            {
                Description = "Fornecedor mock",
                Cnpj = "00.000.000/0000-00",
            };

            _productRepositoryMock.Create(Arg.Any<Product>()).Returns(1);
            _supplierRepositoryMock.GetById(Arg.Any<long>()).Returns(supplierMock);

            // Act
            var productId = _sut.CreateProduct(productDto);

            // Assert
            Assert.AreEqual(1, productId);
        }

        [TestMethod]
        public void CreateProduct_InvalidManufacturingDate_ReturnsException()
        {
            // Arrange
            var productDto = new ProductDto
            {
                ManufacturingDate = DateTime.Now.AddDays(1),
                ExpirationDate = DateTime.Now,
                SupplierId = 1
            };

            _productRepositoryMock.Create(Arg.Any<Product>()).Returns(1);

            // Act - Assert
            Assert.ThrowsException<Exception>(() => _sut.CreateProduct(productDto));
        }

        [TestMethod]
        public void CreateProduct_InvalidSupplierId_ReturnsException()
        {
            // Arrange
            var productDto = new ProductDto
            {
                ManufacturingDate = DateTime.Now.AddDays(-1),
                ExpirationDate = DateTime.Now.AddDays(10),
                SupplierId = -1
            };

            _productRepositoryMock.Create(Arg.Any<Product>()).Returns(1);

            // Act - Assert
            Assert.ThrowsException<Exception>(() => _sut.CreateProduct(productDto));
        }

        [TestMethod]
        public void CreateProduct_SupplierIdNoExistent_ReturnsException()
        {
            // Arrange
            var productDto = new ProductDto
            {
                ManufacturingDate = DateTime.Now.AddDays(-1),
                ExpirationDate = DateTime.Now.AddDays(10),
                SupplierId = 999
            };

            _productRepositoryMock.Create(Arg.Any<Product>()).Returns(1);

            // Act - Assert
            Assert.ThrowsException<Exception>(() => _sut.CreateProduct(productDto));
        }
    }
}