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

        public PropertyController(GetPropertiesUseCase getPropertiesUseCase)
        {
            _getPropertiesUseCase = getPropertiesUseCase;
        }

        [HttpGet]
        public IActionResult GetProperties([FromQuery] PropertyFilter filter)
        {
            var properties = _getPropertiesUseCase.Execute(filter);
            return Ok(properties);
        }
    }
}
