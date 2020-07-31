using BusinessLogic.Options;
using Microsoft.AspNetCore.Mvc;

namespace Angular.Controllers
{
    [ApiController]
    [Route("api/options")]
    public class OptionsController : ControllerBase
    {
        private readonly IOptionsService _optionsService;

        public OptionsController(IOptionsService optionsService)
        {
            _optionsService = optionsService;
        }
        
        [HttpGet, Route("customers")]
        public IActionResult Customers(string keyword)
        {
            var result = _optionsService.GetCustomers(keyword);
            return Ok(result);
        }
    }
}