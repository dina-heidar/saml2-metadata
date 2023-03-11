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

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using AutoMapper;
//using MetadataBuilder.Schema.Metadata;
//using Saml.MetadataBuilder;

//namespace MetadataBuilder.Mappings
//{
//    internal class RichSpMetadataMapper : Profile
//    {
//        public RichSpMetadataMapper()
//        {
//            CreateMap<RichSpMetadata, SPSSODescriptorType>()
//                .ForMember(dest => dest.KeyDescriptor, opt =>
//                {
//                    opt.PreCondition(src => (src.EncryptingCertificates != null || src.SigningCertificates != null));
//                    opt.MapFrom<KeyDescriptorTypeResolver>();
//                })
//               .ForMember(dest => dest.KeyDescriptor, opt => opt.MapFrom<KeyDescriptorTypeResolver>());
//        }

//        //custom key descriptor
//        public class KeyDescriptorTypeResolver : IValueResolver<RichSpMetadata, RoleDescriptorType, KeyDescriptorType[]>
//        {
//            public KeyDescriptorType[] Resolve(RichSpMetadata source, RoleDescriptorType destination,
//                KeyDescriptorType[] member, ResolutionContext context)
//            {
//                var keyDescriptorTypeList = new List<KeyDescriptorType>();

//                var encryptionMethodType = new List<EncryptionMethodType>();

//                if (!source.EncryptingCertificates.Equals(Array.Empty<EncryptingCertificate>()))
//                {
//                    //encryption use
//                    foreach (var encr in source.EncryptingCertificates)
//                    {
//                        foreach (var alg in encr.AcceptedEncryptionMethods)
//                        {
//                            encryptionMethodType.Add(new EncryptionMethodType
//                            {
//                                Algorithm = alg.Algorithm,
//                                OAEPparams = alg.OAEPparams,
//                                KeySize = alg.KeySize
//                            });
//                        }
//                        var keyDescriptorEncrypted = new KeyDescriptorType()
//                        {
//                            useSpecified = true,
//                            use = KeyTypes.encryption,
//                            KeyInfo = new KeyInfoType()
//                            {
//                                ItemsElementName = new[] { ItemsChoiceType2.X509Data },
//                                Items = new X509DataType[]
//                                                {
//                                            new X509DataType()
//                                            {
//                                                Items = new object[] { encr.EncryptionCertificate.GetRawCertData() },
//                                                ItemsElementName = new[] { ItemsChoiceType.X509Certificate }
//                                            }
//                                                }
//                            },
//                            EncryptionMethod = encryptionMethodType.ToArray(),
//                        };
//                        keyDescriptorTypeList.Add(keyDescriptorEncrypted);

//                    }
//                }

//                //signing use
//                foreach (var sign in source.SigningCertificates)
//                {
//                    if (sign != null)
//                    {
//                        var keyDescriptorSigning = new KeyDescriptorType()
//                        {
//                            useSpecified = true,
//                            use = KeyTypes.signing,
//                            KeyInfo = new KeyInfoType()
//                            {
//                                ItemsElementName = new[] { ItemsChoiceType2.X509Data },
//                                Items = new X509DataType[]
//                                                {
//                                            new X509DataType()
//                                            {
//                                                Items = new object[]{ sign.GetRawCertData() },
//                                                ItemsElementName = new [] { ItemsChoiceType.X509Certificate }
//                                            }
//                                                }
//                            }
//                        };
//                        keyDescriptorTypeList.Add(keyDescriptorSigning);
//                    }
//                }

//                return keyDescriptorTypeList.ToArray<KeyDescriptorType>();
//            }
//        }
//    }
//}
