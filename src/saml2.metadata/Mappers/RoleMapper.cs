// Copyright (c) 2022 Dina Heidar
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY
//
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM
//
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.IdentityModel.Xml;
using Saml2Metadata.Constants;
using Saml2Metadata.Schema;

namespace Saml2Metadata
{
    internal static class RoleMapper
    {
        public static (string[] protocolSupportEnumerations, KeyDescriptorType[] keyDescriptorTypes,
          string cachingDuration, ExtensionsType extensions, AttributeConsumingServiceType[] attributeConsumingServices)
           SetValues(string protocolSupportEnumeration, EncryptingCertificate[] encryptingCertificates,
            X509Certificate2[] signingCertificates, string cachingDurations, Extension extension,
            AttributeConsumingService[] attributeConsumingService)
        {
            var protocolSupportEnumerations = new[] { protocolSupportEnumeration }; //---> required
            var keyDescriptorTypes = MapAll(encryptingCertificates, signingCertificates);//optional
            var cachingDuration = (!string.IsNullOrEmpty(cachingDurations) ? cachingDurations.ConvertToXmlCachedDuration() : null); //optional 
            var extensions = (extension != null ? extension.Map() : null);  //optional,              
            var attributeConsumingServices = (attributeConsumingService == null || attributeConsumingService.All(a => a.IsEmpty()) ? null : attributeConsumingService.MapEach()); //optional
            //errorURL //optional
            return (protocolSupportEnumerations, keyDescriptorTypes, cachingDuration, extensions, attributeConsumingServices);
        }

        #region ToXml

