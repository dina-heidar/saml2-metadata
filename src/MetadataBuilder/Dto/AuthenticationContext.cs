﻿// Copyright (c) 2022 Dina Heidar
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
    /// The information added to an assertion regarding details of the technology 
    /// used for the actual authentication action. For example, a service 
    /// provider can request that an identity provider comply with a specific 
    /// authentication method by identifying that method in an authentication request.
    /// </summary>
    public class AuthenticationContext
    {
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
        public string ComparisonType { get; set; } = ComparisonTypes.Exact;
        /// <summary>
        /// Gets or sets a value indicating whether [comparison specified].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [comparison specified]; otherwise, <c>false</c>.
        /// </value>
        public bool ComparisonSpecified { get; set; } = true;
        /// <summary>
        /// Gets the authn context class reference.
        /// </summary>
        /// <value>
        /// The authn context class reference.
        /// </value>
        public string AuthnContextClassRef { get; private set; } = "AuthnContextClassRef";
    }
}
