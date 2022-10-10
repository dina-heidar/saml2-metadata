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

using Saml.MetadataBuilder.Constants;

namespace Saml.MetadataBuilder
{
    public class AuthnRequest : RequestAbstract
    {
        public Subject Subject { get; set; }
        public NameIdPolicy NameIdPolicy { get; set; }
        public Conditions Conditions { get; set; }
        public RequestedAuthnContext RequestedAuthnContext //{ get; set; }
        {
            get
            {
                var ee = RequestedAuthnContextExtensions.FormsAuthentication;
                var t = RequestedAuthnContextExtensions.Custom(
                    new[]
                {
                        AuthnContextRefTypes.Kerberose,
                        AuthnContextRefTypes.IntegratedWindowsAuthentication
                }, ComparisonTypes.Minimum);

                return t;
            }
        }
        //public Scoping Scoping { get; set; }
        public bool ForceAuthn { get; set; }
        public bool IsPassive { get; set; }
        public string ProtocolBinding { get; set; }
        public ushort AssertionConsumerServiceIndex { get; set; }
        public string AssertionConsumerServiceURL { get; set; }
        public ushort AttributeConsumingServiceIndex { get; set; }
        public string ProviderName { get; set; }

    }
}
