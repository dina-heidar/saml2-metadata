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

namespace Saml.MetadataBuilder.Constants
{
    /// <summary>
    ///  NameIDFormats constant values
    /// </summary>
    public static class NameIdFormatTypes
    {
        /// <summary>
        /// The email saml xml constant value
        /// </summary>
        public const string Email = "urn:oasis:names:tc:SAML:1.1:nameid-format:emailAddress";
        /// <summary>
        /// The persistent saml xml constant value
        /// </summary>
        public const string Persistent = "urn:oasis:names:tc:SAML:2.0:nameid-format:persistent";
        /// <summary>
        /// The transient saml xml constant value
        /// </summary>
        public const string Transient = "urn:oasis:names:tc:SAML:2.0:nameid-format:transient";
        /// <summary>
        /// The unspecified saml xml constant value
        /// </summary>
        public const string Unspecified = "urn:oasis:names:tc:SAML:1.1:nameid-format:unspecified";
        /// <summary>
        /// The encrypted saml xml constant value
        /// </summary>
        public const string Encrypted = "urn:oasis:names:tc:SAML:2.0:nameid-format:encrypted";
        /// <summary>
        /// The entity identifier saml xml constant value
        /// </summary>
        public const string EntityIdentifier = "urn:oasis:names:tc:SAML:2.0:nameid-format:entity";
        /// <summary>
        /// The kerberos principal name saml xml constant value
        /// </summary>
        public const string KerberosPrincipalName = "urn:oasis:names:tc:SAML:2.0:nameid-format:kerberos";
        /// <summary>
        /// The subject name saml xml constant value
        /// </summary>
        public const string SubjectName = "urn:oasis:names:tc:SAML:1.1:nameid-format:X509SubjectName";
        /// <summary>
        /// The windows domain qualified name saml xml constant value
        /// </summary>
        public const string WindowsDomainQualifiedName = "urn:oasis:names:tc:SAML:1.1:nameid-format:WindowsDomainQualifiedName";
    }
}
