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

using Saml2Metadata.Constants;

namespace Saml2Metadata
{
    /// <summary>
    /// Represents information about the authentication context requirements 
    /// of authentication statements returned in responses
    /// </summary>
    public class RequestedAuthnContext
    {
        /// <summary>
        /// The authn context reference types
        /// </summary>
        private readonly string[] authnContextRefTypes;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestedAuthnContext"/> class.
        /// </summary>
        /// <param name="authnContextRefTypes">The authn context reference types.</param>
        public RequestedAuthnContext(string[] authnContextRefTypes)
        {
            AuthnContextRefTypes = authnContextRefTypes;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestedAuthnContext"/> class.
        /// </summary>
        /// <param name="authnContextRefTypes">The authn context reference types.</param>
        public RequestedAuthnContext(string authnContextRefTypes)
        {
            AuthnContextRefTypes = new[] { authnContextRefTypes };
        }
        /// <summary>
        /// Authns the context.
        /// </summary>
        /// <param name="comparisonType">Type of the comparison.</param>
        /// <returns></returns>
        private RequestedAuthnContext AuthenticationContext(string comparisonType)
        {
            return new RequestedAuthnContext
            {
                ComparisonType = comparisonType,
                AuthnContextRefTypes = this.authnContextRefTypes
            };
        }

        public RequestedAuthnContext() { }

        /// <summary>
        /// Defaults this instance.
        /// </summary>
        /// <returns></returns>
        public RequestedAuthnContext Default()
        {
            return Exact();
        }

        /// <summary>
        /// Customs the specified comparison type.
        /// </summary>
        /// <param name="comparisonType">Type of the comparison.</param>
        /// <returns></returns>
        public RequestedAuthnContext Custom(string comparisonType)
        {
            return AuthenticationContext(comparisonType);
        }

        /// <summary>
        /// Exacts this instance.
        /// </summary>
        /// <returns></returns>
        public RequestedAuthnContext Exact()
        {
            return AuthenticationContext(ComparisonTypes.Exact);
        }

        /// <summary>
        /// Betters this instance.
        /// </summary>
        /// <returns></returns>
        public RequestedAuthnContext Better()
        {
            return AuthenticationContext(ComparisonTypes.Better);
        }

        /// <summary>
        /// Minimums this instance.
        /// </summary>
        /// <returns></returns>
        public RequestedAuthnContext Minimum()
        {
            return AuthenticationContext(ComparisonTypes.Minimum);
        }

        /// <summary>
        /// Maximums this instance.
        /// </summary>
        /// <returns></returns>
        public RequestedAuthnContext Maximum()
        {
            return AuthenticationContext(ComparisonTypes.Maximum);
        }

        /// <summary>
        /// Gets or sets the authn context reference types.
        /// </summary>
        /// <value>
        /// The authn context reference types.
        /// </value>
        public string[] AuthnContextRefTypes { get; set; }
        /// <summary>
        /// Gets or sets the type of the comparison.
        /// </summary>
        /// <value>
        /// The type of the comparison.
        /// </value>
        public string ComparisonType { get; set; }
        /// <summary>
        /// Gets the authn context class reference.
        /// </summary>
        /// <value>
        /// The authn context class reference.
        /// </value>
        public string AuthnContextClassRef { get; private set; } = "AuthnContextClassRef";
    }
}

