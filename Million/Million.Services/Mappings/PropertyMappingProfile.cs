using AutoMapper;
using Million.Core.Entities;
using Million.Core.Models;

namespace Million.Services.Mappings
{
    public sealed class PropertyMappingProfile : Profile
    {
        public PropertyMappingProfile()
        {
            CreateMap<Property, PropertyResponse>()
                .ReverseMap();

            CreateMap<Property, PropertyRequest>()
                .ReverseMap();
        }
    }
}
