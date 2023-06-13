using AutoMapper;
using Million.Core.Entities;
using Million.Core.Models;
using Million.Core;
using Million.Services.UseCases.PropertyUseCases;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Million.Services.UseCases.PropertyImagesUseCases;

namespace MillionNunit
{
    [TestFixture]
    internal class CreatePropertyImageUseCaseTest
    {
        private Mock<IRepository<PropertyImage>> _repositoryMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void Setup()
        {
            _repositoryMock = new Mock<IRepository<PropertyImage>>();
            _mapperMock = new Mock<IMapper>();
        }

        [Test]
        public void Execute_ShouldReturnsPropertyImageResponse()
        {
            // Arrange
            var propertyImageRequest = new PropertyImageRequest
            {
                Id = "68d0943d-6c4d-4f24-bd77-83a4f1af6608",
                Enabled = true,
                File = "image.png",
                IdProperty = "6fa3ff9a-9205-4a54-8451-d9f43c88b365"
            };

            var propertyImage = new PropertyImage
            {
                Id = Guid.Parse("68d0943d-6c4d-4f24-bd77-83a4f1af6608"),
                Enabled = true,
                File = "image.png",
                IdProperty = Guid.Parse("6fa3ff9a-9205-4a54-8451-d9f43c88b365")
            };

            var propertyResponse = new PropertyImageResponse
            {
                File = "image.png",
            };

            _repositoryMock.Setup(r => r.Insert(It.IsAny<PropertyImage>()))
                           .Returns(propertyImage);

            _mapperMock.Setup(m => m.Map<PropertyImageResponse>(It.IsAny<PropertyImage>()))
                 .Returns(propertyResponse);

            // Act
            var propertyService = new AddPropertyImageUseCase(_mapperMock.Object, _repositoryMock.Object);
            var result = propertyService.Execute(propertyImageRequest);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.GetType(), Is.EqualTo(typeof(PropertyImageResponse)));
                Assert.That(result.File, Is.EqualTo("image.png"));
            });
        }
    }
}
