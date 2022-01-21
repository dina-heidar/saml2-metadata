using System;

namespace MetadataBuilder.Bindings
{
    public class Binding
    {
        private readonly string binding;
        public Binding(string binding)
        {
            this.binding = binding;
        }

        public EndpointType Url(string location, string responseLocation = null)
        {
            Uri uriResult;
            bool result1 = Uri.TryCreate(location, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            if (!result1)
            {
                throw new Saml2MetadataSerializationException("Endpoint location is not a valid Url");
            }

            if (responseLocation != null)
            {
                bool result2 = Uri.TryCreate(responseLocation, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

                if (!result2)
                {
                    throw new Saml2MetadataSerializationException("Endpoint response location is not a valid Url");
                }
            }

            var endpoint = new EndpointType
            {
                Binding = binding,
                Location = location,
                ResponseLocation = responseLocation //optional
            };
            return endpoint;
        }


        public IndexedEndpointType Url(string location, int index, bool isDefault = false)
        {
            Uri uriResult;
            bool result1 = Uri.TryCreate(location, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            if (!result1)
            {
                throw new Saml2MetadataSerializationException("Endpoint location is not a valid Url");
            }

            var indexEndpoint = new IndexedEndpointType
            {
                Binding = binding,
                Location = location,
                index = Convert.ToUInt16(index),
                isDefault = isDefault,
                isDefaultSpecified = true
            };
            return indexEndpoint;
        }
    }
}