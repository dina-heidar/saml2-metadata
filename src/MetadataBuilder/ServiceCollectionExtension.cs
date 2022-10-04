using MetadataBuilder.Schema.Metadata;
using Microsoft.Extensions.DependencyInjection;

namespace Saml.MetadataBuilder
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the saml metadat builder.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddSamlMetadatBuilder(this IServiceCollection services)
        {
            services.AddScoped<IMetadataWriter, MedataWriter>();
            services.AddScoped<IMetadataReader, MetadataReader>();

            //mappers
            services.AddTransient<IMetadataMapper<EntityDescriptor, EntityDescriptorType>, EntityDescriptorTypeMapper>();
            services.AddTransient<IMetadataMapper<EntityDescriptorType, EntityDescriptor>, EntityDescriptorMapper>();

        }
    }
}
