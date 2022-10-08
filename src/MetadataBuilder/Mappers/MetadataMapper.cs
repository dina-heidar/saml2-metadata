// MIT License
// Copyright (c) 2019 Dina Heidar
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

//namespace Saml.MetadataBuilder
//{
//    internal class MetadataMapper : IMetadataMapper<EntityDescriptor, EntityDescriptorType>,
//        IMetadataMapper<EntityDescriptorType, EntityDescriptor>
//    {

//        #region ToXml

//        public EntityDescriptorType MapEntity(EntityDescriptor src)
//        {
//            var entityDescriptorType = new EntityDescriptorType()
//            {
//                cacheDuration = src.CacheDuration, //optional
//                validUntilSpecified = (src.ValidUntil != null),//optional
//                validUntil = src.ValidUntil,//optional
//                entityID = src.EntityID, //---> required
//                ID = src.Id, //optional
//                ContactPerson = (src.ContactPersons != null ? MapEach(src.ContactPersons) : null), //optional
//                Organization = (src.Organization != null ? Map(src.Organization) : null),  //optional              
//                //Signature  = //optional signtaure of metatadata file itself
//                //AdditionalMetadataLocation = src.AdditionalMetadataLocations //optional
//            };


//            SpMetadata spMetadata = src as SpMetadata;
//            SPSSODescriptorType sPSSODescriptorType = Map(spMetadata); //---> required

//            entityDescriptorType.Items = new object[] { sPSSODescriptorType };

//            return entityDescriptorType;
//        }
//        public SPSSODescriptorType Map(SpMetadata src)
//        {
//            if (src.GetType() == typeof(SimpleSpMetadata))
//            {
//                SetValues(src as SimpleSpMetadata);
//            }

//            var spSsoDescriptorType = new SPSSODescriptorType()
//            {
//                NameIDFormat = (src.NameIdFormat != null ? new[] { src.NameIdFormat } : null),//optional
//                AssertionConsumerService = MapEach(src.AssertionConsumerServices),//---> required
//                ArtifactResolutionService = (src.ArtifactResolutionServices != null ? MapEach(src.ArtifactResolutionServices) : null), //optional
//                SingleLogoutService = (src.SingleLogoutServiceEndpoints != null ? MapEach(src.SingleLogoutServiceEndpoints) : null), //optional
//                AuthnRequestsSigned = src.AuthnRequestsSigned, //optional
//                WantAssertionsSigned = src.WantAssertionsSigned,//optional
//                cacheDuration = (src.CacheDuration != null ? src.CacheDuration : null), //optional
//                protocolSupportEnumeration = new[] { src.ProtocolSupportEnumeration }, //---> required
//                //errorURL  //optional
//                Extensions = (src.Extensions != null ? Map(src.Extensions) : null),  //optional,
//                KeyDescriptor = (src.EncryptingCertificates.Count() + src.SigningCertificates.Count() != 0 ? MapAll(src.EncryptingCertificates, src.SigningCertificates) : null),//optional
//                AttributeConsumingService = (src.AttributeConsumingService != null ? MapEach(src.AttributeConsumingService) : null) //optional
//            };
//            return spSsoDescriptorType;
//        }
//        public void SetValues(SimpleSpMetadata src)
//        {
//            src.SingleLogoutServiceEndpoints = (src.SingleLogoutServiceEndpoint != null ? new Endpoint[] { src.SingleLogoutServiceEndpoint } : new Endpoint[0]);
//            src.AssertionConsumerServices = (src.AssertionConsumerService != null ? new IndexedEndpoint[] { src.AssertionConsumerService } : new IndexedEndpoint[0]);
//            src.ArtifactResolutionServices = (src.ArtifactResolutionService != null ? new IndexedEndpoint[] { src.ArtifactResolutionService } : new IndexedEndpoint[0]);
//            src.EncryptingCertificates = (src.EncryptingCertificate != null ? new X509Certificate2[] { src.EncryptingCertificate } : new X509Certificate2[0]);
//            src.SigningCertificates = (src.SigningCertificate != null ? new X509Certificate2[] { src.SigningCertificate } : new X509Certificate2[0]);
//            src.AttributeConsumingService = MapAll(src.ServiceNames, src.ServiceDescriptions, src.RequestedAttributes);
//        }
//        public KeyDescriptorType[] MapAll(X509Certificate2[] encryptionCertificates,
//            X509Certificate2[] signingCertificates)
//        {
//            var keyDescriptorTypeList = new List<KeyDescriptorType>();

