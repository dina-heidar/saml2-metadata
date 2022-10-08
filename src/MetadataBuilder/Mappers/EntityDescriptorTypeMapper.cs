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
    internal class EntityDescriptorTypeMapper : IMetadataMapper<EntityDescriptor, EntityDescriptorType>
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
                ContactPerson = (src.ContactPersons != null ? src.ContactPersons.MapEach() : null), //optional
                Organization = (src.Organization != null ? src.Organization.Map() : null),  //optional
                Extensions = (src.Extensions != null ? MapEach(src.Extensions) : null),
                AdditionalMetadataLocation = (src.AdditionalMetadataLocations != null ? MapEach(src.AdditionalMetadataLocations)
                : new AdditionalMetadataLocationType[0])//optional
            };
            if (src.GetType() == typeof(SpMetadata) || src.GetType() == typeof(SimpleSpMetadata))
            {
                var spMetadata = src as SpMetadata;
                var sPSSODescriptorType = spMetadata.Map(); //---> required

                entityDescriptorType.Items = new object[] { sPSSODescriptorType };
            }
            //if (src.GetType() == typeof(IdpMetadata))
            //{
            //    var idpMetadata = src as IdpMetadata;
            //    var idPSSODescriptorType = idpMetadata.Map(); //---> required
            //}

            return entityDescriptorType;
        }

        #region ToXml
        public static AdditionalMetadataLocationType[] MapEach(AdditionalMetadataLocation[] src)
        {
            if (src.Length > 0 || src != null)
            {
                var additionalMetadataLocationType = new AdditionalMetadataLocationType[src.Length];
                var i = 0;
                foreach (var ams in src)
                {
                    additionalMetadataLocationType[i] = new AdditionalMetadataLocationType()
                    {
                        Value = ams.Value,
                        @namespace = ams.Namespace
                    };
                    if (i < src.Length) { i++; };
                }
                return additionalMetadataLocationType;
            }
            return null;
        }

        public static ExtensionsType MapEach(Extension src)
        {
            var extensionsType = new ExtensionsType();
            var objectList = new List<object>();

            if (src != null)
            {
                foreach (var item in src.Any)
                {

                    if (item is DigestMethod)
                    {
                        var digestMethod = (DigestMethod)item;
                        var digestMethodType = new DigestMethodType1();
                        digestMethodType.Algorithm = digestMethod.Algorithm;
                        objectList.Add(digestMethodType);
                    }
                    if (item is SigningMethod)
                    {
                        var signingMethod = (SigningMethod)item;
                        var signingMethodType = new SigningMethodType
                        {
                            Algorithm = signingMethod.Algorithm,
                            MinKeySize = signingMethod.MinKeySize,
                            MaxKeySize = signingMethod.MaxKeySize,
                        };
                        objectList.Add(signingMethodType);
                    }
                }
                extensionsType.Any = objectList.ToArray<object>();
            }
            return extensionsType;
        }

        #endregion
    }
}

