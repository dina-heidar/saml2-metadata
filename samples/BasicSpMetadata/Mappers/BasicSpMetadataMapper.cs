using AutoMapper;
using BasicSpMetadata.Models;

namespace BasicSpMetadata.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BasicSpMetadataViewModel, Saml.MetadataBuilder.BasicSpMetadata>();
    }
}

