using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using v1.Application.Drivers.AppServices.Interfaces;
using v1.DTO.Drivers.Requests;

namespace v1.API.Controllers.Drivers
{
    [ApiController]
    [Route("drivers")]
    public class DriversController : ControllerBase
    {
        private readonly IDriversAppService _driversAppService;
        private readonly ILogger<DriversController> _logger;

        public DriversController(ILogger<DriversController> logger, IDriversAppService driversAppService)
        {
            _logger = logger;
            _driversAppService = driversAppService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAll() 
            => Ok(_driversAppService.Get());

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute] string id)
            => Ok(_driversAppService.Get(id));

        [HttpPost]
        [Route("")]
        public IActionResult Create([FromBody] DriverRequest request)
            => Ok(_driversAppService.Create(request));

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] string id, [FromBody] DriverRequest request)
            => Ok(_driversAppService.Update(id, request));

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] string id)
            => Ok(_driversAppService.Delete(id));

    }
}
