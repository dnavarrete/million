using Microsoft.AspNetCore.Mvc;
using Million.Core.Models;
using Million.Services.Filters;
using Million.Services.UseCases;

namespace Million.Api.Controllers
{
    [ApiController]
    [Route("api/property")]
    public class PropertyController : ControllerBase
    {
        private readonly GetPropertiesUseCase _getPropertiesUseCase;
        private readonly CreatePropertyUseCase _createPropertyUseCase;

        public PropertyController(GetPropertiesUseCase getPropertiesUseCase, CreatePropertyUseCase createPropertyUseCase)
        {
            _getPropertiesUseCase = getPropertiesUseCase;
            _createPropertyUseCase = createPropertyUseCase;
        }

        [HttpGet]
        public IActionResult GetProperties([FromQuery] PropertyFilter filter)
        {
            var properties = _getPropertiesUseCase.Execute(filter);
            return Ok(properties);
        }

        [HttpPost]
        public IActionResult CreateProperty([FromBody] PropertyRequest filter)
        {
            var property = _createPropertyUseCase.Execute(filter);
            return Ok(property);
        }
    }
}
