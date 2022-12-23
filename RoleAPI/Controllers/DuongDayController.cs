using Microsoft.AspNetCore.Mvc;
using RoleDatas.DBModels;
using RoleServices;

namespace RoleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DuongDayController : ControllerBase
    {
        private readonly ILogger<DuongDayController> _logger;
        private readonly RoleContext _context;
        private readonly IDuongDayServices _duongDayServices;

        public DuongDayController(ILogger<DuongDayController> logger, RoleContext context, IDuongDayServices duongDayServices)
        {
            _logger = logger;
            _context = context;
            _duongDayServices = duongDayServices;
        }

        [HttpGet("get-ds-dd")]
        public async Task<IActionResult> Get()
        {
            var rets = await _duongDayServices.GetDSDuongDay();
            return Ok(rets);
        }
    }
}