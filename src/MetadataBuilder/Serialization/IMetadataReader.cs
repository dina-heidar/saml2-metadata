using System.Threading;
using System.Threading.Tasks;

namespace Saml.MetadataBuilder
{
    public interface IMetadataReader
    {
        Task<EntityDescriptor> Read(string address, CancellationToken cancel);
    }
}
