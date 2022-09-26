﻿using MetadataBuilder.Schema.Metadata;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Saml.MetadataBuilder
{
    internal class MetadataMapper : IMetadataMapper<EntityDescriptor, EntityDescriptorType>
    {
        public EntityDescriptorType MapEntity(EntityDescriptor src)
        {
            var entityDescriptorType = new EntityDescriptorType()
            {
                cacheDuration = src.CacheDuration, //optional
                validUntilSpecified = (src.ValidUntil != null),//optional
                validUntil = src.ValidUntil,//optional
                entityID = src.EntityID, //---> required
                ID = src.Id, //optional
                ContactPerson = (src.ContactPersons != null ? MapEach(src.ContactPersons) : null), //optional
                Organization = (src.Organization != null ? Map(src.Organization) : null),  //optional
                Extensions = (src.Extensions != null ? Map(src.Extensions) : null),  //optional,
                //Signature  = //optional signtaure of metatadats file itself
                //AdditionalMetadataLocation = src.AdditionalMetadataLocations //optional
            };

            SpMetadata spMetadata = src as SpMetadata;
            SPSSODescriptorType sPSSODescriptorType = Map(spMetadata); //---> required

            entityDescriptorType.Items = new object[] { sPSSODescriptorType };

            return entityDescriptorType;
        }
        public SPSSODescriptorType Map(SpMetadata src)
        {
            if (src.GetType() == typeof(SimpleSpMetadata))
            {
                SetValues(src as SimpleSpMetadata);
            }

            var spSsoDescriptorType = new SPSSODescriptorType()
            {
                NameIDFormat = (src.NameIdFormat != null ? new[] { src.NameIdFormat } : null),//optional
                AssertionConsumerService = MapEach(src.AssertionConsumerServices),//---> required
                ArtifactResolutionService = (src.ArtifactResolutionServices != null ? MapEach(src.ArtifactResolutionServices) : null), //optional
                SingleLogoutService = (src.SingleLogoutServiceEndpoints != null ? MapEach(src.SingleLogoutServiceEndpoints) : null), //optional
                AuthnRequestsSigned = src.AuthnRequestsSigned, //optional
                WantAssertionsSigned = src.WantAssertionsSigned,//optional
                cacheDuration = (src.CacheDuration != null ? src.CacheDuration : null), //optional
                protocolSupportEnumeration = new[] { src.RoleDescriptor.ProtocolSupportEnumeration }, //---> required
                //errorURL  //optional
                KeyDescriptor = (src.EncryptingCertificates.Count() + src.SigningCertificates.Count() != 0 ? MapAll(src.EncryptingCertificates, src.SigningCertificates) : null),//optional
                AttributeConsumingService = (src.AttributeConsumingService != null ? MapEach(src.AttributeConsumingService) : null) //optional
            };
            return spSsoDescriptorType;
        }
        public void SetValues(SimpleSpMetadata src)
        {
            src.SingleLogoutServiceEndpoints = (src.SingleLogoutServiceEndpoint != null ? new Endpoint[] { src.SingleLogoutServiceEndpoint } : new Endpoint[0]);
            src.AssertionConsumerServices = (src.AssertionConsumerService != null ? new IndexedEndpoint[] { src.AssertionConsumerService } : new IndexedEndpoint[0]);
            src.ArtifactResolutionServices = (src.ArtifactResolutionService != null ? new IndexedEndpoint[] { src.ArtifactResolutionService } : new IndexedEndpoint[0]);
            src.EncryptingCertificates = (src.EncryptingCertificate != null ? new X509Certificate2[] { src.EncryptingCertificate } : new X509Certificate2[0]);
            src.SigningCertificates = (src.SigningCertificate != null ? new X509Certificate2[] { src.SigningCertificate } : new X509Certificate2[0]);
            src.AttributeConsumingService = MapAll(src.ServiceNames, src.ServiceDescriptions, src.RequestedAttributes);
        }
        public KeyDescriptorType[] MapAll(X509Certificate2[] encryptionCertificates,
            X509Certificate2[] signingCertificates)
        {
            var keyDescriptorTypeList = new List<KeyDescriptorType>();

            foreach (var encr in encryptionCertificates)
            {
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
                                                Items = new object[]{  encr.GetRawCertData() },
                                                ItemsElementName = new [] { ItemsChoiceType.X509Certificate }
                                            }
                                        }
                    }
                };
                keyDescriptorTypeList.Add(keyDescriptorEncrypted);
            }

            foreach (var sign in signingCertificates)
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
            return keyDescriptorTypeList.ToArray<KeyDescriptorType>();
        }
        public AttributeConsumingService[] MapAll(LocalizedName[] serviceNames,
            LocalizedName[] serviceDescription, RequestedAttribute[] requestedAttributes)
        {
            return new AttributeConsumingService[]
            {
                new AttributeConsumingService
                {
                    RequestedAttributes = requestedAttributes,
                    ServiceNames =  serviceNames,
                    ServiceDescriptions = serviceDescription
                }
            };
        }
        public AttributeConsumingServiceType[] MapEach(AttributeConsumingService[] src)
        {
            if (src.Length > 0 || src != null)
            {
                var attributeConsumingServiceType = new AttributeConsumingServiceType[src.Length];

                foreach (var attribute in src)
                {
                    var i = 0;
                    attributeConsumingServiceType[i] =
                        new AttributeConsumingServiceType
                        {
                            ServiceDescription = MapEach(attribute.ServiceDescriptions),
                            ServiceName = MapEach(attribute.ServiceNames),
                            isDefault = attribute.IsDefault,
                            isDefaultSpecified = attribute.IsDefaultFieldSpecified,
                            index = attribute.Index,
                            RequestedAttribute = MapEach(attribute.RequestedAttributes)
                        };
                    if (i < src.Length) { i++; };
                }
                return attributeConsumingServiceType;
            }
            return null;
        }
        public RequestedAttributeType[] MapEach(RequestedAttribute[] src)
        {
            if (src.Length > 0 || src != null)
            {
                var requestedAttributeType = new RequestedAttributeType[src.Length];
                var i = 0;
                foreach (var attribute in src)
                {
                    requestedAttributeType[i] = new RequestedAttributeType
                    {
                        isRequired = attribute.IsRequiredField,
                        isRequiredSpecified = attribute.IsRequiredFieldSpecified,
                        AttributeValue = attribute.AttributeValue,
                        FriendlyName = attribute.FriendlyName,
                        Name = attribute.Name,
                        NameFormat = attribute.NameFormat
                    };
                    if (i < src.Length) { i++; };
                }
                return requestedAttributeType;
            }
            return null;
        }
        public ContactType[] MapEach(ContactPerson[] src)
        {
            if (src.Length > 0 || src != null)
            {
                var contactType = new ContactType[src.Length];
                var i = 0;
                foreach (var contactPerson in src)
                {
                    contactType[i] = new ContactType()
                    {
                        Company = contactPerson.Company,
                        //contactType= contactPerson.ContactType,
                        EmailAddress = contactPerson.EmailAddresses.ToArray(),
                        GivenName = contactPerson.GivenName,
                        SurName = contactPerson.Surname,
                        TelephoneNumber = contactPerson.TelephoneNumbers.ToArray(),
                        //Extensions = contactPerson.ex
                    };
                    if (i < src.Length) { i++; };
                }
                return contactType;
            }
            return null;
        }
        public IndexedEndpointType[] MapEach(IndexedEndpoint[] src)
        {
            if (src.Length > 0 || src != null)
            {
                var indexedEndpointType = new IndexedEndpointType[src.Length];
                var i = 0;
                foreach (var indexedEndpoint in src)
                {
                    indexedEndpointType[i] = new IndexedEndpointType
                    {
                        Location = indexedEndpoint.Location,
                        ResponseLocation = indexedEndpoint.ResponseLocation,
                        Binding = indexedEndpoint.Binding,
                        isDefault = indexedEndpoint.IsDefault,
                        isDefaultSpecified = indexedEndpoint.IsDefaultSpecified,
                        index = indexedEndpoint.Index
                    };
                    if (i < src.Length) { i++; };
                }
                return indexedEndpointType;
            }
            return null;
        }
        public EndpointType[] Map(Endpoint src)
        {
            if (src != null)
            {
                var endpointType = new EndpointType[]{ new EndpointType
                    {
                        Location = src.Location,
                        ResponseLocation = src.ResponseLocation,
                        Binding = src.Binding
                    }
            };
                return endpointType;
            }
            return null;
        }
        public EndpointType[] MapEach(Endpoint[] src)
        {
            if (src.Count() > 0 || src != null)
            {
                var endpointType = new EndpointType[src.Length];
                var i = 0;
                foreach (var endpoint in src)
                {
                    endpointType[i] = new EndpointType
                    {
                        Location = endpoint.Location,
                        ResponseLocation = endpoint.ResponseLocation,
                        Binding = endpoint.Binding
                    };
                    if (i < src.Length) { i++; };
                }
                return endpointType;
            }
            return null;
        }
        public OrganizationType Map(Organization src)
        {
            if (src != null)
            {
                var organizationType = new OrganizationType()
                {
                    OrganizationDisplayName = MapEach(src.OrganizationDisplayName),
                    OrganizationName = MapEach(src.OrganizationName),
                    OrganizationURL = MapEach(src.OrganizationURL)
                };
                return organizationType;
            }
            return null;
        }
        public localizedNameType[] MapEach(IEnumerable<LocalizedName> src)
        {
            if (src.Count() > 0 || src != null)
            {
                var localizedNameType = new localizedNameType[src.Count()];
                var i = 0;
                foreach (var localizedName in src)
                {
                    localizedNameType[i] = new localizedNameType
                    {
                        lang = localizedName.Language,
                        Value = localizedName.Value
                    };
                    if (i < src.Count()) { i++; };
                }
                return localizedNameType;
            }
            return null;
        }
        public localizedURIType[] MapEach(IEnumerable<LocalizedUri> src)
        {
            if (src.Count() > 0 || src != null)
            {
                var localizedURIType = new localizedURIType[src.Count()];
                var i = 0;
                foreach (var localizedUri in src)
                {
                    localizedURIType[i] = new localizedURIType
                    {
                        lang = localizedUri.Language,
                        Value = localizedUri.Uri.ToString()
                    };
                    if (i < src.Count()) { i++; };
                }
                return localizedURIType;
            }
            return null;
        }
        public ExtensionsType Map(Extension src)
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

            //var uIInfoType = new UIInfoType();
            //if (src != null)
            //{

            //    uIInfoType.Items = new object[] { new LocalizedName { Language = src.UiInfo.DisplayName.Language, Value = src.UiInfo.DisplayName.Value } };
            //    uIInfoType.ItemsElementName = new ItemsChoiceType8[] { ItemsChoiceType8.DisplayName };
            //}

            //var extensionsType = new ExtensionsType();
            //extensionsType.Any = new object[] { uIInfoType };

            return extensionsType;
        }
    }
}

