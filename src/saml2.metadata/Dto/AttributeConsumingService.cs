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

using System.Linq;

namespace Saml2Metadata
{
    /// <summary>
    /// 
    /// </summary>
    public class AttributeConsumingService
    {
        /// <summary>
        /// Gets or sets the service names.
        /// </summary>
        /// <value>
        /// The service names.
        /// </value>
        public LocalizedName[] ServiceNames { get; set; }

        /// <summary>
        /// Gets or sets the service descriptions.
        /// </summary>
        /// <value>
        /// The service descriptions.
        /// </value>
        public LocalizedName[] ServiceDescriptions { get; set; }

        /// <summary>
        /// Gets or sets the requested attributes.
        /// </summary>
        /// <value>
        /// The requested attributes.
        /// </value>
        public RequestedAttribute[] RequestedAttributes { get; set; }

        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        /// <value>
        /// The index.
        /// </value>
        public ushort? Index { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is default; otherwise, <c>false</c>.
        /// </value>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is default field specified.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is default field specified; otherwise, <c>false</c>.
        /// </value>
        public bool IsDefaultFieldSpecified { get; set; }

        /// <summary>
        /// Determines whether this instance is empty.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is empty; otherwise, <c>false</c>.
        /// </returns>
        internal bool IsEmpty()
        {
            if (!Index.HasValue &&
                ServiceDescriptions.All(x => x.IsEmpty()) &&
                ServiceNames.All(x => x.IsEmpty()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
