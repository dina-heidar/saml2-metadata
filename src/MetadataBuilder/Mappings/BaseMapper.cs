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

//namespace Saml.MetadataBuilder.Mappings
//{
//    internal class BaseMapper : Profile
//    {
//        public BaseMapper()
//        {
//            CreateMap<ContactPerson, ContactType>()
//              .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Company))
//              .ForMember(dest => dest.contactType, opt => opt.MapFrom(src => src.ContactType))
//              .ForMember(dest => dest.GivenName, opt => opt.MapFrom(src => src.GivenName))
//              .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => new[] { src.EmailAddresses }))
//              .ForMember(dest => dest.SurName, opt => opt.MapFrom(src => src.Surname))
//              .ForMember(dest => dest.TelephoneNumber, opt => opt.MapFrom(src => new[] { src.TelephoneNumbers }))
//              .ReverseMap();

//            CreateMap<Endpoint, EndpointType>()
//              .ForMember(dest => dest.Binding, opt => opt.MapFrom(src => src.Binding))
//              .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
//              .ForMember(dest => dest.ResponseLocation, opt => opt.MapFrom(src => src.ResponseLocation))
//              .ForMember(dest => dest.ResponseLocation, opt => opt.MapFrom(src => src.ResponseLocation))
//              .ReverseMap();

//            CreateMap<IndexedEndpoint, IndexedEndpointType>()
//                .ForMember(dest => dest.Binding, opt => opt.MapFrom(src => src.Binding))
//                .ForMember(dest => dest.index, opt => opt.MapFrom(src => src.Index))
//                .ForMember(dest => dest.isDefault, opt => opt.MapFrom(src => src.IsDefault))
//                .ForMember(dest => dest.isDefaultSpecified, opt => opt.MapFrom(src => src.IsDefaultSpecified))
//                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
//                .ForMember(dest => dest.ResponseLocation, opt => opt.MapFrom(src => src.ResponseLocation))
//                .ForMember(dest => dest.ResponseLocation, opt => opt.MapFrom(src => src.ResponseLocation))
//                .ReverseMap();

//            CreateMap<LocalizedName, localizedNameType>()
//                .ForMember(dest => dest.lang, opt => opt.MapFrom(src => src.Language))
//                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
//                .ReverseMap();

//            CreateMap<LocalizedUri, localizedURIType>()
//                .ForMember(dest => dest.lang, opt => opt.MapFrom(src => src.Language))
//                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Uri.ToString()))
//                .ReverseMap();

//            CreateMap<Organization, OrganizationType>()
//                .ForMember(dest => dest.OrganizationName, opt => opt.MapFrom(src => src.OrganizationName))
//                .ForMember(dest => dest.OrganizationDisplayName, opt => opt.MapFrom(src => src.OrganizationDisplayName))
//                .ForMember(dest => dest.OrganizationURL, opt => opt.MapFrom(src => src.OrganizationURL))
//                .ReverseMap();

//            CreateMap<BasicSpMetadata, RichSpMetadata>()
//                 .ForMember(dest => dest.SingleLogoutServiceEndpoints, opt => opt.MapFrom(src => new Endpoint[] { src.SingleLogoutServiceEndpoint }))
//                 .ForMember(dest => dest.AssertionConsumerServices, opt => opt.MapFrom(src => new IndexedEndpoint[] { src.AssertionConsumerService }))
//                 .ForMember(dest => dest.ArtifactResolutionServices, opt => opt.MapFrom(src => new IndexedEndpoint[] { src.ArtifactResolutionService }))
//                 .ForMember(dest => dest.EncryptingCertificates, opt => opt.MapFrom(src => new EncryptingCertificate[] { src.EncryptingCertificate }))
//                 .ForMember(dest => dest.SigningCertificates, opt => opt.MapFrom(src => new X509Certificate2[] { src.SigningCertificate }))
//                 .ForMember(dest => dest.AttributeConsumingService, opt => opt.MapFrom(src => src.AttributeConsumingService));

//        }
//    }
//}

