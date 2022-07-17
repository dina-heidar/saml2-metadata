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
        public ICollection<LocalizedName> OrganizationDisplayName { get; set; }
        /// <summary>
        /// Gets or sets the name of the organization. This is optional. 
        /// </summary>
        /// <value>
        /// The name of the organization.
        /// </value>
        public ICollection<LocalizedName> OrganizationName { get; set; }
        /// <summary>
        /// Gets or sets the organization URL. This is optional.
        /// </summary>
        /// <value>
        /// The organization URL.
        /// </value>
        public ICollection<LocalizedUri> OrganizationURL { get; set; }      
    }
}
