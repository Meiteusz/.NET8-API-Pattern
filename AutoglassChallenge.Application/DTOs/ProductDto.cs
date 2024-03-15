using AutoglassChallenge.Domain.Enums;
using System.Text.Json.Serialization;

namespace AutoglassChallenge.Application.DTOs
{
    public class ProductDto
    {
        [JsonIgnore]
        public long Id { get; set; }

        public string Description { get; set; }
        public eProductStatus Status { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public long SupplierId { get; set; }
    }
}
