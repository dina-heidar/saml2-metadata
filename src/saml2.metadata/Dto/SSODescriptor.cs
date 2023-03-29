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

namespace Saml2Metadata
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Saml.MetadataBuilder.RoleDescriptor" />
    public class SSODescriptor : RoleDescriptor
    {
        /// <summary>
        /// Gets or sets the artifact resolution service.
        /// </summary>
        /// <value>
        /// The artifact resolution service.
        /// </value>
        public IndexedEndpoint[] ArtifactResolutionServices { get; set; }

        /// <summary>
        /// Gets or sets the single logout service.
        /// </summary>
        /// <value>
        /// The single logout service.
        /// </value>
        public Endpoint[] SingleLogoutServices { get; set; }

        /// <summary>
        /// <para>Used to configure handlers that are responsible 
        /// for processing name identifier management messages from an IdP. 
        /// These are protocol specific, but generally fall into two classes: 
        /// requests, which inform the SP of a change, and responses, 
        /// which conclude a change event initiated by the SP</para>.
        /// </summary>
        /// <value>
        /// The manage name identifier service.
        /// </value>
        public Endpoint[] ManageNameIdServices { get; set; }

        /// <summary>
        /// Gets or sets the name identifier format.
        /// </summary>
        /// <value>
        /// The name identifier format.
        /// </value>
        public string[] NameIdFormats { get; set; }
    }
}
