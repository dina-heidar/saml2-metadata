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

using MetadataBuilder.Schema.Metadata;

namespace Saml.MetadataBuilder
{
    internal static class SsoMapper
    {
        public static (string[] nameIdFormats, IndexedEndpointType[] artifactResolutionServices,
            EndpointType[] singleLogoutServices, EndpointType[] manageNameIDServices)
            SetValues(string nameIdFormat, IndexedEndpoint[] artifactResolutionEndpoints,
            Endpoint[] singleLogoutEndpoints, Endpoint[] manageNameIDEndpoints)
        {
            var nameIdFormats = (nameIdFormat != null ? new[] { nameIdFormat } : null);//optional                
            var artifactResolutionServices = (artifactResolutionEndpoints != null ? artifactResolutionEndpoints.MapEach() : null); //optional
            var singleLogoutServices = (singleLogoutEndpoints != null ? singleLogoutEndpoints.MapEach() : null); //optional
            var manageNameIDServices = (manageNameIDEndpoints != null ? manageNameIDEndpoints.MapEach() : null); //optional

            return (nameIdFormats, artifactResolutionServices, singleLogoutServices, manageNameIDServices);
        }

        public static (string[] nameIdFormats, IndexedEndpointType[] artifactResolutionServices,
            EndpointType[] singleLogoutServices)
            SetValues(string nameIdFormat, IndexedEndpoint[] artifactResolutionEndpoints,
            Endpoint[] singleLogoutEndpoints)
        {
            var nameIdFormats = (nameIdFormat != null ? new[] { nameIdFormat } : null);//optional                
            var artifactResolutionServices = (artifactResolutionEndpoints != null ? artifactResolutionEndpoints.MapEach() : null); //optional
            var singleLogoutServices = (singleLogoutEndpoints != null ? singleLogoutEndpoints.MapEach() : null); //optional           

            return (nameIdFormats, artifactResolutionServices, singleLogoutServices);
        }
    }
}
