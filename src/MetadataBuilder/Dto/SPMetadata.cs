//using MetadataBuilder.Constants;
//using Saml.MetadataBuilder;
//using System.Collections.Generic;
//using System.Security.Cryptography.X509Certificates;

//namespace MetadataBuilder.Dto
//{
//    public class SPMetadata : EntityDescriptor
//    {
//        public string NameIdFormat { get; set; }
//        public IndexedEndpoint[] AssertionConsumerServices { get; set; }
//        public IndexedEndpoint[] ArtifactResolutionServices { get; set; }
//        public Saml.MetadataBuilder.Endpoint SingleLogoutServiceEndpoint { get; set; }
//        public bool AuthnRequestsSigned { get; set; }
//        public bool WantAssertionsSigned { get; set; }


//        public LocalizedName[] ServiceNames { get; set; }
//        public LocalizedName[] ServiceDescriptions { get; set; }
//        public RequestedAttribute[] RequestedAttributes { get; set; } //optional
//        //SPSSODescriptorType =>keydescriptor
//        public IDictionary<Saml.MetadataBuilder.Constants.KeyTypes, X509Certificate2> EncryptingSiginingCertificate { get; set; }  //optional if want authnreqestSigend is false   

//        private AttributeConsumingService AttributeConsumingService { get; set; }

//        public SPMetadata()
//        {
//            RoleDescriptor = new RoleDescriptor
//            {
//                ProtocolSupportEnumeration = ProtocolSupportEnumerationTypes.Default,
//            };
//            AttributeConsumingService = new AttributeConsumingService
//            {
//                ServiceDescriptions = ServiceDescriptions,
//                ServiceNames = ServiceNames,
//            };
//        }

//        //public XmlDocument Build()
//        //{            
//        //    var xml = _writer.Output(this);
//        //    return xml;

//        //}
//    }
//}
