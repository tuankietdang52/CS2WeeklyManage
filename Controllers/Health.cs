using Microsoft.AspNetCore.Mvc;

namespace CS2WeeklyManage.Controllers
{
    [Route("/health")]
    [ApiController]
    public class Health : ControllerBase
    {
        private readonly ILogger<Health> _logger;

        public Health(ILogger<Health> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Check()
        {
            return Ok("Ok");
        }
    }
}