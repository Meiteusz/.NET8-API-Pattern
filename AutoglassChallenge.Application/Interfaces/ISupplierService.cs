using AutoglassChallenge.Application.DTOs;

namespace AutoglassChallenge.Application.Interfaces
{
    public interface ISupplierService
    {
        long CreateSupplier(SupplierDto supplierDto);
        SupplierDto GetSupplierById(long supplierId);
        IEnumerable<SupplierDto> GetSuppliersFromPagination(int pageNumber, int pageSize);
        void UpdateSupplier(long supplierId, SupplierDto supplierDto);
        void DeleteSupplier(long supplierId);
    }
}
