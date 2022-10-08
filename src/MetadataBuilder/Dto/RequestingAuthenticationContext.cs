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

using Saml.MetadataBuilder.Constants;

namespace Saml.MetadataBuilder
{
    /// <summary>
    /// Represents information about the authentication context requirements 
    /// of authentication statements returned in responses
    /// </summary>
    public class RequestingAuthenticationContext
    {
        /// <summary>
        /// The authn context reference types
        /// </summary>
        private readonly string[] authnContextRefTypes;
        /// <summary>
        /// The comparison type
        /// </summary>
        private readonly string comparisonType;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestingAuthenticationContext"/> class.
        /// </summary>
        /// <param name="authnContextRefTypes">The authn context reference types.</param>
        public RequestingAuthenticationContext(string[] authnContextRefTypes)
        {
            this.authnContextRefTypes = authnContextRefTypes;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestingAuthenticationContext"/> class.
        /// </summary>
        /// <param name="authnContextRefTypes">The authn context reference types.</param>
        public RequestingAuthenticationContext(string authnContextRefTypes)
        {
            this.authnContextRefTypes = new[] { authnContextRefTypes };
        }
        /// <summary>
        /// Authns the context.
        /// </summary>
        /// <param name="comparisonType">Type of the comparison.</param>
        /// <returns></returns>
        private AuthenticationContext AuthenticationContext(string comparisonType)
        {
            return new AuthenticationContext
            {
                ComparisonType = comparisonType,
                ComparisonSpecified = true,
                AuthnContextRefTypes = this.authnContextRefTypes
            };
        }

        /// <summary>
        /// Defaults this instance.
        /// </summary>
        /// <returns></returns>
        public AuthenticationContext Default()
        {
            return Exact();
        }

        /// <summary>
        /// Customs the specified comparison type.
        /// </summary>
        /// <param name="comparisonType">Type of the comparison.</param>
        /// <returns></returns>
        public AuthenticationContext Custom(string comparisonType)
        {
            return AuthenticationContext(comparisonType);
        }

        /// <summary>
        /// Exacts this instance.
        /// </summary>
        /// <returns></returns>
        public AuthenticationContext Exact()
        {
            return AuthenticationContext(ComparisonTypes.Exact);
        }

        /// <summary>
        /// Betters this instance.
        /// </summary>
        /// <returns></returns>
        public AuthenticationContext Better()
        {
            return AuthenticationContext(ComparisonTypes.Better);
        }

        /// <summary>
        /// Minimums this instance.
        /// </summary>
        /// <returns></returns>
        public AuthenticationContext Minimum()
        {
            return AuthenticationContext(ComparisonTypes.Minimum);
        }

        /// <summary>
        /// Maximums this instance.
        /// </summary>
        /// <returns></returns>
        public AuthenticationContext Maximum()
        {
            return AuthenticationContext(ComparisonTypes.Maximum);
        }
    }
}

