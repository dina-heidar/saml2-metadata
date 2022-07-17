using AutoMapper;
using MetadataBuilder;
using System.Xml;

namespace Saml.MetadataBuilder
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Saml.MetadataBuilder.SingleSignOn" />
    public class ServiceProviderMetadata : SingleSignOn
    {       

        /// <summary>
        /// Gets or sets the assertion consumer services.
        /// </summary>
        /// <value>
        /// The assertion consumer services.
        /// </value>
        public IndexedEndpoint[] AssertionConsumerServices { get; set; }

        /// <summary>
        /// Gets or sets the attribute consuming service.
        /// </summary>
        /// <value>
        /// The attribute consuming service.
        /// </value>
        public AttributeConsumingService[] AttributeConsumingService { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [authn requests signed].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [authn requests signed]; otherwise, <c>false</c>.
        /// </value>
        public bool AuthnRequestsSigned { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [authn requests signed field specified].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [authn requests signed field specified]; otherwise, <c>false</c>.
        /// </value>
        public bool AuthnRequestsSignedFieldSpecified { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether [want assertions signed].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [want assertions signed]; otherwise, <c>false</c>.
        /// </value>
        public bool WantAssertionsSigned { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [want assertions signed field specified].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [want assertions signed field specified]; otherwise, <c>false</c>.
        /// </value>
        public bool WantAssertionsSignedFieldSpecified { get; set; } = true;

        private readonly IWriter _writer;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceProviderMetadata"/> class.
        /// </summary>
        /// <param name="witer">The witer.</param>
        /// <param name="mapper">The mapper.</param>
        public ServiceProviderMetadata(IWriter witer, IMapper mapper)
        {
            _writer = witer;    
            _mapper = mapper;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceProviderMetadata"/> class.
        /// </summary>
        public ServiceProviderMetadata()
        {
        }

        /// <summary>
        /// Builds the specified sp.
        /// </summary>
        /// <returns></returns>
        public XmlDocument Build()
        {                
            var entityDescriptor = _mapper.Map<ServiceProviderMetadata, EntityDescriptor>(this); 
            var xml = _writer.Output(entityDescriptor);
            return xml;

            //return new EntityDescriptor
            //{
            //    EntityID = sp.EntityId,
            //    Items = new object[] { sp },
            //    ContactPerson =  sp.ContactPerson,
            //    Extensions = sp.Extensions,
            //    Organization = sp.Organization,
            //    ValidUntil = sp.ValidUntil,
            //    ValidUntilFieldSpecified = sp.ValidUntilFieldSpecified,
            //    CacheDuration = sp.CacheDuration,   
            //    Id = sp.Id,
            //    //AnyAttr = sp.a
            //};

        }
    }
}