//            foreach (var encr in encryptionCertificates)
//            {
//                var keyDescriptorEncrypted = new KeyDescriptorType()
//                {
//                    useSpecified = true,
//                    use = KeyTypes.encryption,
//                    KeyInfo = new KeyInfoType()
//                    {
//                        ItemsElementName = new[] { ItemsChoiceType2.X509Data },
//                        Items = new X509DataType[]
//                                        {
//                                            new X509DataType()
//                                            {
//                                                Items = new object[]{  encr.GetRawCertData() },
//                                                ItemsElementName = new [] { ItemsChoiceType.X509Certificate }
//                                            }
//                                        }
//                    }
//                };
//                keyDescriptorTypeList.Add(keyDescriptorEncrypted);
//            }

//            foreach (var sign in signingCertificates)
//            {
//                var keyDescriptorSigning = new KeyDescriptorType()
//                {
//                    useSpecified = true,
//                    use = KeyTypes.signing,
//                    KeyInfo = new KeyInfoType()
//                    {
//                        ItemsElementName = new[] { ItemsChoiceType2.X509Data },
//                        Items = new X509DataType[]
//                                        {
//                                            new X509DataType()
//                                            {
//                                                Items = new object[]{ sign.GetRawCertData() },
//                                                ItemsElementName = new [] { ItemsChoiceType.X509Certificate }
//                                            }
//                                        }
//                    }
//                };
//                keyDescriptorTypeList.Add(keyDescriptorSigning);
//            }
//            return keyDescriptorTypeList.ToArray<KeyDescriptorType>();
//        }
//        public AttributeConsumingService[] MapAll(LocalizedName[] serviceNames,
//            LocalizedName[] serviceDescription, RequestedAttribute[] requestedAttributes)
//        {
//            return new AttributeConsumingService[]
//            {
//                new AttributeConsumingService
//                {
//                    RequestedAttributes = requestedAttributes,
//                    ServiceNames =  serviceNames,
//                    ServiceDescriptions = serviceDescription
//                }
//            };
//        }
//        public AttributeConsumingServiceType[] MapEach(AttributeConsumingService[] src)
//        {
//            if (src.Length > 0 || src != null)
//            {
//                var attributeConsumingServiceType = new AttributeConsumingServiceType[src.Length];

