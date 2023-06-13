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

            ReplaceIfChanged(ref property, p => p.Year, propertyRequest.Year);
            ReplaceIfChanged(ref property, p => p.Price, propertyRequest.Price);
            ReplaceIfChanged(ref property, p => p.Address, propertyRequest.Address);
            ReplaceIfChanged(ref property, p => p.Name, propertyRequest.Name);

            var updatedProperty = _repository.Update(property);
            return _mapper.Map<PropertyResponse>(updatedProperty);
        }

        private static void ReplaceIfChanged<TEntity, TProperty>(ref TEntity entity, Expression<Func<TEntity, TProperty>> propertyExpression, TProperty newValue) where TEntity : class
        {
            var memberExpression = propertyExpression.Body as MemberExpression;
            var propertyInfo = memberExpression?.Member as PropertyInfo;
            var currentValue = propertyInfo?.GetValue(entity);

            if (propertyInfo is not null && newValue != null && !Equals(newValue, default) && !Equals(currentValue, newValue) && !(newValue is string strValue && string.IsNullOrEmpty(strValue)))
            {
                propertyInfo.SetValue(entity, newValue);
            }
        }
    }
}
