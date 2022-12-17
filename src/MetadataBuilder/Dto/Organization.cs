﻿// Copyright (c) 2022 Dina Heidar
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

using System.Collections.Generic;

namespace Saml.MetadataBuilder
{
    /// <summary>
    /// The organization inforamtion
    /// </summary>
    public class Organization
    {
        /// <summary>
        /// Gets or sets the display name of the organization. This is optional. 
        /// </summary>
        /// <value>
        /// The display name of the organization.
        /// </value>
        public IList<LocalizedName> OrganizationDisplayName { get; set; }
        /// <summary>
        /// Gets or sets the name of the organization. This is optional. 
        /// </summary>
        /// <value>
        /// The name of the organization.
        /// </value>
        public IList<LocalizedName> OrganizationName { get; set; }
        /// <summary>
        /// Gets or sets the organization URL. This is optional.
        /// </summary>
        /// <value>
        /// The organization URL.
        /// </value>
        public IList<LocalizedUri> OrganizationURL { get; set; }
    }
}