//                foreach (var attribute in src)
//                {
//                    var i = 0;
//                    attributeConsumingServiceType[i] =
//                        new AttributeConsumingServiceType
//                        {
//                            ServiceDescription = MapEach(attribute.ServiceDescriptions),
//                            ServiceName = MapEach(attribute.ServiceNames),
//                            isDefault = attribute.IsDefault,
//                            isDefaultSpecified = attribute.IsDefaultFieldSpecified,
//                            index = attribute.Index,
//                            RequestedAttribute = MapEach(attribute.RequestedAttributes)
//                        };
//                    if (i < src.Length) { i++; };
//                }
//                return attributeConsumingServiceType;
//            }
//            return null;
//        }
//        public RequestedAttributeType[] MapEach(RequestedAttribute[] src)
//        {
//            if (src.Length > 0 || src != null)
//            {
//                var requestedAttributeType = new RequestedAttributeType[src.Length];
//                var i = 0;
//                foreach (var attribute in src)
//                {
//                    requestedAttributeType[i] = new RequestedAttributeType
//                    {
//                        isRequired = attribute.IsRequiredField,
//                        isRequiredSpecified = attribute.IsRequiredFieldSpecified,
//                        AttributeValue = attribute.AttributeValue,
//                        FriendlyName = attribute.FriendlyName,
//                        Name = attribute.Name,
//                        NameFormat = attribute.NameFormat
//                    };
//                    if (i < src.Length) { i++; };
//                }
//                return requestedAttributeType;
//            }
//            return null;
//        }
//        public ContactType[] MapEach(ContactPerson[] src)
//        {
//            if (src.Length > 0 || src != null)
//            {
//                var contactType = new ContactType[src.Length];
//                var i = 0;
//                foreach (var contactPerson in src)
//                {
//                    contactType[i] = new ContactType()
//                    {
//                        Company = contactPerson.Company,
//                        //contactType= contactPerson.ContactType,
//                        EmailAddress = contactPerson.EmailAddresses.ToArray(),
//                        GivenName = contactPerson.GivenName,
//                        SurName = contactPerson.Surname,
//                        TelephoneNumber = contactPerson.TelephoneNumbers.ToArray(),
//                        //Extensions = contactPerson.ex
//                    };
//                    if (i < src.Length) { i++; };
//                }
//                return contactType;
//            }
//            return null;
//        }
//        public IndexedEndpointType[] MapEach(IndexedEndpoint[] src)
//        {
//            if (src.Length > 0 || src != null)
//            {
//                var indexedEndpointType = new IndexedEndpointType[src.Length];
//                var i = 0;
//                foreach (var indexedEndpoint in src)
//                {
//                    indexedEndpointType[i] = new IndexedEndpointType
//                    {
//                        Location = indexedEndpoint.Location,
//                        ResponseLocation = indexedEndpoint.ResponseLocation,
//                        Binding = indexedEndpoint.Binding,
//                        isDefault = indexedEndpoint.IsDefault,
//                        isDefaultSpecified = indexedEndpoint.IsDefaultSpecified,
//                        index = indexedEndpoint.Index
//                    };
//                    if (i < src.Length) { i++; };
//                }
//                return indexedEndpointType;
//            }
//            return null;
//        }
//        //public EndpointType[] Map(Endpoint src)
//        //{
//        //    if (src != null)
//        //    {
//        //        var endpointType = new EndpointType[]{ new EndpointType
//        //            {
//        //                Location = src.Location,
//        //                ResponseLocation = src.ResponseLocation,
//        //                Binding = src.Binding
//        //            }
//        //    };
//        //        return endpointType;
//        //    }
//        //    return null;
//        //}
//        public EndpointType[] MapEach(Endpoint[] src)
//        {
//            if (src.Count() > 0 || src != null)
//            {
//                var endpointType = new EndpointType[src.Length];
//                var i = 0;
//                foreach (var endpoint in src)
//                {
//                    endpointType[i] = new EndpointType
//                    {
//                        Location = endpoint.Location,
//                        ResponseLocation = endpoint.ResponseLocation,
//                        Binding = endpoint.Binding
//                    };
//                    if (i < src.Length) { i++; };
//                }
//                return endpointType;
//            }
//            return null;
//        }
//        public OrganizationType Map(Organization src)
//        {
//            if (src != null)
//            {
//                var organizationType = new OrganizationType()
//                {
//                    OrganizationDisplayName = MapEach(src.OrganizationDisplayName),
//                    OrganizationName = MapEach(src.OrganizationName),
//                    OrganizationURL = MapEach(src.OrganizationURL)
//                };
//                return organizationType;
//            }
//            return null;
//        }
//        public localizedNameType[] MapEach(IEnumerable<LocalizedName> src)
//        {
//            if (src.Count() > 0 || src != null)
//            {
//                var localizedNameType = new localizedNameType[src.Count()];
//                var i = 0;
//                foreach (var localizedName in src)
//                {
//                    localizedNameType[i] = new localizedNameType
//                    {
//                        lang = localizedName.Language,
//                        Value = localizedName.Value
//                    };
//                    if (i < src.Count()) { i++; };
//                }
//                return localizedNameType;
//            }
//            return null;
//        }
//        public localizedURIType[] MapEach(IEnumerable<LocalizedUri> src)
//        {
//            if (src.Count() > 0 || src != null)
//            {
//                var localizedURIType = new localizedURIType[src.Count()];
//                var i = 0;
//                foreach (var localizedUri in src)
//                {
//                    localizedURIType[i] = new localizedURIType
//                    {
//                        lang = localizedUri.Language,
//                        Value = localizedUri.Uri.ToString()
//                    };
//                    if (i < src.Count()) { i++; };
//                }
//                return localizedURIType;
//            }
//            return null;
//        }
//        public ExtensionsType Map(Extension src)
//        {
//            var extensionsType = new ExtensionsType();
//            var objectList = new List<object>();

