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

namespace Saml2Metadata
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Saml2Metadata.SSODescriptor" />
    public class IDPSSODescriptor : SSODescriptor
    {
        /// <summary>
        /// Gets or sets the single sign on service.
        /// </summary>
        /// <value>
        /// The single sign on service.
        /// </value>
        public Endpoint[] SingleSignOnServices { get; set; }

        /// <summary>
        /// Gets or sets the name identifier mapping service.
        /// </summary>
        /// <value>
        /// The name identifier mapping service.
        /// </value>
        public Endpoint[] NameIdMappingServices { get; set; }

        /// <summary>
        /// Gets or sets the assertion identifier request service.
        /// </summary>
        /// <value>
        /// The assertion identifier request service.
        /// </value>
        public Endpoint[] AssertionIdRequestServices { get; set; }

        /// <summary>
        /// Gets or sets the attribute profile field.
        /// </summary>
        /// <value>
        /// The attribute profile field.
        /// </value>
        public string[] AttributeProfiles { get; set; }

        /// <summary>
        /// Gets or sets the attributes.
        /// </summary>
        /// <value>
        /// The attributes.
        /// </value>
        public Attribute[] Attributes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [want authn requests signed].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [want authn requests signed]; otherwise, <c>false</c>.
        /// </value>
        public bool WantAuthnRequestsSigned { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [want authn requests signed field specified].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [want authn requests signed field specified]; otherwise, <c>false</c>.
        /// </value>
        public bool WantAuthnRequestsSignedFieldSpecified { get; set; } = true;
    }
}

