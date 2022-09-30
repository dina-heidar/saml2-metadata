using Saml.MetadataBuilder.Constants;

namespace Saml.MetadataBuilder
{
    /// <summary>
    /// AssertionConsumerService indexed endpoint with different binding value types.
    /// </summary>
    public static class AssertionConsumerServiceExtensions
    {
        /// <summary>Gets the binding of type POST.</summary>
        /// <value>The binding of type POST.</value>
        public static Binding Post => new Binding(BindingTypes.Post);
        /// <summary>Gets the binding of type REDIRECT.</summary>
        /// <value>The binding of type REDIRECT.</value>
        public static Binding Redirect => new Binding(BindingTypes.Redirect);
        /// <summary>Gets the binding of type ARTIFACT.</summary>
        /// <value>The binding of type ARTIFACT.</value>
        public static Binding Artifact => new Binding(BindingTypes.Artifact);       
    }
}