//            if (src != null)
//            {
//                foreach (var item in src.Any)
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
//                extensionsType.Any = objectList.ToArray<object>();
//            }

//            //var uIInfoType = new UIInfoType();
//            //if (src != null)
//            //{

//            //    uIInfoType.Items = new object[] { new LocalizedName { Language = src.UiInfo.DisplayName.Language, Value = src.UiInfo.DisplayName.Value } };
//            //    uIInfoType.ItemsElementName = new ItemsChoiceType8[] { ItemsChoiceType8.DisplayName };
//            //}

//            //var extensionsType = new ExtensionsType();
//            //extensionsType.Any = new object[] { uIInfoType };

//            return extensionsType;
//        }

//        #endregion

//        #region fromXml

//        public EntityDescriptor MapEntity(EntityDescriptorType src)
//        {
//            var entityDescriptor = new EntityDescriptor()
//            {
//                CacheDuration = src.cacheDuration,
//                ValidUntil = src.validUntil,
//                EntityID = src.entityID,
//                Id = src.ID,
//                Items = src.Items,
//                ContactPersons = (src.ContactPerson != null ? MapEach(src.ContactPerson) : null), //optional
//                Organization = (src.Organization != null ? Map(src.Organization) : null),  //optional              
//                //Signature = (src.Signature != null ? Map(src.Signature) : null)
//                //AdditionalMetadataLocation = src.AdditionalMetadataLocations //optional
//            };

//            if (src.Items.Length != 0)
//            {
//                var items = new object[src.Items.Length];
//                var i = 0;
//                foreach (var item in src.Items)
//                {                  
//                    if (item.GetType() == typeof(IDPSSODescriptorType))
//                    {
//                        var idpSSODescriptor = Map(item as IDPSSODescriptorType);
//                        entityDescriptor.Items[i] = idpSSODescriptor;
//                        if (i < src.Items.Length) { i++; };
//                    }
//                    if (item.GetType() == typeof(SPSSODescriptorType))
//                    {
//                        var spSSODescriptor = Map(item as SPSSODescriptorType);
//                        entityDescriptor.Items[i] = spSSODescriptor;
//                        if (i < src.Items.Length) { i++; };
//                    }
//                }
//            }
//            return entityDescriptor;
//        }
//        public SPSSODescriptor Map(SPSSODescriptorType src)
//        {
//            var spSsoDescriptor = new SPSSODescriptor()
//            {
//                //sp
//                AssertionConsumerServices = (src.AssertionConsumerService != null ? MapEach(src.AssertionConsumerService) : new IndexedEndpoint[0]),
//                AttributeConsumingService = (src.AttributeConsumingService != null ? MapEach(src.AttributeConsumingService) : new AttributeConsumingService[0]),
//                AuthnRequestsSigned = src.AuthnRequestsSigned,
//                AuthnRequestsSignedFieldSpecified = src.AuthnRequestsSignedSpecified,
//                WantAssertionsSigned = src.WantAssertionsSigned,
//                WantAssertionsSignedFieldSpecified = src.WantAssertionsSignedSpecified,

//                //sso
//                NameIdFormats = (src.NameIDFormat != null ? src.NameIDFormat : new string[0]),
//                ArtifactResolutionServices = (src.ArtifactResolutionService != null ? MapEach(src.ArtifactResolutionService) : new IndexedEndpoint[0]),
//                SingleLogoutServices = (src.SingleLogoutService != null ? MapEach(src.SingleLogoutService) : new Endpoint[0]),
//                ManageNameIdServices = (src.ManageNameIDService != null ? MapEach(src.ManageNameIDService) : new Endpoint[0]),

