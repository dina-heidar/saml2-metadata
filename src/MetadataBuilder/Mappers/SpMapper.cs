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
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using MetadataBuilder.Schema.Metadata;

namespace Saml.MetadataBuilder
{
    internal static class SpMapper
    {
        #region ToXml
        internal static SPSSODescriptorType Map(this RichSpMetadata src)
        {
            if (src.GetType() == typeof(BasicSpMetadata))
            {
                //map basic sp metadata properties to rich sp metadata ones
                SetValues(src as BasicSpMetadata);
            }

            //get sso mapper values
            var (nameIdFormats, artifactResolutionServices, singleLogoutServices) = SsoMapper.SetValues(
                src.NameIdFormat,
                src.ArtifactResolutionServices,
                src.SingleLogoutServiceEndpoints);

            //get role mapper values
            var (protocolSupportEnumerations, keyDescriptorTypes,
                cachingDuration, extensions, attributeConsumingServices) = RoleMapper.SetValues(
                    src.ProtocolSupportEnumeration, src.EncryptingCertificates,
                    src.SigningCertificates, src.CacheDuration, src.Extensions,
                    src.AttributeConsumingService);

            var spSsoDescriptorType = new SPSSODescriptorType()
            {
                //sp
                AssertionConsumerService = src.AssertionConsumerServices.MapEach(),//---> required
                AuthnRequestsSigned = src.AuthnRequestsSigned, //optional
                WantAssertionsSigned = src.WantAssertionsSigned,//optional
                AuthnRequestsSignedSpecified = true,
                WantAssertionsSignedSpecified = true,

                //sso
                NameIDFormat = nameIdFormats,//optional                
                ArtifactResolutionService = artifactResolutionServices, //optional
                SingleLogoutService = singleLogoutServices, //optional

                //role
                protocolSupportEnumeration = protocolSupportEnumerations, //---> required
                KeyDescriptor = keyDescriptorTypes, //optional
                cacheDuration = cachingDuration, //optional
                Extensions = extensions, //optional
                AttributeConsumingService = attributeConsumingServices //optional                
            };
            return spSsoDescriptorType;
        }
        private static void SetValues(BasicSpMetadata src)
        {
            src.SingleLogoutServiceEndpoints = (src.SingleLogoutServiceEndpoint != null ? new Endpoint[] { src.SingleLogoutServiceEndpoint } : new Endpoint[0]);
            src.AssertionConsumerServices = (src.AssertionConsumerService != null ? new IndexedEndpoint[] { src.AssertionConsumerService } : new IndexedEndpoint[0]);
            src.ArtifactResolutionServices = (src.ArtifactResolutionService != null ? new IndexedEndpoint[] { src.ArtifactResolutionService } : new IndexedEndpoint[0]);
            src.EncryptingCertificates = (src.EncryptingCertificate != null ? new EncryptingCertificate[] { src.EncryptingCertificate } : new EncryptingCertificate[0]);
            src.SigningCertificates = (src.SigningCertificate != null ? new X509Certificate2[] { src.SigningCertificate } : new X509Certificate2[0]);
            //src.AttributeConsumingService = (src.AttributeConsumingService.All(a => a.IsEmpty()) ? null : src.AttributeConsumingService.MapEach());  //MapAll(src.ServiceNames, src.ServiceDescriptions, src.RequestedAttributes);
        }
        //public static AttributeConsumingService[] MapAll(LocalizedName[] serviceNames,
        //LocalizedName[] serviceDescription, RequestedAttribute[] requestedAttributes)
        //{
        //    if (
        //        serviceNames.Equals(Array.Empty<LocalizedName>())
        //        && serviceDescription.Equals(Array.Empty<LocalizedName>())
        //        && requestedAttributes.Equals(Array.Empty<RequestedAttribute>())
        //        )
        //        return null;

        //    else
        //    {
        //        return new AttributeConsumingService[]
        //        {
        //        new AttributeConsumingService
        //        {
        //            RequestedAttributes = requestedAttributes,
        //            ServiceNames =  serviceNames,
        //            ServiceDescriptions = serviceDescription
        //        }
        //        };
        //    }
        //}
        public static AttributeConsumingServiceType[] MapEach(this IEnumerable<AttributeConsumingService> src)
        {
            var isEmpty = Array.Empty<AttributeConsumingService>().Equals(src);
            var isEmptyEn = Enumerable.Empty<AttributeConsumingService>().Equals(src);

            if (src.Count() > 0 || src != null)
            {
                var attributeConsumingServiceType = new AttributeConsumingServiceType[src.Count()];

                var i = 0;
                foreach (var attribute in src)
                {
                    if (attribute != null)
                    {
                        attributeConsumingServiceType[i] = new AttributeConsumingServiceType
                        {
                            ServiceDescription = attribute.ServiceDescriptions?.MapEach(),
                            ServiceName = attribute.ServiceNames?.MapEach(),
                            isDefault = (bool)attribute.IsDefault,
                            isDefaultSpecified = (bool)attribute.IsDefaultFieldSpecified,
                            index = (ushort)attribute.Index,
                            RequestedAttribute = attribute.RequestedAttributes?.MapEach()
                        };
                    }
                    if (i < src.Count()) { i++; };
                }
                return attributeConsumingServiceType;
            }
            return null;
        }
        public static RequestedAttributeType[] MapEach(this IEnumerable<RequestedAttribute> src)
        {
            if (src.Count() > 0 || src != null)
            {
                var requestedAttributeType = new RequestedAttributeType[src.Count()];
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
                    if (i < src.Count()) { i++; };
                }
                return requestedAttributeType;
            }
            return new RequestedAttributeType[0];
        }

