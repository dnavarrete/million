using AutoMapper;
using Million.Core.Entities;
using Million.Core.Models;
using Million.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Million.Services.UseCases.PropertyImagesUseCases
{
    public sealed class AddPropertyImageUseCase
    {
        private readonly IMapper _mapper;
        private readonly IRepository<PropertyImage> _repository;

        public AddPropertyImageUseCase(IMapper mapper, IRepository<PropertyImage> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public PropertyImageResponse Execute(PropertyImageRequest propertyImageRequest)
        {
            var propertyImage = _mapper.Map<PropertyImage>(propertyImageRequest);
            _repository.Insert(propertyImage);
            return _mapper.Map<PropertyImageResponse>(propertyImage);
        }
    }
}
