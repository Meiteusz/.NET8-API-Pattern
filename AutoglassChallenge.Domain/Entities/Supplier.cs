namespace AutoglassChallenge.Domain.Entities
{
    public class Supplier : EntityBase
    {
        public string Description { get; set; }
        public string Cnpj { get; set; }

        public IList<Product> Products { get; set; }
    }
}