        public static string ConvertToXmlCachedDuration(this string src)
        {
            var interval = new TimeSpan();

            if (TimeSpan.TryParse(src, out interval))
                return XmlConvert.ToString(interval);
            else
                return null;
        }
        public static ContactType[] MapEach(this ContactPerson[] src)
        {
            if (src.Length > 0 || src != null)
            {
                var contactType = new ContactType[src.Length];
                var i = 0;
                foreach (var contactPerson in src)
                {
                    if (contactPerson.ContactType != null)
                    {
                        contactType[i] = new ContactType()
                        {
                            Company = contactPerson.Company,
                            contactType = ((ContactEnumType)contactPerson.ContactType).MapEnum(),
                            EmailAddress = contactPerson.EmailAddresses.ToArray(),
                            GivenName = contactPerson.GivenName,
                            SurName = contactPerson.Surname,
                            TelephoneNumber = contactPerson.TelephoneNumbers.ToArray(),
                            //Extensions = contactPerson.ex
                        };
                    }

                    if (i < src.Length) { i++; };
                }
                return contactType;
            }
            return null;
        }
        public static ContactTypeType MapEnum(this ContactEnumType contactType)
        {
            switch (contactType)
            {
                case ContactEnumType.Technical:
                    return ContactTypeType.technical;

                case ContactEnumType.Administrative:
                    return ContactTypeType.administrative;

                case ContactEnumType.Support:
                    return ContactTypeType.support;

                case ContactEnumType.Billing:
                    return ContactTypeType.billing;

                case ContactEnumType.Other:
                    return ContactTypeType.other;

                default:
                    throw new Saml2MetadataSerializationException($"Invalid ContactType {contactType}");
            }
        }
        public static OrganizationType Map(this Organization src)
        {
            if (src != null)
            {
                var organizationType = new OrganizationType()
                {
                    OrganizationDisplayName = src.OrganizationDisplayName?.MapEach(),
                    OrganizationName = src.OrganizationName?.MapEach(),
                    OrganizationURL = src.OrganizationURL?.MapEach()
                };
                return organizationType;
            }
            return null;
        }
        public static localizedNameType[] MapEach(this IEnumerable<LocalizedName> src)
        {
            if (src.Count() > 0 || src != null)
            {
                var localizedNameType = new localizedNameType[src.Count()];
                var i = 0;
                foreach (var localizedName in src)
                {
                    //if (!localizedName.IsAnyNullOrEmpty())
                    //{
                    localizedNameType[i] = new localizedNameType
                    {
                        lang = localizedName.Language,
                        Value = localizedName.Value
                    };
                    //}
                    if (i < src.Count()) { i++; };
                }
                return localizedNameType;
            }
            return null;
        }
        public static localizedURIType[] MapEach(this IEnumerable<LocalizedUri> src)
        {
            if (src.Count() > 0 || src != null)
            {
                var localizedURIType = new localizedURIType[src.Count()];
                var i = 0;
                foreach (var localizedUri in src)
                {
                    //if (!localizedUri.IsAnyNullOrEmpty())
                    //{
                    localizedURIType[i] = new localizedURIType
                    {
                        lang = localizedUri.Language,
                        Value = localizedUri.Uri?.ToString()
                    };
                    //}
                    if (i < src.Count()) { i++; };
                }
                return localizedURIType;
            }
            return null;
        }
        public static ExtensionsType Map(this Extension src)
        {
            var extensionsType = new ExtensionsType();
            var objectList = new List<object>();

            if (src != null)
            {
                foreach (var item in src.Any)
                {
                    if (item is UiInfo)
                    {
                        var uiInfo = (UiInfo)item;
                        var uIInfoType = new UIInfoType();
                        uIInfoType.Items = new object[] {
                            new localizedNameType {
                                lang = uiInfo.DisplayName.Language, Value = uiInfo.DisplayName.Value
                            },
                            new localizedNameType
                            {
                                lang = uiInfo.Description.Language, Value=uiInfo.Description.Value
                            },
                            new KeywordsType
                            {
                                lang = uiInfo.Keywords.Language, Text = uiInfo.Keywords.Values,
                            },
                            new localizedURIType
                            {
                                lang = uiInfo.InformationURL?.Language??null, Value = uiInfo.InformationURL?.Uri.ToString()??null
                            },
                            new localizedURIType
                            {
                                lang = uiInfo.PrivacyStatementURL?.Language??null, Value=uiInfo.PrivacyStatementURL?.Uri.ToString()??null
                            },
                            new LogoType
                            {
                                lang = uiInfo.Logo?.Language??null, height = uiInfo.Logo?.Height??null, width = uiInfo.Logo?.Width??null, Value=uiInfo.Logo?.Value?.ToString()??null
                            }
                        };
                        uIInfoType.ItemsElementName = new ItemsChoiceType8[] {
                            ItemsChoiceType8.DisplayName,
                            ItemsChoiceType8.Description,
                            ItemsChoiceType8.Keywords,
                            ItemsChoiceType8.InformationURL,
                            ItemsChoiceType8.PrivacyStatementURL,
                            ItemsChoiceType8.Logo
                        };
                        objectList.Add(uIInfoType);
                    }
                    if (item is DiscoHints)
                    {
                        var discoHints = (DiscoHints)item;
                        var discoHintsType = new DiscoHintsType();
                        discoHintsType.Items = new object[] { discoHints.DomainHint, discoHints.IPHint, discoHints.GeolocationHint };
                        discoHintsType.ItemsElementName = new ItemsChoiceType9[] {
                            ItemsChoiceType9.DomainHint,
                            ItemsChoiceType9.IPHint,
                            ItemsChoiceType9.GeolocationHint
                        };
                        objectList.Add(discoHintsType);
                    }
                }
                extensionsType.Any = objectList.ToArray<object>();
            }
            return extensionsType;
        }
        public static EndpointType[] MapEach(this Endpoint[] src)
        {
            if (src.Count() > 0 || src != null)
            {
                var endpointType = new EndpointType[src.Length];
                var i = 0;

                foreach (var endpoint in src)
                {
                    if (!endpoint.IsEmpty())
                    {
                        endpointType[i] = new EndpointType
                        {
                            Location = endpoint.Location,
                            ResponseLocation = endpoint.ResponseLocation,
                            Binding = endpoint.Binding
                        };
                        if (i < src.Length) { i++; };
                    }
                }
                return endpointType;
            }
            return null;
        }
        public static IndexedEndpointType[] MapEach(this IndexedEndpoint[] src)
        {
            if (src.Length > 0 || src != null)
            {
                var indexedEndpointType = new IndexedEndpointType[src.Length];
                var i = 0;
                foreach (var indexedEndpoint in src)
                {
                    if (!indexedEndpoint.IsEmpty())
                    {
                        indexedEndpointType[i] = new IndexedEndpointType
                        {
                            Location = indexedEndpoint.Location,
                            ResponseLocation = indexedEndpoint.ResponseLocation,
                            Binding = indexedEndpoint.Binding,
                            isDefault = indexedEndpoint.IsDefault,
                            isDefaultSpecified = indexedEndpoint.IsDefaultSpecified,
                            index = (ushort)indexedEndpoint.Index
                        };
                        if (i < src.Length) { i++; };
                    }
                }
                return indexedEndpointType;
            }
            return null;
        }
        public static KeyDescriptorType[] MapAll(EncryptingCertificate[] encryptingCertificates,
           X509Certificate2[] signingCertificates)
        {
            var keyDescriptorTypeList = new List<KeyDescriptorType>();

            //encryption use
            foreach (var encr in encryptingCertificates)
            {
                if (encr.EncryptionCertificate != null)
                {
                    var encryptionMethodTypes = new List<EncryptionMethodType>();

                    if (encr.EncryptionMethods != null)
                    {
                        foreach (var alg in encr.EncryptionMethods)
                        {
                            if (!alg.IsEmpty())
                            {
                                encryptionMethodTypes.Add(new EncryptionMethodType
                                {
                                    Algorithm = alg.Algorithm,
                                    OAEPparams = alg.OAEPparams,
                                    KeySize = alg.KeySize
                                });
                            }
                        }
                    }
                    var keyDescriptorEncrypted = new KeyDescriptorType()
                    {
                        useSpecified = true,
                        use = KeyTypes.encryption,
                        KeyInfo = new KeyInfoType()
                        {
                            ItemsElementName = new[] { ItemsChoiceType2.X509Data },
                            Items = new X509DataType[]
                                            {
                                                new X509DataType()
                                                {
                                                    Items = new object[] { encr.EncryptionCertificate.GetRawCertData() },
                                                    ItemsElementName = new[] { ItemsChoiceType.X509Certificate }
                                                }
                                            }
                        },
                        EncryptionMethod = encryptionMethodTypes?.ToArray()
                    };
                    keyDescriptorTypeList.Add(keyDescriptorEncrypted);
                }
            }

            //signing use
            foreach (var sign in signingCertificates)
            {
                if (sign != null)
                {
                    var keyDescriptorSigning = new KeyDescriptorType()
                    {
                        useSpecified = true,
                        use = KeyTypes.signing,
                        KeyInfo = new KeyInfoType()
                        {
                            ItemsElementName = new[] { ItemsChoiceType2.X509Data },
                            Items = new X509DataType[]
                                            {
                                            new X509DataType()
                                            {
                                                Items = new object[]{ sign.GetRawCertData() },
                                                ItemsElementName = new [] { ItemsChoiceType.X509Certificate }
                                            }
                                            }
                        }
                    };
                    keyDescriptorTypeList.Add(keyDescriptorSigning);
                }
            }

            return keyDescriptorTypeList.ToArray<KeyDescriptorType>();
        }

