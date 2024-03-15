using System.Text.Json.Serialization;

namespace AutoglassChallenge.Application.DTOs
{
    public class SupplierDto
    {
        [JsonIgnore]
        public long Id { get; set; }

        public string Description { get; set; }
        public string Cnpj { get; set; }
    }
}
