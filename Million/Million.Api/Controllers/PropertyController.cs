using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Million.Api.Filters;
using Million.Core.Models;
using Million.Services.Filters;
using Million.Services.UseCases.PropertyImagesUseCases;
using Million.Services.UseCases.PropertyUseCases;

namespace Million.Api.Controllers
{
    [ApiController]
    [Route("api/property")]
    public class PropertyController : ControllerBase
    {
        private readonly GetPropertiesUseCase _getPropertiesUseCase;
        private readonly CreatePropertyUseCase _createPropertyUseCase;
        private readonly AddPropertyImageUseCase _addPropertyImageUseCase;
        private readonly UpdatePropertyUseCase _updatePropertyUseCase;

        public PropertyController(GetPropertiesUseCase getPropertiesUseCase, CreatePropertyUseCase createPropertyUseCase, AddPropertyImageUseCase addPropertyImageUseCase, UpdatePropertyUseCase updatePropertyUseCase)
        {
            _getPropertiesUseCase = getPropertiesUseCase;
            _createPropertyUseCase = createPropertyUseCase;
            _addPropertyImageUseCase = addPropertyImageUseCase;
            _updatePropertyUseCase = updatePropertyUseCase;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetProperties([FromQuery] PropertyFilter filter)
        {
            var properties = _getPropertiesUseCase.Execute(filter);
            return Ok(properties);
        }

        [HttpPost]
        [ValidateModelState]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateProperty([FromBody] PropertyRequest propertyRequest)
        {
            var property = _createPropertyUseCase.Execute(propertyRequest);
            return Ok(property);
        }

        [HttpPost("image")]
        [ValidateModelState]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreatePropertyImage([FromBody] PropertyImageRequest propertyImageRequest)
        {
            var propertyImage = _addPropertyImageUseCase.Execute(propertyImageRequest);
            return Ok(propertyImage);
        }

        [HttpPatch("{id}")]
        [ValidateModelState]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateProperty(Guid id, [FromBody] JsonPatchDocument<PropertyRequest> patchDocument)
        {
            var propertyRequest = new PropertyRequest();
            patchDocument.ApplyTo(propertyRequest);
            var property = _updatePropertyUseCase.Execute(id, propertyRequest);
            return Ok(property);
        }

        [ValidateModelState]
        [HttpPatch("{id}/price")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdatePriceProperty(Guid id, [FromBody] PropertyPriceRequest propertyPriceRequest)
        {
            var property = _updatePropertyUseCase.ExecuteUpdatePrice(id, propertyPriceRequest);
            return Ok(property);
        }
    }
}
