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

namespace Saml.MetadataBuilder.Constants
{
    /// <summary>
    /// 
    /// </summary>
    public static class AuthnContextRefTypes
    {
        /// <summary>
        /// The user name and password
        /// </summary>
        public const string UserNameAndPassword = "urn:oasis:names:tc:SAML:2.0:ac:classes:Password";
        /// <summary>
        /// The password protected transport
        /// </summary>
        public const string PasswordProtectedTransport = "urn:oasis:names:tc:SAML:2.0:ac:classes:PasswordProtectedTransport";
        /// <summary>
        /// The transport layer security client
        /// </summary>
        public const string TransportLayerSecurityClient = "urn:oasis:names:tc:SAML:2.0:ac:classes:TLSClient";
        /// <summary>
        /// The X509 certificate
        /// </summary>
        public const string X509Certificate = "urn:oasis:names:tc:SAML:2.0:ac:classes:X509";
        /// <summary>
        /// The integrated windows authentication
        /// </summary>
        public const string IntegratedWindowsAuthentication = "urn:federation:authentication:windows";
        /// <summary>
        /// The kerberose
        /// </summary>
        public const string Kerberose = "urn:oasis:names:tc:SAML:2.0:ac:classes:Kerberos";
    }
}
