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

namespace Saml2Metadata
{
    /// <summary>
    /// 
    /// </summary>
    public class RoleDescriptor
    {

        /// <summary>
        /// Gets or sets the protocol support enumeration.
        /// </summary>
        /// <value>
        /// The protocol support enumeration.
        /// </value>
        public string ProtocolSupportEnumeration { get; set; }
        /// <summary>
        /// Gets or sets the contact person.
        /// </summary>
        /// <value>
        /// The contact person.
        /// </value>
        public ContactPerson[] ContactPersons { get; set; }
        /// <summary>
        /// Gets or sets the organization.
        /// </summary>
        /// <value>
        /// The organization.
        /// </value>
        public Organization Organization { get; set; }

        /// <summary>
        /// Gets or sets the encrypting certificates.
        /// </summary>
        /// <value>
        /// The encrypting certificates.
        /// </value>
        public X509Certificate2[] EncryptingCertificates { get; set; }
        /// <summary>
        /// Gets or sets the signing certificates.
        /// </summary>
        /// <value>
        /// The signing certificates.
        /// </value>
        public X509Certificate2[] SigningCertificates { get; set; }

        /// <summary>
        /// Gets or sets the extensions.
        /// </summary>
        /// <value>
        /// The extensions.
        /// </value>
        public Extension Extensions { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the valid until.
        /// </summary>
        /// <value>
        /// The valid until.
        /// </value>
        public DateTime ValidUntil { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [valid until field specified].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [valid until field specified]; otherwise, <c>false</c>.
        /// </value>
        public bool ValidUntilFieldSpecified { get; set; } = true;

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
        /// Gets or sets the error URL field.
        /// </summary>
        /// <value>
        /// The error URL field.
        /// </value>
        public string ErrorUrlField { get; set; }
    }
}
