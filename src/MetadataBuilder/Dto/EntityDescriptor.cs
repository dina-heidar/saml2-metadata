using MetadataBuilder.Schema.Metadata;
using Microsoft.IdentityModel.Xml;
using System;
using System.Xml;

namespace Saml.MetadataBuilder
{
    public class EntityDescriptor
    {
        public Signature Signature { get; set; }

        public Extension Extensions { get; set; }

        public object[] Items { get; set; }

        public Organization Organization { get; set; }

        public ContactPerson[] ContactPerson { get; set; }

        //public AdditionalMetadataLocationType[] additionalMetadataLocationField { get; set; }

        public string EntityID { get; set; }

        public DateTime ValidUntil { get; set; }

        public bool ValidUntilFieldSpecified { get; set; } = true;

        public string CacheDuration { get; set; }

        public string Id {get;set;}

        public XmlAttribute[] AnyAttr { get; set; }
    }
}
