using AutoglassChallenge.Application.CustomExceptions;
using AutoglassChallenge.Application.Services;
using AutoglassChallenge.Domain.Repositories;
using AutoMapper;
using NSubstitute;

namespace AutoglassChallenge.Tests
{
    [TestClass]
    public class SupplierServiceTests
    {
        private IProductRepository _productRepositoryMock;
        private ISupplierRepository _supplierRepositoryMock;
        private IMapper _mapperMock;
        private SupplierService _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _productRepositoryMock = Substitute.For<IProductRepository>();
            _supplierRepositoryMock = Substitute.For<ISupplierRepository>();
            _mapperMock = Substitute.For<IMapper>();

            _sut = new SupplierService(_supplierRepositoryMock, _productRepositoryMock, _mapperMock);
        }

        [TestMethod]
        public void GetSupplierById_ValidManufacturingDate_ReturnsProductId()
        {
            // Arrange
            var supplierIdMock = 999;

            // Act - Assert
            Assert.ThrowsException<RecordNotFoundException>(() => _sut.GetSupplierById(supplierIdMock));
        }
    }
}
