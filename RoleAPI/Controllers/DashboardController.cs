using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoleDatas.DBModels;
using RoleServices;

namespace RoleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly RoleContext _context;
        private readonly IDashboardServices _dashboardServices;

        public DashboardController(ILogger<DashboardController> logger, RoleContext context, IDashboardServices dashboardServices)
        {
            _logger = logger;
            _context = context;
            _dashboardServices = dashboardServices;
        }

        [AllowAnonymous]
        [HttpGet("get-sl-tb")]
        public async Task<IActionResult> GetSoLuongTB()
        {
            var rets = await _dashboardServices.GetSoLuongTB();
            return Ok(rets);
        }

        [AllowAnonymous]
        [HttpGet("get-sltb-dong-cat")]
        public async Task<IActionResult> GetSLTBDongCat()
        {
            var rets = await _dashboardServices.GetSLTBDongCat();
            return Ok(rets);
        }
    }
}