//                //role
//                ProtocolSupportEnumeration = (src.protocolSupportEnumeration != null ? src.protocolSupportEnumeration[0] : String.Empty),
//                ContactPersons = (src.ContactPerson != null ? MapEach(src.ContactPerson) : new ContactPerson[0]),
//                Organization = (src.Organization != null ? Map(src.Organization) : null),
//                EncryptingCertificates = (src.KeyDescriptor != null ? MapEach(src.KeyDescriptor, KeyTypes.encryption) : new X509Certificate2[0]),
//                SigningCertificates = (src.KeyDescriptor != null ? MapEach(src.KeyDescriptor, KeyTypes.signing) : new X509Certificate2[0]),
//                Id = src.ID,
//                ValidUntil = src.validUntil,
//                CacheDuration = src.cacheDuration
//            };
//            return spSsoDescriptor;
//        }
//        public IDPSSODescriptor Map(IDPSSODescriptorType src)
//        {
//            var idpSsoDescriptor = new IDPSSODescriptor()
//            {
//                //idp
//                SingleSignOnServices = (src.SingleSignOnService != null ? MapEach(src.SingleSignOnService) : new Endpoint[0]),
//                NameIdMappingServices = (src.NameIDMappingService != null ? MapEach(src.NameIDMappingService) : new Endpoint[0]),
//                AssertionIdRequestServices = (src.AssertionIDRequestService != null ? MapEach(src.AssertionIDRequestService) : new Endpoint[0]),
//                AttributeProfiles = (src.AttributeProfile != null ? src.AttributeProfile : new string[0]),
//                Attributes = (src.Attribute != null ? MapEach(src.Attribute) : new Attribute[0]),
//                WantAuthnRequestsSigned = src.WantAuthnRequestsSigned,

//                //sso
//                NameIdFormats = (src.NameIDFormat != null ? src.NameIDFormat : new string[0]),
//                ArtifactResolutionServices = (src.ArtifactResolutionService != null ? MapEach(src.ArtifactResolutionService) : new IndexedEndpoint[0]),
//                SingleLogoutServices = (src.SingleLogoutService != null ? MapEach(src.SingleLogoutService) : new Endpoint[0]),
//                ManageNameIdServices = (src.ManageNameIDService != null ? MapEach(src.ManageNameIDService) : new Endpoint[0]),

