using System.Xml;

namespace Saml.MetadataBuilder
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMetadataWriter
    {
        /// <summary>
        /// Outputs the specified entity.
        /// </summary>
        /// <param name="entityDescriptor">The entity descriptor.</param>
        /// <returns></returns>
        XmlDocument Output(EntityDescriptor entityDescriptor);
    }
}
