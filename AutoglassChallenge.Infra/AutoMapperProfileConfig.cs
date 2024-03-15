using AutoglassChallenge.Application.DTOs;
using AutoglassChallenge.Domain.Entities;
using AutoMapper;

namespace AutoglassChallenge.Infra
{
    public class AutoMapperProfileConfig : Profile
    {
        public AutoMapperProfileConfig()
        {
            MappingEntities();
        }

        private void MappingEntities()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<Supplier, SupplierDto>();
            CreateMap<SupplierDto, Supplier>();
        }

        public static MapperConfiguration CreateMapperConfiguration()
            => new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfileConfig());
            });
    }
}
