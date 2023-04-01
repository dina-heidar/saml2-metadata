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

namespace Saml2Metadata
{
    /// <summary>
    ///   <br />
    /// </summary>
    public class BindingExtensions
    {
        /// <summary>The binding</summary>
        private readonly string binding;

        /// <summary>Initializes a new instance of the <see cref="BindingExtensions" /> class.</summary>
        /// <param name="binding">The binding.</param>
        public BindingExtensions(string binding)
        {
            this.binding = binding;
        }

        /// <summary>
        /// URLs the specified location.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <param name="responseLocation">The response location.</param>
        /// <returns></returns>
        /// <exception cref="Saml2Metadata.Saml2MetadataSerializationException">
        /// Endpoint location is not a valid Url
        /// or
        /// Endpoint response location is not a valid Url
        /// </exception>
        public Endpoint Url(string location, string responseLocation = null)
        {
            Uri uriResult;

            //check if location is a valid http/https url
            var isValidLocation = Uri.TryCreate(location, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            if (!isValidLocation)
            {
                throw new Saml2MetadataSerializationException("Endpoint location is not a valid Url");
            }

            if (responseLocation != null)
            {
                //check if response location is a valid http/https url
                var isValidResponseLocation = Uri.TryCreate(responseLocation, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

                if (!isValidResponseLocation)
                {
                    throw new Saml2MetadataSerializationException("Endpoint response location is not a valid Url");
                }
            }

            var endpoint = new Endpoint
            {
                Binding = binding,
                Location = location,
                ResponseLocation = responseLocation //optional
            };
            return endpoint;
        }
        /// <summary>
        /// URLs the specified location.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <param name="index">The index.</param>
        /// <param name="isDefault">if set to <c>true</c> [is default].</param>
        /// <returns></returns>
        /// <exception cref="Saml2Metadata.Saml2MetadataSerializationException">Endpoint location is not a valid Url</exception>
        public IndexedEndpoint Url(string location, int index, bool isDefault = false)
        {
            Uri uriResult;

            //check if location is a valid http/https url
            var isValidLocation = Uri.TryCreate(location, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            if (!isValidLocation)
            {
                throw new Saml2MetadataSerializationException("Endpoint location is not a valid Url");
            }

            var indexEndpoint = new IndexedEndpoint
            {
                Binding = binding,
                Location = location,
                Index = Convert.ToUInt16(index),
                IsDefault = isDefault
            };
            return indexEndpoint;
        }
    }
}
