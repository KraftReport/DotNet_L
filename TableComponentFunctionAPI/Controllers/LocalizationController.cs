using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace TableComponentFunctionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalizationController : ControllerBase
    {
        private readonly IStringLocalizer<LocalizationController> localizer;

        public LocalizationController(IStringLocalizer<LocalizationController> localizer)
        {
            this.localizer = localizer;
        }

        [HttpGet]
        public IActionResult Greet()
        {
            var greeting = localizer["Greet"];
            return Ok(new { Message = greeting });
        }
    }
}
