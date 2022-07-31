//using AutoMapper;
//using MetadataBuilder.Dto;
//using MetadataBuilder.Schema.Metadata;

//namespace Saml.MetadataBuilder
//{
//    public class MappingProfile : Profile
//    {
//        public MappingProfile()
//        {
//            CreateMap<SPMetadata, SPSSODescriptorType>()
//               //.ForMember(dest => dest.NameIDFormat, opt => opt.MapFrom(src => new[] { src.NameIdFormat }))
//               //.ForMember(dest => dest.Organization, opt => opt.MapFrom(src => src.Organization))
//               //.ForMember(dest => dest.Extensions, opt => opt.MapFrom(src => src.Extensions))
//               //.ForMember(dest => dest.AssertionConsumerService, opt => opt.MapFrom(src => src.AssertionConsumerServices))
//               //.ForMember(dest => dest.ArtifactResolutionService, opt => opt.MapFrom(src => src.ArtifactResolutionServices))
//               //.ForMember(dest => dest.SingleLogoutService, opt => opt.MapFrom(src => new[] { src.SingleLogoutServiceEndpoint }))
//               .ForMember(dest => dest.AuthnRequestsSigned, opt => opt.MapFrom(src => src.AuthnRequestsSigned))
//               .ForMember(dest => dest.WantAssertionsSigned, opt => opt.MapFrom(src => src.WantAssertionsSigned))
//               //.ForMember(dest => dest.cacheDuration, opt => opt.MapFrom(src => src.CacheDuration))
//               //.ForMember(dest => dest.ContactPerson, opt => opt.MapFrom(src => src.ContactPersons))
//               //.ForPath(dest => dest.protocolSupportEnumeration, opt => opt.MapFrom(src => new[] { src.RoleDescriptor.ProtocolSupportEnumeration }))
//               .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.Id))
//               //.ForPath(dest => dest.KeyDescriptor, opt => opt.MapFrom(src => new src.RoleDescriptor.KeyDescriptor))
//               //.ForMember(dest => dest.AttributeConsumingService, opt => opt.MapFrom(src => src.ServiceNames))
//               //.ForMember(dest => dest.AttributeConsumingService, opt => opt.MapFrom(src => src.ServiceDescriptions))
//               .ForAllMembers(c => c.Ignore());

//        //    CreateMap<LocalizedName[], AttributeConsumingService>()
//        //          .ForMember(dest => dest.ServiceNames, opt => opt.MapFrom(src => src));

//        //    CreateMap<LocalizedName[], AttributeConsumingService>()
//        //         .ForMember(dest => dest.ServiceDescriptions, opt => opt.MapFrom(src => src));

//        //    CreateMap<RequestedAttribute[], AttributeConsumingService>()
//        //        .ForMember(dest => dest.RequestedAttributes, opt => opt.MapFrom(src => src));
//        }
//    }

//}