        #endregion



        #region FromXml

        public static string ConvertFromXmlCachedDuration(this string src)
        {
            return XmlConvert.ToTimeSpan(src).ToString();
        }
        public static ContactPerson[] MapEach(this ContactType[] src)
        {
            if (src.Count() > 0 || src != null)
            {
                var contactPersons = new ContactPerson[src.Length];
                var i = 0;
                foreach (var cp in src)
                {
                    contactPersons[i] = new ContactPerson
                    {
                        Company = cp.Company,
                        EmailAddresses = cp.EmailAddress,
                        GivenName = cp.GivenName,
                        TelephoneNumbers = cp.TelephoneNumber,
                        Surname = cp.SurName,
                        ContactType = cp.contactType.MapEnum()
                    };
                    if (i < src.Length) { i++; };
                }
                return contactPersons;
            }
            return new ContactPerson[0];
        }
        public static ContactEnumType MapEnum(this ContactTypeType contactTypeType)
        {
            switch (contactTypeType)
            {
                case ContactTypeType.technical:
                    return Constants.ContactEnumType.Technical;

                case ContactTypeType.administrative:
                    return Constants.ContactEnumType.Administrative;

                case ContactTypeType.support:
                    return Constants.ContactEnumType.Support;

                case ContactTypeType.billing:
                    return Constants.ContactEnumType.Billing;

                case ContactTypeType.other:
                    return Constants.ContactEnumType.Other;

                default:
                    throw new Saml2MetadataSerializationException($"Invalid ContactType {contactTypeType}");
            }
        }
        public static Organization Map(this OrganizationType src)
        {
            if (src != null)
            {
                var organization = new Organization()
                {
                    OrganizationDisplayName = src.OrganizationDisplayName.MapEach(),
                    OrganizationName = src.OrganizationName.MapEach(),
                    OrganizationURL = src.OrganizationURL.MapEach()
                };
                return organization;
            }
            return null;
        }
        public static LocalizedName[] MapEach(this IEnumerable<localizedNameType> src)
        {
            if (src.Count() > 0 || src != null)
            {
                var localizedName = new LocalizedName[src.Count()];
                var i = 0;
                foreach (var ln in src)
                {
                    localizedName[i] = new LocalizedName
                    {
                        Language = ln.lang,
                        Value = ln.Value
                    };
                    if (i < src.Count()) { i++; };
                }
                return localizedName;
            }
            return new LocalizedName[0];
        }
        public static LocalizedUri[] MapEach(this localizedURIType[] src)
        {
            if (src.Count() > 0 || src != null)
            {
                var localizedUri = new LocalizedUri[src.Count()];
                var i = 0;
                foreach (var lu in src)
                {
                    localizedUri[i] = new LocalizedUri
                    {
                        Language = lu.lang,
                        Uri = new Uri(lu.Value)
                    };
                    if (i < src.Count()) { i++; };
                }
                return localizedUri;
            }
            return new LocalizedUri[0];
        }
        public static IndexedEndpoint[] MapEach(this IndexedEndpointType[] src)
        {
            if (src.Count() > 0 || src != null)
            {
                var indexedEndpoint = new IndexedEndpoint[src.Length];
                var i = 0;
                foreach (var iep in src)
                {
                    indexedEndpoint[i] = new IndexedEndpoint
                    {
                        Location = iep.Location,
                        ResponseLocation = iep.ResponseLocation,
                        Binding = iep.Binding,
                        Index = iep.index,
                        IsDefault = iep.isDefault,
                        IsDefaultSpecified = iep.isDefaultSpecified
                    };
                    if (i < src.Length) { i++; };
                }
                return indexedEndpoint;
            }
            return new IndexedEndpoint[0];
        }
        //public static Extension Map(ExtensionsType src)
        //{
        //    var extensionsType = new Extension();
        //    var objectList = new List<object>();

