using AutoMapper;
using Million.Core.Entities;
using Million.Core;
using Million.Core.Models;
using System.Linq.Expressions;
using System.Reflection;

namespace Million.Services.UseCases.PropertyUseCases
{
    public sealed class UpdatePropertyUseCase
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Property> _repository;

        public UpdatePropertyUseCase(IMapper mapper, IRepository<Property> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public PropertyResponse Execute(Guid id, PropertyRequest propertyRequest)
        {
            var property = _repository.Find(id);

            if (property == null)
            {
                return default!;
            }

            if (propertyRequest.Year != default && property.Year != propertyRequest.Year)
            {
                property.Year = propertyRequest.Year;
            }

            if (!string.IsNullOrEmpty(propertyRequest.Address) && property.Address != propertyRequest.Address)
            {
                property.Address = propertyRequest.Address;
            }

            if (!string.IsNullOrEmpty(propertyRequest.Name) && property.Name != propertyRequest.Name)
            {
                property.Name = propertyRequest.Name;
            }

            var updatedProperty = _repository.Update(property);
            return _mapper.Map<PropertyResponse>(updatedProperty);
        }

        public PropertyResponse ExecuteUpdatePrice(Guid id, PropertyPriceRequest propertyPriceRequest)
        {
            var property = _repository.Find(id);

            if (property == null)
            {
                return default!;
            }

            if (propertyPriceRequest.Price != default && property.Price != propertyPriceRequest.Price)
            {
                property.Price = propertyPriceRequest.Price;
            }

            var updatedProperty = _repository.Update(property);
            return _mapper.Map<PropertyResponse>(updatedProperty);
        }
    }
}
