using MetadataBuilder.Bindings;

namespace MetadataBuilder.Endpoints
{
    public static class SingleLogoutService
    {
        public static Binding Post => new Binding(Constants.Bindings.Post);
        public static Binding Redirect => new Binding(Constants.Bindings.Redirect);       
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