        //    if (src != null)
        //    {
        //        foreach (var item in src.Any)
        //        {
        //            if (item is UIInfoType)
        //            {
        //                var uiInfoType = (UIInfoType)item;
        //                var uiInfo = new UiInfo();

        //                uiInfo.DisplayName = new LocalizedName { Language= uiInfoType.}


        //                uiInfo..Items = new object[] {
        //                    new LocalizedName {
        //                        Language = uiInfoType.DisplayName.Language, Value = uiInfoType.DisplayName.Value
        //                    },
        //                    new localizedNameType
        //                    {
        //                        lang = uiInfo.Description.Language, Value=uiInfo.Description.Value
        //                    },
        //                    new KeywordsType
        //                    {
        //                        lang = uiInfo.Keywords.Language, Text = uiInfo.Keywords.Values,
        //                    },
        //                    new localizedURIType
        //                    {
        //                        lang = uiInfo.InformationURL?.Language??null, Value = uiInfo.InformationURL?.Uri.ToString()??null
        //                    },
        //                    new localizedURIType
        //                    {
        //                        lang = uiInfo.PrivacyStatementURL?.Language??null, Value=uiInfo.PrivacyStatementURL?.Uri.ToString()??null
        //                    },
        //                    new LogoType
        //                    {
        //                        lang = uiInfo.Logo?.Language??null, height = uiInfo.Logo?.Height??null, width = uiInfo.Logo?.Width??null, Value=uiInfo.Logo?.Value?.ToString()??null
        //                    }
        //                };
        //                uIInfoType.ItemsElementName = new ItemsChoiceType8[] {
        //                    ItemsChoiceType8.DisplayName,
        //                    ItemsChoiceType8.Description,
        //                    ItemsChoiceType8.Keywords,
        //                    ItemsChoiceType8.InformationURL,
        //                    ItemsChoiceType8.PrivacyStatementURL,
        //                    ItemsChoiceType8.Logo
        //                };
        //                objectList.Add(uIInfoType);
        //            }
        //            if (item is DiscoHints)
        //            {
        //                var discoHints = (DiscoHints)item;
        //                var discoHintsType = new DiscoHintsType();
        //                discoHintsType.Items = new object[] { discoHints.DomainHint, discoHints.IPHint, discoHints.GeolocationHint };
        //                discoHintsType.ItemsElementName = new ItemsChoiceType9[] {
        //                    ItemsChoiceType9.DomainHint,
        //                    ItemsChoiceType9.IPHint,
        //                    ItemsChoiceType9.GeolocationHint
        //                };
        //                objectList.Add(discoHintsType);
        //            }
        //        }
        //        extensionsType.Any = objectList.ToArray<object>();
        //    }
        //    return extensionsType;
        //}
        public static Endpoint[] MapEach(this EndpointType[] src)
        {
            if (src.Count() > 0 || src != null)
            {
                var endpoint = new Endpoint[src.Length];
                var i = 0;
                foreach (var ep in src)
                {
                    endpoint[i] = new Endpoint
                    {
                        Location = ep.Location,
                        ResponseLocation = ep.ResponseLocation,
                        Binding = ep.Binding
                    };
                    if (i < src.Length) { i++; };
                }
                return endpoint;
            }
            return new Endpoint[0];
        }
        public static X509Certificate2[] MapEach(KeyDescriptorType[] src, KeyTypes keyTypes)
        {
            var newSrc = src.Where(x => x.use == keyTypes).ToArray();
            if (newSrc.Count() > 0 || newSrc != null)
            {
                var x509Certificate2 = new X509Certificate2[newSrc.Length];
                var i = 0;
                foreach (var keyDescriptor in newSrc)
                {
                    var keyInfo = ReadKeyInfo(keyDescriptor.KeyInfo);
                    foreach (var data in keyInfo.X509Data)
                    {
                        foreach (var certificate in data.Certificates)
                        {
                            x509Certificate2[i] = new X509Certificate2(Convert.FromBase64String(certificate));
                            if (i < src.Length) { i++; };
                        }
                    }
                }
                return x509Certificate2;
            }
            return new X509Certificate2[0];
        }

        #region internals
        internal static KeyInfo ReadKeyInfo(KeyInfoType keyInfoType)
        {
            var safeSettings = new XmlReaderSettings
            {
                XmlResolver = null,
                DtdProcessing = DtdProcessing.Prohibit,
                ValidationType = ValidationType.None
            };
            var keyInfoTypeString = SerializeToStringXml<KeyInfoType>(keyInfoType);
            using (var reader = XmlReader.Create(new StringReader(keyInfoTypeString), safeSettings))
            {
                var dsigSerializer = DSigSerializer.Default;
                var keyInfo = dsigSerializer.ReadKeyInfo(reader);
                return keyInfo;
            }
        }
        internal static string SerializeToStringXml<T>(T item) where T : class
        {
            var xmlString = string.Empty;
            var xmlSerializer = new XmlSerializer(typeof(T));
            using (var memStm = new MemoryStream())
            {
                xmlSerializer.Serialize(memStm, item);
                memStm.Position = 0;
                xmlString = new StreamReader(memStm).ReadToEnd();
            }
            return xmlString;
        }
        #endregion

        #endregion

    }
}
