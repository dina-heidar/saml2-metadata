﻿// MIT License
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

using Saml.MetadataBuilder.Constants;

namespace Saml.MetadataBuilder
{
    /// <summary>
    /// SingleLogoutService endpoint with different binding value types.
    /// </summary>
    public static class SingleLogoutServiceTypes
    {
        //// <summary>Gets the binding of type POST.</summary>
        /// <value>The binding of type POST.</value>
        public static BindingExtensions Post => new BindingExtensions(BindingTypes.Post);
        /// <summary>Gets the binding of type REDIRECT.</summary>
        /// <value>The binding of type REDIRECT.</value>
        public static BindingExtensions Redirect => new BindingExtensions(BindingTypes.Redirect);
    }
}


//sso  endpoint types:
//artifactResolutionService => IndexedEndpointType[]
//singleLogoutServiceField => EndpointType[]
//manageNameIDServiceField => EndpointType[] X
//nameIDFormat => string[]


//sp descriptor
//assertionConsumerService => IndexedEndpointType[]
//attributeConsumingService => AttributeConsumingServiceType[] ---what claims we need 

//idp descriptor
//singleSignOnService => EndpointType
//nameIDMappingService => EndpointType
//assertionIDRequestService => EndpointType X

