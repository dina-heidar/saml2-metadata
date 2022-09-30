using Saml.MetadataBuilder.Constants;

namespace Saml.MetadataBuilder
{
    /// <summary>
    /// 
    /// </summary>
    public static class RequestingAuthenticationContextTypes
    {
        /// <summary>
        /// Gets the forms authentication.
        /// </summary>
        /// <value>
        /// The forms authentication.
        /// </value>
        public static RequestingAuthenticationContext FormsAuthentication =>
            new RequestingAuthenticationContext(AuthnContextRefTypes.UserNameAndPassword);
        /// <summary>
        /// Gets the windows authentication.
        /// </summary>
        /// <value>
        /// The windows authentication.
        /// </value>
        public static RequestingAuthenticationContext WindowsAuthentication =>
           new RequestingAuthenticationContext(AuthnContextRefTypes.IntegratedWindowsAuthentication);

        /// <summary>
        /// Customs the specified authn context reference types.
        /// </summary>
        /// <param name="authnContextRefTypes">The authn context reference types.</param>
        /// <param name="comparisonTypes">The comparison types.</param>
        /// <returns></returns>
        public static AuthenticationContext Custom(string[] authnContextRefTypes,
            string comparisonTypes) =>
            new RequestingAuthenticationContext(authnContextRefTypes).Custom(comparisonTypes);

    }
}
