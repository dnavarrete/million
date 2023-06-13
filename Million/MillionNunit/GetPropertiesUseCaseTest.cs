using AutoMapper;
using Million.Core;
using Million.Core.Entities;
using Million.Core.Models;
using Million.Services.Filters;
using Million.Services.UseCases.PropertyUseCases;
using Moq;
using System.Linq.Expressions;

namespace MillionNunit
{
    [TestFixture]
    internal class GetPropertiesUseCaseTest
    {
        private Mock<IRepository<Property>> _repositoryMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void Setup()
        {
            _repositoryMock = new Mock<IRepository<Property>>();
            _mapperMock = new Mock<IMapper>();
        }

        [Test]
        public void Execute_ReturnsFilteredProperties()
        {
            var filter = new PropertyFilter
            {
                Year = 2020
            };

            var properties = new List<Property>
            {
                new Property { Id = Guid.Parse("2c1cf255-4684-48ed-857b-cddb189911c4"), Year = 2020, Price = 150000 },
                new Property { Id = Guid.Parse("6c069192-425e-4e90-9222-1c69743e09a9"), Year = 2019, Price = 250000 },
                new Property { Id = Guid.Parse("d1484618-0f73-4999-b10c-fd85f3b0cf8d"), Year = 2020, Price = 180000 },
                new Property { Id = Guid.Parse("b1e94997-7a21-4542-9649-1c4bb19a070b"), Year = 2021, Price = 90000 }
            };

            var propertiesResult = new List<PropertyResponse>
            {
                new PropertyResponse { Id = "2c1cf255-4684-48ed-857b-cddb189911c4", Year = 2020, Price = 150000 },
                new PropertyResponse { Id = "d1484618-0f73-4999-b10c-fd85f3b0cf8d", Year = 2020, Price = 180000 },
            };

            _repositoryMock.Setup(r => r.Get(It.IsAny<Expression<Func<Property, bool>>>()))
                           .Returns(properties.AsQueryable());

            _mapperMock.Setup(m => m.Map<IEnumerable<PropertyResponse>>(It.IsAny<IEnumerable<Property>>()))
                 .Returns(propertiesResult);

            var propertyService = new GetPropertiesUseCase(_mapperMock.Object, _repositoryMock.Object);
            var result = propertyService.Execute(filter);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(2));

            var propertyIds = result.Select(p => p.Id).ToList();
            CollectionAssert.Contains(propertyIds, "2c1cf255-4684-48ed-857b-cddb189911c4");
            CollectionAssert.Contains(propertyIds, "d1484618-0f73-4999-b10c-fd85f3b0cf8d");
        }
    }
}