        #endregion

        #region FromXml

        public static SPSSODescriptor Map(this SPSSODescriptorType src)
        {
            var spSsoDescriptor = new SPSSODescriptor()
            {
                //sp
                AssertionConsumerServices = (src.AssertionConsumerService != null ? src.AssertionConsumerService.MapEach() : new IndexedEndpoint[0]),
                AttributeConsumingService = (src.AttributeConsumingService != null ? src.AttributeConsumingService.MapEach() : new AttributeConsumingService[0]),
                AuthnRequestsSigned = src.AuthnRequestsSigned,
                AuthnRequestsSignedFieldSpecified = src.AuthnRequestsSignedSpecified,
                WantAssertionsSigned = src.WantAssertionsSigned,
                WantAssertionsSignedFieldSpecified = src.WantAssertionsSignedSpecified,

                //sso
                NameIdFormats = (src.NameIDFormat != null ? src.NameIDFormat : new string[0]),
                ArtifactResolutionServices = (src.ArtifactResolutionService != null ? src.ArtifactResolutionService.MapEach() : new IndexedEndpoint[0]),
                SingleLogoutServices = (src.SingleLogoutService != null ? src.SingleLogoutService.MapEach() : new Endpoint[0]),
                ManageNameIdServices = (src.ManageNameIDService != null ? src.ManageNameIDService.MapEach() : new Endpoint[0]),

                //role
                ProtocolSupportEnumeration = (src.protocolSupportEnumeration != null ? src.protocolSupportEnumeration[0] : string.Empty),
                ContactPersons = (src.ContactPerson != null ? src.ContactPerson.MapEach() : new ContactPerson[0]),
                Organization = (src.Organization != null ? src.Organization.Map() : null),
                EncryptingCertificates = (src.KeyDescriptor != null ? RoleMapper.MapEach(src.KeyDescriptor, KeyTypes.encryption) : new X509Certificate2[0]),
                SigningCertificates = (src.KeyDescriptor != null ? RoleMapper.MapEach(src.KeyDescriptor, KeyTypes.signing) : new X509Certificate2[0]),
                Id = src.ID,
                ValidUntil = src.validUntil,
                CacheDuration = src.cacheDuration
            };
            return spSsoDescriptor;
        }
        public static AttributeConsumingService[] MapEach(this AttributeConsumingServiceType[] src)
        {
            if (src.Count() > 0 || src != null)
            {
                var attributeConsumingService = new AttributeConsumingService[src.Length];
                var i = 0;
                foreach (var atc in src)
                {
                    attributeConsumingService[i] = new AttributeConsumingService
                    {
                        IsDefault = atc.isDefault,
                        IsDefaultFieldSpecified = atc.isDefaultSpecified,
                        ServiceDescriptions = atc.ServiceDescription.MapEach(),
                        ServiceNames = atc.ServiceName.MapEach(),
                        Index = atc.index,
                        RequestedAttributes = atc.RequestedAttribute.MapEach()
                    };
                    if (i < src.Length) { i++; };
                }
                return attributeConsumingService;
            }
            return new AttributeConsumingService[0];
        }
        public static RequestedAttribute[] MapEach(this RequestedAttributeType[] src)
        {
            if (src.Count() > 0 || src != null)
            {
                var requestedAttribute = new RequestedAttribute[src.Count()]; var i = 0;
                foreach (var ra in src)
                {
                    requestedAttribute[i] = new RequestedAttribute
                    {
                        IsRequiredFieldSpecified = ra.isRequiredSpecified,
                        IsRequiredField = ra.isRequired,
                        AttributeValue = ra.AttributeValue,
                        FriendlyName = ra.FriendlyName,
                        Name = ra.Name,
                        NameFormat = ra.NameFormat
                    };
                    if (i < src.Count()) { i++; };
                }
                return requestedAttribute;
            }
            return new RequestedAttribute[0];
        }

        #endregion
    }
}
