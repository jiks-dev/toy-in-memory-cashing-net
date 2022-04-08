using CashingNet.Domain.Entities;
using CashingNet.Domain.Services.Caches;
using Microsoft.AspNetCore.Mvc;

namespace CashingNet.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleController : ControllerBase
    {
        private readonly IEntityCacheManager _cacheManager;

        public ExampleController(IEntityCacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var example = _cacheManager.Get<Example>();
            return Ok(example);
        }
    }
}