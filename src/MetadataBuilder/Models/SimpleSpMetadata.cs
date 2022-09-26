using System.Security.Cryptography.X509Certificates;

namespace Saml.MetadataBuilder
{
    public class SimpleSpMetadata : SpMetadata
    {
        public IndexedEndpoint AssertionConsumerService { get; set; }
        public IndexedEndpoint ArtifactResolutionService { get; set; }
        public Endpoint SingleLogoutServiceEndpoint { get; set; }
        public LocalizedName[] ServiceNames { get; set; } = new LocalizedName[0];
        public LocalizedName[] ServiceDescriptions { get; set; } = new LocalizedName[0];
        public RequestedAttribute[] RequestedAttributes { get; set; } = new RequestedAttribute[0];//optional
        public X509Certificate2 EncryptingCertificate { get; set; }
        public X509Certificate2 SigningCertificate { get; set; }


        //internal new IndexedEndpoint[] AssertionConsumerServices
        //{
        //    get
        //    {
        //        if (AssertionConsumerService != null)
        //        {
        //            return new IndexedEndpoint[] {AssertionConsumerService};
        //        }
        //        return null;
        //    }            
        //}

        //internal new Endpoint[] SingleLogoutServiceEndpoints
        //{
        //    get
        //    {
        //        if (SingleLogoutServiceEndpoint != null)
        //        {
        //            return new Endpoint[]{SingleLogoutServiceEndpoint };
        //        }
        //        return null;
        //    }
        //}


        //public SimpleSpMetadata()
        //{
        //    if (SingleLogoutServiceEndpoint != null)
        //    {
        //        SingleLogoutServiceEndpoints = new Endpoint[]
        //        {
        //            SingleLogoutServiceEndpoint
        //        };
        //    }

        //    AttributeConsumingService = new AttributeConsumingService[]
        //    {
        //            new AttributeConsumingService
        //            {
        //            ServiceDescriptions = ServiceDescriptions,
        //            ServiceNames = ServiceNames,
        //            RequestedAttributes = RequestedAttributes
        //            }
        //    };

        //        if (ArtifactResolutionService != null)
        //        {
        //            ArtifactResolutionServices = new IndexedEndpoint[]
        //            {
        //            ArtifactResolutionService
        //            };
        //        }


        //    }
    }
}