//                //role
//                ProtocolSupportEnumeration = (src.protocolSupportEnumeration != null ? src.protocolSupportEnumeration[0] : String.Empty),
//                ContactPersons = (src.ContactPerson != null ? MapEach(src.ContactPerson) : new ContactPerson[0]),
//                Organization = (src.Organization != null ? Map(src.Organization) : null),
//                EncryptingCertificates = (src.KeyDescriptor != null ? MapEach(src.KeyDescriptor, KeyTypes.encryption) : new X509Certificate2[0]),
//                SigningCertificates = (src.KeyDescriptor != null ? MapEach(src.KeyDescriptor, KeyTypes.signing) : new X509Certificate2[0]),
//                Id = src.ID,
//                ValidUntil = src.validUntil,
//                CacheDuration = src.cacheDuration
//            };
//            return idpSsoDescriptor;
//        }
//        public AttributeConsumingService[] MapEach(AttributeConsumingServiceType[] src)
//        {
//            if (src.Count() > 0 || src != null)
//            {
//                var attributeConsumingService = new AttributeConsumingService[src.Length];
//                var i = 0;
//                foreach (var atc in src)
//                {
//                    attributeConsumingService[i] = new AttributeConsumingService
//                    {
//                        IsDefault = atc.isDefault,
//                        IsDefaultFieldSpecified = atc.isDefaultSpecified,
//                        ServiceDescriptions = MapEach(atc.ServiceDescription),
//                        ServiceNames = MapEach(atc.ServiceName),
//                        Index = atc.index,
//                        RequestedAttributes = MapEach(atc.RequestedAttribute)
//                    };
//                    if (i < src.Length) { i++; };
//                }
//                return attributeConsumingService;
//            }
//            return new AttributeConsumingService[0];
//        }
//        public ContactPerson[] MapEach(ContactType[] src)
//        {
//            if (src.Count() > 0 || src != null)
//            {
//                var contactPersons = new ContactPerson[src.Length];
//                var i = 0;
//                foreach (var cp in src)
//                {
//                    contactPersons[i] = new ContactPerson
//                    {
//                        Company = cp.Company,
//                        EmailAddresses = cp.EmailAddress,
//                        GivenName = cp.GivenName,
//                        TelephoneNumbers = cp.TelephoneNumber,
//                        Surname = cp.SurName,
//                        ContactType = MapEnum(cp.contactType)
//                    };
//                    if (i < src.Length) { i++; };
//                }
//                return contactPersons;
//            }
//            return new ContactPerson[0];
//        }
//        public X509Certificate2[] MapEach(KeyDescriptorType[] src, KeyTypes keyTypes)
//        {
//            var newSrc = src.Where(x => x.use == keyTypes).ToArray();
//            if (newSrc.Count() > 0 || newSrc != null)
//            {
//                var x509Certificate2 = new X509Certificate2[newSrc.Length];
//                var i = 0;
//                foreach (var keyDescriptor in newSrc)
//                {
//                    var keyInfo = ReadKeyInfo(keyDescriptor.KeyInfo);
//                    foreach (var data in keyInfo.X509Data)
//                    {
//                        foreach (var certificate in data.Certificates)
//                        {
//                            x509Certificate2[i] = new X509Certificate2(Convert.FromBase64String(certificate));
//                            if (i < src.Length) { i++; };
//                        }
//                    }
//                }
//                return x509Certificate2;
//            }
//            return new X509Certificate2[0];
//        }
//        internal KeyInfo ReadKeyInfo(KeyInfoType keyInfoType)
//        {
//            var safeSettings = new XmlReaderSettings
//            {
//                XmlResolver = null,
//                DtdProcessing = DtdProcessing.Prohibit,
//                ValidationType = ValidationType.None
//            };
//            var keyInfoTypeString = SerializeToStringXml<KeyInfoType>(keyInfoType);
//            using (var reader = XmlReader.Create(new StringReader(keyInfoTypeString), safeSettings))
//            {
//                var dsigSerializer = DSigSerializer.Default;
//                var keyInfo = dsigSerializer.ReadKeyInfo(reader);
//                return keyInfo;
//            }
//        }
//        private string SerializeToStringXml<T>(T item) where T : class
//        {
//            string xmlString = string.Empty;
//            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
//            using (MemoryStream memStm = new MemoryStream())
//            {
//                xmlSerializer.Serialize(memStm, item);
//                memStm.Position = 0;
//                xmlString = new StreamReader(memStm).ReadToEnd();
//            }
//            return xmlString;
//        }
//        public Constants.ContactEnumType MapEnum(ContactTypeType contactTypeType)
//        {
//            switch (contactTypeType)
//            {
//                case ContactTypeType.technical:
//                    return Constants.ContactEnumType.Technical;

//                case ContactTypeType.administrative:
//                    return Constants.ContactEnumType.Administrative;

//                case ContactTypeType.support:
//                    return Constants.ContactEnumType.Support;

//                case ContactTypeType.billing:
//                    return Constants.ContactEnumType.Billing;

//                case ContactTypeType.other:
//                    return Constants.ContactEnumType.Other;

