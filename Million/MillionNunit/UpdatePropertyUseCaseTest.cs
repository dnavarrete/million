using AutoMapper;
using Million.Core.Entities;
using Million.Core;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Million.Core.Models;
using Million.Services.UseCases.PropertyUseCases;

namespace MillionNunit
{
    [TestFixture]
    internal class UpdatePropertyUseCaseTest
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
        public void Execute_ShouldUpdateAndReturnPropertyResponse()
        {
            // Arrange
            var id = Guid.NewGuid();

            var propertyRequest = new PropertyRequest
            {
                Year = 2023,
                Address = "New Address",
                Name = "New Name"
            };
            var existingProperty = new Property
            {
                Id = id,
                Year = 2022,
                Address = "Old Address",
                Name = "Old Name"
            };
            var updatedProperty = new Property
            {
                Id = id,
                Year = propertyRequest.Year,
                Address = propertyRequest.Address,
                Name = propertyRequest.Name
            };
            var expectedResponse = new PropertyResponse
            {
                Id = $"{id}",
                Year = propertyRequest.Year,
                Address = propertyRequest.Address,
                Name = propertyRequest.Name
            };

            _repositoryMock.Setup(r => r.Find(id)).Returns(existingProperty);
            _repositoryMock.Setup(r => r.Update(It.IsAny<Property>())).Returns(updatedProperty);
            _mapperMock.Setup(m => m.Map<PropertyResponse>(updatedProperty)).Returns(expectedResponse);

            // Act
            var propertyService = new UpdatePropertyUseCase(_mapperMock.Object, _repositoryMock.Object);
            var result = propertyService.Execute(id, propertyRequest);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResponse));
        }

        [Test]
        public void ExecuteUpdatePrice_ShouldUpdatePriceAndReturnPropertyResponse()
        {
            // Arrange
            var id = Guid.NewGuid();

            var propertyPriceRequest = new PropertyPriceRequest
            {
                Price = 100000
            };

            var existingProperty = new Property
            {
                Id = id,
                Price = 90000
            };

            var updatedProperty = new Property
            {
                Id = id,
                Price = propertyPriceRequest.Price
            };

            var expectedResponse = new PropertyResponse
            {
                Id = $"{id}",
                Price = propertyPriceRequest.Price
            };

            _repositoryMock.Setup(r => r.Find(id)).Returns(existingProperty);
            _repositoryMock.Setup(r => r.Update(It.IsAny<Property>())).Returns(updatedProperty);
            _mapperMock.Setup(m => m.Map<PropertyResponse>(updatedProperty)).Returns(expectedResponse);

            // Act
            var propertyService = new UpdatePropertyUseCase(_mapperMock.Object, _repositoryMock.Object);
            var result = propertyService.ExecuteUpdatePrice(id, propertyPriceRequest);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResponse));
        }
    }
}
