using AutoMapper;
using MetadataBuilder.Constants;
using MetadataBuilder.Schema.Metadata;
using Microsoft.IdentityModel.Xml;
using System;

namespace Saml.MetadataBuilder
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Endpoint, EndpointType>();
            CreateMap<IndexedEndpoint, IndexedEndpointType>();

            CreateMap<AuthenticationContext, RequestedAuthnContextType>()
                .ForMember(dest => dest.ComparisonSpecified, opt => opt.MapFrom(src => src.ComparisonSpecified))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.AuthnContextRefTypes))
                .ForMember(dest => dest.ItemsElementName, opt => opt.MapFrom(src => src.AuthnContextClassRef))
                .ForMember(dest => dest.Comparison, opt => opt.MapFrom(src => Enum.GetName(typeof(AuthnContextComparisonType), src.ComparisonType)));

            CreateMap<ServiceProviderMetadata, EntityDescriptorType>()
                .ForMember(dest => dest.entityID, opt => opt.MapFrom(src => src.EntityId))
                .ForMember(dest => dest.Organization, opt => opt.MapFrom(src => src.Organization))
                .ForMember(dest => dest.Extensions, opt => opt.MapFrom(src => src.Extensions));

            CreateMap<LocalizedName, localizedNameType>()
                .ForMember(dest => dest.lang, opt => opt.MapFrom(src => src.Language))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value));

            CreateMap<LocalizedUri, localizedURIType>()
               .ForMember(dest => dest.lang, opt => opt.MapFrom(src => src.Language))
               .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Uri.ToString()));

            CreateMap<Organization, OrganizationType>()
                 .ForMember(dest => dest.OrganizationName, opt => opt.MapFrom(src => src.OrganizationName));

            CreateMap<Extension, ExtensionsType>()
                .ForMember(dest => dest.Any, opt => opt.MapFrom(src => src.UiInfo));

            CreateMap<KeyDescriptor, KeyDescriptorType>()
                  .ForMember(dest => dest.KeyInfo, opt => opt.MapFrom(src => src.KeyInfo))
                  .ForMember(dest => dest.useSpecified, opt => opt.MapFrom(src => src.UseSpecified))
                  .ForMember(dest => dest.use, opt => opt.MapFrom(src => src.KeyType))
                  .ForMember(dest => dest.useSpecified, opt => opt.MapFrom(src => src.UseSpecified));

            CreateMap<KeyInfo, KeyInfoType>()
                 .ForMember(dest => dest.ItemsElementName, opt => opt.MapFrom(src => src.KeyName))
                 .ForPath(dest => dest.Items, opt => opt.MapFrom(src => src.X509Data));


            CreateMap<X509Data, X509DataType>()
                 .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Certificates))
                 .ForMember(dest => dest.ItemsElementName, opt => opt.MapFrom(src => X509DataTypes.X509Certificate));

            //CreateMap<Signature, SignatureType>()
            //     .ForMember(dest => dest.SignatureValue, opt => opt.MapFrom(src => src.SignatureValue))
            //     .ForMember(dest=>dest.SignedInfo, opt => opt.MapFrom(src => src.SignedInfo))
            //      .ForMember(dest => dest.KeyInfo, opt => opt.MapFrom(src => src.KeyInfo))
            //       .ForMember(dest => dest.Object, opt => opt.MapFrom(src => src.)

            //CreateMap<UiInfo, UIInfoType>()
            //    .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Logo))
            //    .ForMember(dest => dest.ItemsElementName, opt => opt.MapFrom(src => src.))


            CreateMap<Logo, LogoType>()
                 .ForMember(dest => dest.width, opt => opt.MapFrom(src => src.Width))
                 .ForMember(dest => dest.height, opt => opt.MapFrom(src => src.Height))
                 .ForMember(dest => dest.lang, opt => opt.MapFrom(src => src.Language))
                 .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value));





        }
    }
}
