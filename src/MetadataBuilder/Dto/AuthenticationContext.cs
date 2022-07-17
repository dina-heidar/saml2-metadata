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
