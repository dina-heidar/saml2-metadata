using AutoMapper;
using MetadataBuilder;
using Microsoft.Extensions.DependencyInjection;

namespace Saml.MetadataBuilder
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSamlMetadatBuilder(this IServiceCollection services)
        {
            services.AddScoped<IWriter, Writer>();
            services.AddScoped<IMapper>();
        }
    }
}
