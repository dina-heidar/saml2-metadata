using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Xml;
using System.Collections.Generic;

namespace Saml.MetadataBuilder
{
    /// <summary>
    /// Saml2SPConfiguration class
    /// </summary>
    public class ServiceProviderConfiguration : BaseConfiguration
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceProviderConfiguration"/> class.
        /// </summary>
        public ServiceProviderConfiguration() { }
        /// <summary>Gets or sets the signature.</summary>
        /// <value>The signature.</value>
        public Signature Signature { get; set; }
        /// <summary>Gets or sets the signing credentials.</summary>
        /// <value>The signing credentials.</value>
        public SigningCredentials SigningCredentials { get; set; }
        /// <summary>Gets the key infos.</summary>
        /// <value>The key infos.</value>
        public ICollection<KeyInfo> KeyInfos { get; } = new List<KeyInfo>();
        /// <summary>Gets or sets the token endpoint.</summary>
        /// <value>The token endpoint.</value>
        public string TokenEndpoint { get; set; }
        /// <summary>Gets or sets the name identifier format.</summary>
        /// <value>The name identifier format.</value>
        public ICollection<string> NameIdFormat { get; set; }
        /// <summary>Gets or sets the assertion consumer services indexed endpoint.</summary>
        /// <value>The assertion consumer services.</value>
        public ICollection<IndexedEndpoint> AssertionConsumerServices { get; set; }
        //{
        //    get
        //    {
        //        var t = new List<IndexedEndpoint>();
        //           t.Add(AssertionConsumerService.Post.Url("test", 0));
        //        return t;
        //    }
        //}
        /// <summary>Gets or sets the single logout services endpoints.</summary>
        /// <value>The single logout services.</value>
        public ICollection<Endpoint> SingleLogoutServices { get; set; }
		//{
		//    get
		//    {
		//        var t = new List<Endpoint>();
		//        t.Add(SingleLogoutService.Post.Url("https://"));
		//        return t;
		//    }
		//}
	}
}