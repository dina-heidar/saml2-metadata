using MetadataBuilder;
using MetadataBuilder.Dto;
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
            services.AddScoped<IMedatataWriter, MedatataWriter>();

            //mappers
            services.AddTransient<IMetadataMapper<EntityDescriptor, EntityDescriptorType>, MetadataMapper>();            
            
        }
    }
}
