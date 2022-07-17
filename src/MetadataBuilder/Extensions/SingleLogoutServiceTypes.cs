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
        public static Binding Post => new Binding(BindingTypes.Post);
        /// <summary>Gets the binding of type REDIRECT.</summary>
        /// <value>The binding of type REDIRECT.</value>
        public static Binding Redirect => new Binding(BindingTypes.Redirect);       
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

