using AutoMapper;
using Million.Core;
using Million.Core.Entities;
using Million.Core.Models;
using Million.Services.Filters;
using Million.Services.Utils;
using System.Linq.Expressions;

namespace Million.Services.UseCases
{
    public sealed class GetPropertiesUseCase
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Property> _repository;

        public GetPropertiesUseCase(IMapper mapper, IRepository<Property> repository) 
        {
            _mapper = mapper;
            _repository = repository;
        }

        public IEnumerable<PropertyResponse> Execute(PropertyFilter filter) 
        {
            Expression<Func<Property, bool>> filterExpression = p => true;

            if (filter.Year.HasValue)
            {
                filterExpression = filterExpression.And(p => p.Year == filter.Year.Value);
            }

            if (filter.MinPrice.HasValue)
            {
                filterExpression = filterExpression.And(p => p.Price >= filter.MinPrice.Value);
            }

            if (filter.MaxPrice.HasValue)
            {
                filterExpression = filterExpression.And(p => p.Price <= filter.MaxPrice.Value);
            }

            var properties = _repository.Get(filterExpression);
            var mappedProperties = _mapper.Map<IEnumerable<PropertyResponse>>(properties);
            return mappedProperties;
        }
    }
}
