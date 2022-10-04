using Saml.MetadataBuilder.Constants;
using System.Collections.Generic;

namespace Saml.MetadataBuilder
{
    /// <summary>
    /// Contact person information
    /// </summary>
    public class ContactPerson
    {
        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>
        /// The company.
        /// </value>
        public string Company { get; set; }

        /// <summary>
        /// Gets or sets the email addresses.
        /// </summary>
        /// <value>
        /// The email addresses.
        /// </value>
        public ICollection<string> EmailAddresses { get; set; }
        /// <summary>
        /// Gets or sets the name of the given.
        /// </summary>
        /// <value>
        /// The name of the given.
        /// </value>
        public string GivenName { get; set; }
        /// <summary>
        /// Gets or sets the surname.
        /// </summary>
        /// <value>
        /// The surname.
        /// </value>
        public string Surname { get; set; }
        /// <summary>
        /// Gets or sets the telephone numbers.
        /// </summary>
        /// <value>
        /// The telephone numbers.
        /// </value>
        public ICollection<string> TelephoneNumbers { get; set; }
        /// <summary>
        /// Gets or sets the type of the contact.
        /// </summary>
        /// <value>
        /// The type of the contact.
        /// </value>
        public ContactEnumType ContactType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactPerson"/> class.
        /// </summary>
        public ContactPerson() {}
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactPerson"/> class.
        /// </summary>
        /// <param name="contactType">Type of the contact.</param>
        public ContactPerson(ContactEnumType contactType)
        {
            ContactType = contactType;
        }
    }
}
