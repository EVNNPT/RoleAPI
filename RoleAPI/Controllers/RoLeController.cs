using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoleDatas.DBModels;
using RoleServices;

namespace RoleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoLeController : ControllerBase
    {
        private readonly ILogger<RoLeController> _logger;
        private readonly RoleContext _context;
        private readonly IRoLeServices _roLeServices;

        public RoLeController(ILogger<RoLeController> logger, RoleContext context, IRoLeServices roLeServices)
        {
            _logger = logger;
            _context = context;
            _roLeServices = roLeServices;
        }

        [AllowAnonymous]
        [HttpGet("get-ds-rl")]
        public async Task<IActionResult> GetDSRoLe()
        {
            var rets = await _roLeServices.GetDSRoLe();
            return Ok(rets);
        }

        [AllowAnonymous]
        [HttpGet("get-detail-rl")]
        public async Task<IActionResult> GetDetailRoLe(string MaPMIS)
        {
            var ret = await _roLeServices.GetDetailRoLe(MaPMIS);
            return Ok(ret);
        }

        [AllowAnonymous]
        [HttpPost("add-rl")]
        public async Task<ActionResult> AddRoLe(NvRole item)
        {
            await _roLeServices.AddRoLe(item);
            return Ok(new
            {
                message = "Thêm mới thông tin 'Rơ le' thành công.'",
            });
        }

        [AllowAnonymous]
        [HttpPost("update-rl")]
        public async Task<ActionResult> UpdateRoLe(NvRole item)
        {
            await _roLeServices.UpdateRoLe(item);
            return Ok(new
            {
                message = "Cập nhật thông tin 'Rơ le' thành công.'",
            });
        }
    }
}