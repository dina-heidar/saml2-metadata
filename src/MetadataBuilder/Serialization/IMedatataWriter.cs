using System.Threading.Tasks;
using System.Xml;

namespace Saml.MetadataBuilder
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMedatataWriter
    {        
        //Task<XmlDocument> For<SpMetadata>(SpMetadata sp);
        /// <summary>
        /// Outputs the specified entity.
        /// </summary>
        /// <param name="entityDescriptor">The entity descriptor.</param>
        /// <returns></returns>
        XmlDocument Output(EntityDescriptor entityDescriptor);
    }
}
