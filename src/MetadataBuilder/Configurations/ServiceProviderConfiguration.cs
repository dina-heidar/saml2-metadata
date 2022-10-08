// Copyright (c) 2022 Dina Heidar
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY
//
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM
//
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
//

//namespace Saml.MetadataBuilder
//{
//	/// <summary>
//	/// ServiceProviderConfiguration class
//	/// </summary>
//	public class ServiceProviderConfiguration : BaseConfiguration
//	{
//		/// <summary>
//		/// Initializes a new instance of the <see cref="ServiceProviderConfiguration"/> class.
//		/// </summary>
//		public ServiceProviderConfiguration() { }
//		/// <summary>Gets or sets the signature.</summary>
//		/// <value>The signature.</value>
//		public Signature Signature { get; set; }
//		/// <summary>Gets or sets the signing credentials.</summary>
//		/// <value>The signing credentials.</value>
//		public SigningCredentials SigningCredentials { get; set; }
//		/// <summary>Gets the key infos.</summary>
//		/// <value>The key infos.</value>
//		public ICollection<KeyInfo> KeyInfos { get; } = new List<KeyInfo>();
//		/// <summary>Gets or sets the token endpoint.</summary>
//		/// <value>The token endpoint.</value>
//		public string TokenEndpoint { get; set; }
//		/// <summary>Gets or sets the name identifier format.</summary>
//		/// <value>The name identifier format.</value>
//		public ICollection<string> NameIdFormat { get; set; }
//		/// <summary>Gets or sets the assertion consumer services indexed endpoint.</summary>
//		/// <value>The assertion consumer services.</value>
//		public ICollection<IndexedEndpoint> AssertionConsumerServices { get; set; }
//		//{
//		//    get
//		//    {
//		//        var t = new List<IndexedEndpoint>();
//		//           t.Add(AssertionConsumerService.Post.Url("test", 0));
//		//        return t;
//		//    }
//		//}
//		/// <summary>Gets or sets the single logout services endpoints.</summary>
//		/// <value>The single logout services.</value>
//		public ICollection<Endpoint> SingleLogoutServices { get; set; }
//		//{
//		//    get
//		//    {
//		//        var t = new List<Endpoint>();
//		//        t.Add(SingleLogoutService.Post.Url("https://"));
//		//        return t;
//		//    }
//		//}
//	}
//}
