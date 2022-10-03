using System;

namespace Saml.MetadataBuilder
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
        /// <exception cref="MetadataBuilder.Saml2MetadataSerializationException">Endpoint location is not a valid Url
        /// or
        /// Endpoint response location is not a valid Url</exception>
        public Endpoint Url(string location, string responseLocation = null)
        {
            Uri uriResult;

            //check if location is a valid http/https url
            bool isValidLocation = Uri.TryCreate(location, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            if (!isValidLocation)
            {
                throw new Saml2MetadataSerializationException("Endpoint location is not a valid Url");
            }

            if (responseLocation != null)
            {
                //check if response location is a valid http/https url
                bool isValidResponseLocation = Uri.TryCreate(responseLocation, UriKind.Absolute, out uriResult)
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
        /// <param name="index">The index (will default to 0 if not provided).</param>
        /// <param name="isDefault">if set to <c>true</c> [is default].</param>
        /// <returns>
        /// IndexedEndpoint
        /// </returns>
        /// <exception cref="MetadataBuilder.Saml2MetadataSerializationException">Endpoint location is not a valid Url</exception>
        public IndexedEndpoint Url(string location, int index, bool isDefault = false)
        {
            Uri uriResult;
           
            //check if location is a valid http/https url
            bool isValidLocation = Uri.TryCreate(location, UriKind.Absolute, out uriResult)
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