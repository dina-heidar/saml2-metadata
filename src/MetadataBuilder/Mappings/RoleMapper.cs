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
//using static MetadataBuilder.Mappings.RichSpMetadataMapper;

//namespace Saml.MetadataBuilder.Mappings
//{
//    internal class RoleMapper : Profile
//    {
//        public RoleMapper()
//        {
//            CreateMap<RoleDescriptor, RoleDescriptorType>()
//                .ForMember(dest => dest.cacheDuration, opt => opt.MapFrom(src => src.CacheDuration))
//                .ForMember(dest => dest.protocolSupportEnumeration, opt => opt.MapFrom(src => new[] { src.ProtocolSupportEnumeration }))
//                .ForMember(dest => dest.errorURL, opt => opt.MapFrom(src => src.ErrorUrlField))
//                .ForMember(dest => dest.Extensions, opt =>
//                {
//                    opt.PreCondition(src => (src.Extensions != null));
//                    opt.MapFrom<ExtensionsTypeResolver>();
//                });             
//        }
//        public class ExtensionsTypeResolver : IValueResolver<RoleDescriptor, RoleDescriptorType, ExtensionsType>
//        {
//            public ExtensionsType Resolve(RoleDescriptor source, RoleDescriptorType destination,
//                ExtensionsType member, ResolutionContext context)
//            {
//                var extensions = new ExtensionsType();
//                var objectList = new List<object>();

//                foreach (var item in source.Extensions.Any)
//                {
//                    if (item is UiInfo)
//                    {
//                        var uiInfo = (UiInfo)item;
//                        var uIInfoType = new UIInfoType();
//                        uIInfoType.Items = new object[] {
//                            new localizedNameType {
//                                lang = uiInfo.DisplayName.Language, Value = uiInfo.DisplayName.Value
//                            },
//                            new localizedNameType
//                            {
//                                lang = uiInfo.Description.Language, Value=uiInfo.Description.Value
//                            },
//                            new KeywordsType
//                            {
//                                lang = uiInfo.Keywords.Language, Text = uiInfo.Keywords.Values,
//                            },
//                            new localizedURIType
//                            {
//                                lang = uiInfo.InformationURL?.Language??null, Value = uiInfo.InformationURL?.Uri.ToString()??null
//                            },
//                            new localizedURIType
//                            {
//                                lang = uiInfo.PrivacyStatementURL?.Language??null, Value=uiInfo.PrivacyStatementURL?.Uri.ToString()??null
//                            },
//                            new LogoType
//                            {
//                                lang = uiInfo.Logo?.Language??null, height = uiInfo.Logo?.Height??null, width = uiInfo.Logo?.Width??null, Value=uiInfo.Logo?.Value?.ToString()??null
//                            }
//                        };
//                        uIInfoType.ItemsElementName = new ItemsChoiceType8[] {
//                            ItemsChoiceType8.DisplayName,
//                            ItemsChoiceType8.Description,
//                            ItemsChoiceType8.Keywords,
//                            ItemsChoiceType8.InformationURL,
//                            ItemsChoiceType8.PrivacyStatementURL,
//                            ItemsChoiceType8.Logo
//                        };
//                        objectList.Add(uIInfoType);
//                    }
//                    if (item is DiscoHints)
//                    {
//                        var discoHints = (DiscoHints)item;
//                        var discoHintsType = new DiscoHintsType();
//                        discoHintsType.Items = new object[] { discoHints.DomainHint, discoHints.IPHint, discoHints.GeolocationHint };
//                        discoHintsType.ItemsElementName = new ItemsChoiceType9[] {
//                            ItemsChoiceType9.DomainHint,
//                            ItemsChoiceType9.IPHint,
//                            ItemsChoiceType9.GeolocationHint
//                        };
//                        objectList.Add(discoHintsType);
//                    }
//                }
//                extensions.Any = objectList.ToArray<object>();
//                return extensions;
//            }
//        }
//    }
//}

