using AutoMapper;
using Million.Core.Entities;
using Million.Core;
using Million.Core.Models;
using Moq;
using Million.Services.UseCases.PropertyUseCases;

namespace MillionNunit
{
    [TestFixture]
    internal class CreatePropertyUseCaseTest
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
        public void Execute_ShouldReturnsPropertyResponse()
        {
            // Arrange
            var propertyRequest = new PropertyRequest 
            {
                Address = "Direccion 1",
                Name = "Nombre 1",
                CodeInternal = "Code 1",
                Id = "68d0943d-6c4d-4f24-bd77-83a4f1af6608",
                IdOwner = "6fa3ff9a-9205-4a54-8451-d9f43c88b365",
                Price = 2500,
                Year = 2020
            };

            var property = new Property
            {
                Address = "Direccion 1",
                Name = "Nombre 1",
                CodeInternal = "Code 1",
                Id = Guid.Parse("68d0943d-6c4d-4f24-bd77-83a4f1af6608"),
                IdOwner = Guid.Parse("6fa3ff9a-9205-4a54-8451-d9f43c88b365"),
                Price = 2500,
                Year = 2020
            };

            var propertyResponse = new PropertyResponse 
            {
                Address = "Direccion 1",
                Name = "Nombre 1",
                Id = "68d0943d-6c4d-4f24-bd77-83a4f1af6608",
                Price = 2500,
                Year = 2020
            };

            _repositoryMock.Setup(r => r.Insert(It.IsAny<Property>()))
                           .Returns(property);

            _mapperMock.Setup(m => m.Map<PropertyResponse>(It.IsAny<Property>()))
                 .Returns(propertyResponse);

            // Act
            var propertyService = new CreatePropertyUseCase(_mapperMock.Object, _repositoryMock.Object);
            var result = propertyService.Execute(propertyRequest);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.GetType(), Is.EqualTo(typeof(PropertyResponse)));
                Assert.That(result.Id, Is.EqualTo("68d0943d-6c4d-4f24-bd77-83a4f1af6608"));
            });
        }
    }
}
