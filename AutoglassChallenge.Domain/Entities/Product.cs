using AutoglassChallenge.Domain.Enums;

namespace AutoglassChallenge.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Description { get; set; }
        public eProductStatus Status { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public long SupplierId { get; set; }

        public Supplier Supplier { get; set; }
    }
}
