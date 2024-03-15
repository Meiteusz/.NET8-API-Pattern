using AutoglassChallenge.Application.Interfaces;
using AutoglassChallenge.Application.Services;
using AutoglassChallenge.Domain.Repositories;
using AutoglassChallenge.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AutoglassChallenge.Infra.IoC
{
    public class Injector
    {
        public static void InjectIoCServices(IServiceCollection serviceColletion)
        {
            InjectRepositories(serviceColletion);
            InjectServices(serviceColletion);
        }

        private static void InjectRepositories(IServiceCollection serviceColletion)
        {
            serviceColletion.AddScoped<IProductRepository, ProductRepository>();
            serviceColletion.AddScoped<ISupplierRepository, SupplierRepository>();
        }

        private static void InjectServices(IServiceCollection serviceColletion)
        {
            serviceColletion.AddScoped<IProductService, ProductService>();
            serviceColletion.AddScoped<ISupplierService, SupplierService>();
        }
    }
}
