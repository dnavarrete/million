﻿using Microsoft.AspNetCore.Mvc;
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

        public PropertyController(GetPropertiesUseCase getPropertiesUseCase, CreatePropertyUseCase createPropertyUseCase, AddPropertyImageUseCase addPropertyImageUseCase)
        {
            _getPropertiesUseCase = getPropertiesUseCase;
            _createPropertyUseCase = createPropertyUseCase;
            _addPropertyImageUseCase = addPropertyImageUseCase;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateProperty([FromBody] PropertyRequest propertyRequest)
        {
            var property = _createPropertyUseCase.Execute(propertyRequest);
            return Ok(property);
        }

        [HttpPost("image")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreatePropertyImage([FromBody] PropertyImageRequest propertyImageRequest)
        {
            var propertyImage = _addPropertyImageUseCase.Execute(propertyImageRequest);
            return Ok(propertyImage);
        }
    }
}
