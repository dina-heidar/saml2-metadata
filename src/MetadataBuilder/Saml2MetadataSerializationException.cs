using System;

namespace Saml.MetadataBuilder
{
    internal class Saml2MetadataSerializationException : Exception
    {
        public Saml2MetadataSerializationException(string message) 
            : base(message) {}

        public Saml2MetadataSerializationException(string message, Exception innerException) 
            : base(message, innerException) {}
    }
}