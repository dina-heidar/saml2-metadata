using System.Threading;
using System.Threading.Tasks;

namespace Saml.MetadataBuilder
{
    public interface IMetadataReader
    {
        public Task<EntityDescriptor> Read(string address, CancellationToken cancel); 
    }
}
