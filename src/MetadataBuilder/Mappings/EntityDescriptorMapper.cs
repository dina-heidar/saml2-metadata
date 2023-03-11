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

//using System.Collections.Generic;
//using System.Linq;
//using AutoMapper;
//using MetadataBuilder.Schema.Metadata;

//namespace Saml.MetadataBuilder.Mappings
//{
//    internal class EntityDescriptorMapper : Profile
//    {
//        public EntityDescriptorMapper()
//        {
//            CreateMap<AdditionalMetadataLocation, AdditionalMetadataLocationType>()
//               .ForMember(dest => dest.@namespace, opt => opt.MapFrom(src => src.Namespace))
//               .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
//               .ReverseMap();

//            CreateMap<EntityDescriptor, EntityDescriptorType>()
//                .ForMember(dest => dest.cacheDuration, opt => opt.MapFrom(src => src.CacheDuration))
//                .ForMember(dest => dest.ContactPerson, opt => opt.MapFrom(src => src.ContactPersons))
//                .ForMember(dest => dest.entityID, opt => opt.MapFrom(src => src.EntityID))
//                .ForMember(dest => dest.Organization, opt => opt.MapFrom(src => src.Organization))
//                .ForMember(dest => dest.validUntil, opt => opt.MapFrom(src => src.ValidUntil))
//                .ForMember(dest => dest.Items, opt => opt.MapFrom<ItemTypeResolver>())
//                .ForMember(dest => dest.Extensions, opt =>
//                 {
//                     opt.PreCondition(src => (src.Extensions != null));
//                     opt.MapFrom<ExtensionsTypeResolver>();
//                 })
//                .ForMember(dest => dest.AdditionalMetadataLocation, opt => opt.MapFrom(src => src.AdditionalMetadataLocations));
//        }
//        public class ItemTypeResolver : IValueResolver<EntityDescriptor, EntityDescriptorType, object[]>
//        {
//            public object[] Resolve(EntityDescriptor source, EntityDescriptorType destination,
//                object[] member, ResolutionContext context)
//            {
//                var items = new List<object>();

//                if (source.GetType() == typeof(BasicSpMetadata))
//                {
//                    var bsm = context.Mapper.Map<BasicSpMetadata, RichSpMetadata>(source as BasicSpMetadata);
//                    var spSsoDescriptor = context.Mapper.Map<RichSpMetadata, SPSSODescriptorType>(bsm);
//                    items.Add(spSsoDescriptor);
//                }
//                if (source.GetType() == typeof(RichSpMetadata))
//                {
//                    var spSsoDescriptor = context.Mapper.Map<RichSpMetadata, SPSSODescriptorType>(source as RichSpMetadata);
//                    items.Add(spSsoDescriptor);
//                }
//                return items.ToArray<object>();
//            }
//        }
//        public class ExtensionsTypeResolver : IValueResolver<EntityDescriptor, EntityDescriptorType, ExtensionsType>
//        {
//            public ExtensionsType Resolve(EntityDescriptor source, EntityDescriptorType destination,
//                ExtensionsType member, ResolutionContext context)
//            {

//                var extensions = new ExtensionsType();
//                var objectList = new List<object>();

//                foreach (var item in source.Extensions.Any)
//                {
//                    if (item.GetType() == typeof(DigestMethodType1))
//                    {
//                        var digestMethodType = (DigestMethodType1)item;
//                        var digestMethod = new DigestMethod();
//                        digestMethod.Algorithm = digestMethodType.Algorithm;
//                        objectList.Add(digestMethod);
//                    }
//                    if (item.GetType() == typeof(SigningMethod))
//                    {
//                        var signingMethodType = (SigningMethodType)item;
//                        var signingMethod = new SigningMethod
//                        {
//                            Algorithm = signingMethodType.Algorithm,
//                            MinKeySize = signingMethodType.MinKeySize,
//                            MaxKeySize = signingMethodType.MaxKeySize,
//                        };
//                        objectList.Add(signingMethod);
//                    }
//                }
//                extensions.Any = objectList.ToArray<object>();
//                return extensions;
//            }
//        }
//    }
//}
