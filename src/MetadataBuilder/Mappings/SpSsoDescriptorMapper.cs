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

//using AutoMapper;
//using MetadataBuilder.Schema.Metadata;

//namespace Saml.MetadataBuilder.Mappings
//{
//    public class SpSsoDescriptorMapper : Profile
//    {
//        public SpSsoDescriptorMapper()
//        {
//            CreateMap<SPSSODescriptor, SPSSODescriptorType>()
//                .ForMember(dest => dest.AssertionConsumerService, opt => opt.MapFrom(src => src.AssertionConsumerServices))
//                .ForMember(dest => dest.AttributeConsumingService, opt => opt.MapFrom(src => src.AttributeConsumingService))
//                .ForMember(dest => dest.AuthnRequestsSigned, opt => opt.MapFrom(src => src.AuthnRequestsSigned))
//                .ForMember(dest => dest.AuthnRequestsSignedSpecified, opt => opt.MapFrom(src => src.AuthnRequestsSignedFieldSpecified))
//                .ForMember(dest => dest.ContactPerson, opt => opt.MapFrom(src => src.ContactPersons))
//                .ForMember(dest => dest.Extensions, opt => opt.MapFrom(src => src.Extensions))                  
//                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.Id))
//                .ForMember(dest => dest.Organization, opt => opt.MapFrom(src => src.Organization))
//                .ForMember(dest => dest.validUntil, opt => opt.MapFrom(src => src.ValidUntil))
//                .ForMember(dest => dest.validUntilSpecified, opt => opt.MapFrom(src => src.ValidUntilFieldSpecified))
//                .ForMember(dest => dest.WantAssertionsSigned, opt => opt.MapFrom(src => src.WantAssertionsSigned))
//                .ForMember(dest => dest.WantAssertionsSignedSpecified, opt => opt.MapFrom(src => src.WantAssertionsSignedFieldSpecified));

//            CreateMap<AttributeConsumingService, AttributeConsumingServiceType>()
//                .ForMember(dest => dest.index, opt => opt.MapFrom(src => src.Index))
//                .ForMember(dest => dest.isDefault, opt => opt.MapFrom(src => src.IsDefault))
//                .ForMember(dest => dest.isDefaultSpecified, opt => opt.MapFrom(src => src.IsDefaultFieldSpecified))
//                .ForMember(dest => dest.ServiceName, opt => opt.MapFrom(src => src.ServiceNames))
//                .ForMember(dest => dest.ServiceDescription, opt => opt.MapFrom(src => src.ServiceDescriptions))
//                .ForMember(dest => dest.RequestedAttribute, opt => opt.MapFrom(src => src.RequestedAttributes))
//                .ReverseMap();

//            CreateMap<RequestedAttribute, RequestedAttributeType>()
//                .ForMember(dest => dest.AttributeValue, opt => opt.MapFrom(src => src.AttributeValue))
//                .ForMember(dest => dest.FriendlyName, opt => opt.MapFrom(src => src.FriendlyName))
//                .ForMember(dest => dest.isRequired, opt => opt.MapFrom(src => src.IsRequiredField))
//                .ForMember(dest => dest.isRequiredSpecified, opt => opt.MapFrom(src => src.IsRequiredFieldSpecified))
//                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
//                .ForMember(dest => dest.NameFormat, opt => opt.MapFrom(src => src.NameFormat))
//                .ReverseMap();
//        }
//    }
//}
