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

using System.Collections.Generic;
using System.Linq;
using MetadataBuilder.Schema.Metadata;

namespace Saml.MetadataBuilder
{
    internal class EntityDescriptorMapper : IMetadataMapper<EntityDescriptorType, EntityDescriptor>
    {
        public EntityDescriptor MapEntity(EntityDescriptorType src)
        {
            var entityDescriptor = new EntityDescriptor()
            {
                CacheDuration = src.cacheDuration,
                ValidUntil = src.validUntil,
                EntityID = src.entityID,
                Id = src.ID,
                Items = src.Items,
                ContactPersons = (src.ContactPerson != null ? src.ContactPerson.MapEach() : null), //optional
                Organization = (src.Organization != null ? src.Organization.Map() : null),  //optional
                Extensions = (src.Extensions != null ? Map(src.Extensions) : null),
                AdditionalMetadataLocations = (src.AdditionalMetadataLocation != null ? MapEach(src.AdditionalMetadataLocation)
                : new AdditionalMetadataLocation[0])//optional
            };

            if (src.Items.Length != 0)
            {
                var items = new object[src.Items.Length];
                var i = 0;
                foreach (var item in src.Items)
                {
                    if (item.GetType() == typeof(IDPSSODescriptorType))
                    {
                        var idpSSODescriptor = (item as IDPSSODescriptorType).Map();
                        entityDescriptor.Items[i] = idpSSODescriptor;
                        if (i < src.Items.Length) { i++; };
                    }
                    if (item.GetType() == typeof(SPSSODescriptorType))
                    {
                        var spSSODescriptor = (item as SPSSODescriptorType).Map();
                        entityDescriptor.Items[i] = spSSODescriptor;
                        if (i < src.Items.Length) { i++; };
                    }
                }
            }
            return entityDescriptor;
        }
        #region FromXml
        public static AdditionalMetadataLocation[] MapEach(AdditionalMetadataLocationType[] src)
        {
            if (src.Length > 0 || src != null)
            {
                var additionalMetadataLocation = new AdditionalMetadataLocation[src.Length];
                var i = 0;
                foreach (var ams in src)
                {
                    additionalMetadataLocation[i] = new AdditionalMetadataLocation()
                    {
                        Value = ams.Value,
                        Namespace = ams.@namespace
                    };
                    if (i < src.Length) { i++; };
                }
                return additionalMetadataLocation;
            }
            return null;
        }
        public static Extension Map(ExtensionsType src)
        {
            var extensions = new Extension();
            var objectList = new List<object>();

            if (src != null)
            {
                foreach (var item in src.Any)
                {

                    if (item.GetType() == typeof(DigestMethodType1))
                    {
                        var digestMethodType = (DigestMethodType1)item;
                        var digestMethod = new DigestMethod();
                        digestMethod.Algorithm = digestMethodType.Algorithm;
                        objectList.Add(digestMethod);
                    }
                    if (item.GetType() == typeof(SigningMethod))
                    {
                        var signingMethodType = (SigningMethodType)item;
                        var signingMethod = new SigningMethod
                        {
                            Algorithm = signingMethodType.Algorithm,
                            MinKeySize = signingMethodType.MinKeySize,
                            MaxKeySize = signingMethodType.MaxKeySize,
                        };
                        objectList.Add(signingMethod);
                    }
                }
                extensions.Any = objectList.ToArray<object>();
            }
            return extensions;
        }
        #endregion
    }
}