//                default:
//                    throw new Saml2MetadataSerializationException($"Invalid ContactType {contactTypeType}");
//            }
//        }
//        public Attribute[] MapEach(AttributeType[] src)
//        {
//            if (src.Count() > 0 || src != null)
//            {
//                var attribute = new Attribute[src.Length];
//                var i = 0;
//                foreach (var att in src)
//                {
//                    attribute[i] = new Attribute
//                    {
//                        AttributeValue = att.AttributeValue,
//                        FriendlyName = att.FriendlyName,
//                        Name = att.Name,
//                        NameFormat = att.NameFormat
//                    };
//                    if (i < src.Length) { i++; };
//                }
//                return attribute;
//            }
//            return new Attribute[0];
//        }
//        public IndexedEndpoint[] MapEach(IndexedEndpointType[] src)
//        {
//            if (src.Count() > 0 || src != null)
//            {
//                var indexedEndpoint = new IndexedEndpoint[src.Length];
//                var i = 0;
//                foreach (var iep in src)
//                {
//                    indexedEndpoint[i] = new IndexedEndpoint
//                    {
//                        Location = iep.Location,
//                        ResponseLocation = iep.ResponseLocation,
//                        Binding = iep.Binding,
//                        Index = iep.index,
//                        IsDefault = iep.isDefault,
//                        IsDefaultSpecified = iep.isDefaultSpecified
//                    };
//                    if (i < src.Length) { i++; };
//                }
//                return indexedEndpoint;
//            }
//            return new IndexedEndpoint[0];
//        }
//        public Endpoint[] MapEach(EndpointType[] src)
//        {
//            if (src.Count() > 0 || src != null)
//            {
//                var endpoint = new Endpoint[src.Length];
//                var i = 0;
//                foreach (var ep in src)
//                {
//                    endpoint[i] = new Endpoint
//                    {
//                        Location = ep.Location,
//                        ResponseLocation = ep.ResponseLocation,
//                        Binding = ep.Binding
//                    };
//                    if (i < src.Length) { i++; };
//                }
//                return endpoint;
//            }
//            return new Endpoint[0];
//        }
//        public Organization Map(OrganizationType src)
//        {
//            if (src != null)
//            {
//                var organization = new Organization()
//                {
//                    OrganizationDisplayName = MapEach(src.OrganizationDisplayName),
//                    OrganizationName = MapEach(src.OrganizationName),
//                    OrganizationURL = MapEach(src.OrganizationURL)
//                };
//                return organization;
//            }
//            return null;
//        }
//        public LocalizedName[] MapEach(IEnumerable<localizedNameType> src)
//        {
//            if (src.Count() > 0 || src != null)
//            {
//                var localizedName = new LocalizedName[src.Count()];
//                var i = 0;
//                foreach (var ln in src)
//                {
//                    localizedName[i] = new LocalizedName
//                    {
//                        Language = ln.lang,
//                        Value = ln.Value
//                    };
//                    if (i < src.Count()) { i++; };
//                }
//                return localizedName;
//            }
//            return new LocalizedName[0];
//        }
//        public LocalizedUri[] MapEach(localizedURIType[] src)
//        {
//            if (src.Count() > 0 || src != null)
//            {
//                var localizedUri = new LocalizedUri[src.Count()];
//                var i = 0;
//                foreach (var lu in src)
//                {
//                    localizedUri[i] = new LocalizedUri
//                    {
//                        Language = lu.lang,
//                        Uri = new Uri(lu.Value)
//                    };
//                    if (i < src.Count()) { i++; };
//                }
//                return localizedUri;
//            }
//            return new LocalizedUri[0];
//        }
//        public RequestedAttribute[] MapEach(RequestedAttributeType[] src)
//        {
//            if (src.Count() > 0 || src != null)
//            {
//                var requestedAttribute = new RequestedAttribute[src.Count()]; var i = 0;
//                foreach (var ra in src)
//                {
//                    requestedAttribute[i] = new RequestedAttribute
//                    {
//                        IsRequiredFieldSpecified = ra.isRequiredSpecified,
//                        IsRequiredField = ra.isRequired,
//                        AttributeValue = ra.AttributeValue,
//                        FriendlyName = ra.FriendlyName,
//                        Name = ra.Name,
//                        NameFormat = ra.NameFormat
//                    };
//                    if (i < src.Count()) { i++; };
//                }
//                return requestedAttribute;
//            }
//            return new RequestedAttribute[0];
//        }

//        #endregion

//    }
//}

