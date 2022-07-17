using Saml.MetadataBuilder;
using System.Xml;

namespace MetadataBuilder
{
    /// <summary>
    /// 
    /// </summary>
    public interface IWriter
    {
        /// <summary>
        /// Outputs the specified entity.
        /// </summary>
        /// <param name="entityDescriptor">The entity descriptor.</param>
        /// <returns></returns>
        public XmlDocument Output(EntityDescriptor entityDescriptor);
    }
}
