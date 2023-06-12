using Million.Core.Entities;
using Million.Core.Models;
using Million.Core;
using Million.Services.Filters;
using System.Linq.Expressions;
using AutoMapper;

namespace Million.Services.UseCases
{
    public sealed class CreatePropertyUseCase
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Property> _repository;

        public CreatePropertyUseCase(IMapper mapper, IRepository<Property> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public PropertyResponse Execute(PropertyRequest propertyRequest)
        {
            var property = _mapper.Map<Property>(propertyRequest);
            _repository.Insert(property);
            return _mapper.Map<PropertyResponse>(property);
        }
    }
}
