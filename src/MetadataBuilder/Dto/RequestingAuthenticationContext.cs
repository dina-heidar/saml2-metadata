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

