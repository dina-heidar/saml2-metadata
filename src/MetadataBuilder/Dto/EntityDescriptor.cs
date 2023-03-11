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
using System.Security.Cryptography.X509Certificates;
using Saml.MetadataBuilder.Constants;

namespace Saml.MetadataBuilder
{
    /// <summary>
    /// This base class that creates the metadata.
    /// </summary>
    public class EntityDescriptor
    {
        /// <summary>
        /// <para><b>*Required*</b><br/> 
        /// The unique identifier of the SAML entity 
        /// which is described by this definition.<br/>
        /// Example: dev.contoso.com
        /// </para>
        /// </summary>
        /// <value>
        /// The entity identifier.
        /// </value>
        /// <example>dev.constoso.com</example>
        public string EntityID { get; set; }
        /// <summary>
        /// <para><b>Optional</b><br/>
        /// The expiration time of the metadata.<br/>
        /// Example: 2028-01-21T18:12:29.287Z
        /// </para>
        /// </summary>
        /// <value>
        /// The valid until value.
        /// </value>        
        /// <example>2028-01-21T18:12:29.287Z</example>
        public DateTime ValidUntil { get; set; }
        /// <summary>
        /// <para><b>Optional</b><br/>
        /// The maximum length of time a consumer should cache the metadata.<br/>
        /// The time interval is specified in the following form "PnYnMnDTnHnMnS" where:<br/>
        /// - P indicates the period(required)<br/>
        /// - nY indicates the number of years<br/>
        /// - nM indicates the number of months<br/>
        /// - nD indicates the number of days<br/>
        /// - T indicates the start of a time section(required if you are going to specify hours, minutes, or seconds)<br/>
        /// - nH indicates the number of hours<br/>
        /// - nM indicates the number of minutes<br/>
        /// - nS indicates the number of seconds<br/>
        /// </para>
        /// </summary>
        /// <value>
        /// The duration of the cache.
        /// </value>
        /// <example>PT604800S</example>
        public string CacheDuration { get; set; }
        /// <summary>
        /// <para><b>Optional</b><br/> 
        /// A document-unique identifier 
        /// for the element, typically used as a reference point when signing. <br/>
        /// Example: 35D0C44A-52CE-4D2F-BE06-AE5F00C30AA7
        /// </para>
        /// </summary>
        /// <value>
        /// The a document-unique identifier.
        /// </value>
        /// <example>35D0C44A-52CE-4D2F-BE06-AE5F00C30AA7</example>
        public string Id { get; set; }
        /// <summary>
        /// <para>
        /// <b>Optional for Service Providers</b><br/> 
        /// <b>Required for Identity Providers</b><br/> 
        /// Used to include a digital signature that can be used to 
        /// sign various elements in a metadata definition.
        /// </para>
        /// </summary>
        /// <value>
        /// The certificate used for signature.
        /// </value>
        public X509Certificate2 Signature { get; set; }
        /// <summary>
        /// <para><b>Optional</b><br/> 
        /// Used to include metadata extensions that are agreed upon 
        /// between a metadata publisher and the consumer.
        /// </para>
        /// </summary>
        /// <value>
        /// The extensions.
        /// </value>
        public Extension Extensions { get; set; } = null;
        /// <summary>
        /// <para><b>*Required*</b><br/> 
        /// Used to describe the role or capabilities of the SAML entity.
        /// </para>
        /// </summary>
        /// <value>
        /// The role descriptor.
        /// </value>
        public object[] ObjectItems { get; set; } = null;       
        /// <summary>
        /// <para><b>Optional</b><br/> 
        /// Used to identifying the organization 
        /// responsible for the SAML entity, it possible 
        /// to include details such as organization’s name, 
        /// display name, URL.
        /// </para>
        /// </summary>
        /// <value>
        /// The organization.
        /// </value>
        public Organization Organization { get; set; }
        /// <summary>
        /// <para><b>Optional</b><br/> 
        /// used to provide various kind of information about 
        /// a contact person such as individuals’ name,
        /// email address and phone numbers.
        /// </para>
        /// </summary>
        /// <value>
        /// The contact persons.
        /// </value>
        public ContactPerson[] ContactPersons { get; set; }
        /// <summary>
        /// <para><b>Optional</b><br/> 
        /// Used to provide a set of locations where additional 
        /// metadata exists for the current SAML entity.
        /// </para>
        /// </summary>
        /// <value>
        /// The additional metadata location field.
        /// </value>
        public AdditionalMetadataLocation[] AdditionalMetadataLocations { get; set; }
        internal MetadataType MetadataType { get; set; }
    }
}
