
using MetadataBuilder.Bindings;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Xml;
using System.Collections.Generic;

namespace MetadataBuilder.Configuration
{
    public class Saml2SPConfiguration : BaseConfiguration
    {
        public Saml2SPConfiguration() { }
        public Signature Signature { get; set; }
        public SigningCredentials SigningCredentials { get; set; }
        public ICollection<KeyInfo> KeyInfos { get; } = new List<KeyInfo>();
        public string TokenEndpoint { get; set; }
        public ICollection<string> NameIdFormat { get; set; }
        public ICollection<IndexedEndpointType> AssertionConsumerServices { get; set; }
        //{
        //    get
        //    {
        //        var t = new List<IndexedEndpointType>();
        //           t.Add(AssertionConsumerService.Post.Url("test", 0));
        //        return t;
        //    }
        //}
        public ICollection<EndpointType> SingleLogoutServices { get; set; }
        //{
        //    get
        //    {
        //        var t = new List<EndpointType>();
        //        t.Add(SingleLogoutService.Post.Url("https://"));
        //        return t;
        //    }
        //}
    }
}