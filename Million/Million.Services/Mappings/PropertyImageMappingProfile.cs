using AutoMapper;
using Million.Core.Entities;
using Million.Core.Models;

namespace Million.Services.Mappings
{
    public sealed class PropertyImageMappingProfile : Profile
    {
        public PropertyImageMappingProfile()
        {
            CreateMap<PropertyImage, PropertyImageResponse>()
                .ReverseMap();

            CreateMap<PropertyImage, PropertyImageRequest>()
                .ReverseMap();
        }
    }
}
