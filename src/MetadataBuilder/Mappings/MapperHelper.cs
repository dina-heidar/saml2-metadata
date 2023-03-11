//// Copyright (c) 2022 Dina Heidar
//// Permission is hereby granted, free of charge, to any person obtaining a copy
//// of this software and associated documentation files (the "Software"), to deal
//// in the Software without restriction, including without limitation the rights
//// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//// copies of the Software, and to permit persons to whom the Software is
//// furnished to do so, subject to the following conditions:
////
//// The above copyright notice and this permission notice shall be included in all
//// copies or substantial portions of the Software.
////
//// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY
////
//// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM
////
//// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//// SOFTWARE.
////

//using System.Security.Cryptography.X509Certificates;
//using AutoMapper;
//using MetadataBuilder.Schema.Metadata;
//using Saml.MetadataBuilder;
//using Saml.MetadataBuilder.Mappings;

//namespace MetadataBuilder.Mappings;

//public static class MapperHelper
//{
//    static IMapper staticMapper;

//    static MapperHelper()
//    {
//        var config = new MapperConfiguration(cfg =>
//        {
//            cfg.AddProfile<Saml.MetadataBuilder.Mappings.BaseMapper>();
//            cfg.AddProfile<Saml.MetadataBuilder.Mappings.EntityDescriptorMapper>();
//            cfg.AddProfile<Saml.MetadataBuilder.Mappings.EntityDescriptorMapper>();

//            cfg.AddProfile<Saml.MetadataBuilder.Mappings.SpSsoDescriptorMapper>();

//            cfg.AddProfile<Saml.MetadataBuilder.Mappings.SsoDescriptorMapper>();

//            cfg.AddProfile<Saml.MetadataBuilder.Mappings.RoleMapper>();
//            cfg.AddProfile<MetadataBuilder.Mappings.RichSpMetadataMapper>();

//            //cfg.CreateMap<ContactPerson, ContactType>()
//            //  .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Company))
//            //  .ForMember(dest => dest.contactType, opt => opt.MapFrom(src => src.ContactType))
//            //  .ForMember(dest => dest.GivenName, opt => opt.MapFrom(src => src.GivenName))
//            //  .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => new[] { src.EmailAddresses }))
//            //  .ForMember(dest => dest.SurName, opt => opt.MapFrom(src => src.Surname))
//            //  .ForMember(dest => dest.TelephoneNumber, opt => opt.MapFrom(src => new[] { src.TelephoneNumbers }))
//            //  .ReverseMap();

//            //cfg.CreateMap<Endpoint, EndpointType>()
//            //  .ForMember(dest => dest.Binding, opt => opt.MapFrom(src => src.Binding))
//            //  .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
//            //  .ForMember(dest => dest.ResponseLocation, opt => opt.MapFrom(src => src.ResponseLocation))
//            //  .ForMember(dest => dest.ResponseLocation, opt => opt.MapFrom(src => src.ResponseLocation))
//            //  .ReverseMap();

//            //cfg.CreateMap<IndexedEndpoint, IndexedEndpointType>()
//            //    .ForMember(dest => dest.Binding, opt => opt.MapFrom(src => src.Binding))
//            //    .ForMember(dest => dest.index, opt => opt.MapFrom(src => src.Index))
//            //    .ForMember(dest => dest.isDefault, opt => opt.MapFrom(src => src.IsDefault))
//            //    .ForMember(dest => dest.isDefaultSpecified, opt => opt.MapFrom(src => src.IsDefaultSpecified))
//            //    .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
//            //    .ForMember(dest => dest.ResponseLocation, opt => opt.MapFrom(src => src.ResponseLocation))
//            //    .ForMember(dest => dest.ResponseLocation, opt => opt.MapFrom(src => src.ResponseLocation))
//            //    .ReverseMap();

//            //cfg.CreateMap<LocalizedName, localizedNameType>()
//            //    .ForMember(dest => dest.lang, opt => opt.MapFrom(src => src.Language))
//            //    .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
//            //    .ReverseMap();

//            //cfg.CreateMap<LocalizedUri, localizedURIType>()
//            //    .ForMember(dest => dest.lang, opt => opt.MapFrom(src => src.Language))
//            //    .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Uri.ToString()))
//            //    .ReverseMap();

//            //cfg.CreateMap<Organization, OrganizationType>()
//            //    .ForMember(dest => dest.OrganizationName, opt => opt.MapFrom(src => src.OrganizationName))
//            //    .ForMember(dest => dest.OrganizationDisplayName, opt => opt.MapFrom(src => src.OrganizationDisplayName))
//            //    .ForMember(dest => dest.OrganizationURL, opt => opt.MapFrom(src => src.OrganizationURL))
//            //    .ReverseMap();

//            //cfg.CreateMap<BasicSpMetadata, RichSpMetadata>()
//            //     .ForMember(dest => dest.SingleLogoutServiceEndpoints, opt => opt.MapFrom(src => new Endpoint[] { src.SingleLogoutServiceEndpoint }))
//            //     .ForMember(dest => dest.AssertionConsumerServices, opt => opt.MapFrom(src => new IndexedEndpoint[] { src.AssertionConsumerService }))
//            //     .ForMember(dest => dest.ArtifactResolutionServices, opt => opt.MapFrom(src => new IndexedEndpoint[] { src.ArtifactResolutionService }))
//            //     .ForMember(dest => dest.EncryptingCertificates, opt => opt.MapFrom(src => new EncryptingCertificate[] { src.EncryptingCertificate }))
//            //     .ForMember(dest => dest.SigningCertificates, opt => opt.MapFrom(src => new X509Certificate2[] { src.SigningCertificate }))
//            //     .ForMember(dest => dest.AttributeConsumingService, opt => opt.MapFrom(src => src.AttributeConsumingService));

//        });

//        staticMapper = config.CreateMapper();
//    }

//    //First approach, create a mapper and use it from a static method
//    public static T MapFrom<T>(object entity)
//    {
//        return staticMapper.Map<T>(entity);
//    }

//    //Second approach (if users need to use their own types which are not known by this project)
//    //Create you own mapper interface ans return it
//    public static IMyMapper GetMapperFor<TSource, TDestination>()
//    {
//        var config = new MapperConfiguration(cfg =>
//        {
//            cfg.CreateMap<TSource, TDestination>();
//        });

//        var _mapper = config.CreateMapper();

//        return new MyMapper(_mapper);
//    }

//    //Third sample, create and use mapper inside a static helper method
//    //This is for mapping foreign types that this project does not 
//    //include (e.g POCO or model types in other projects)
//    public static TDestination Map<TDestination, TSource>(TSource entity)
//    {
//        var config = new MapperConfiguration(cfg =>
//        {
//            cfg.CreateMap<TSource, TDestination>();
//        });

//        var _mapper = config.CreateMapper();

//        return _mapper.Map<TDestination>(entity);
//    }
//}
