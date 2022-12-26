using Microsoft.AspNetCore.Authorization;
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

        [AllowAnonymous]
        [HttpGet("get-ds-dd")]
        public async Task<IActionResult> GetDSDuongDay()
        {
            var rets = await _duongDayServices.GetDSDuongDay();
            return Ok(rets);
        }

        [AllowAnonymous]
        [HttpGet("get-detail-dd")]
        public async Task<IActionResult> GetDetailDuongDay(string MaPMIS)
        {
            var ret = await _duongDayServices.GetDetailDuongDay(MaPMIS);
            return Ok(ret);
        }

        [AllowAnonymous]
        [HttpPost("add-dd")]
        public async Task<ActionResult> AddDuongDay(NvDuongday item)
        {
            await _duongDayServices.AddDuongDay(item);
            return Ok(new
            {
                message = "Thêm mới thông tin 'Đường dây' thành công.'",
            });
        }

        [AllowAnonymous]
        [HttpPost("update-dd")]
        public async Task<ActionResult> UpdateDuongDay(NvDuongday item)
        {
            await _duongDayServices.UpdateDuongDay(item);
            return Ok(new
            {
                message = "Cập nhật thông tin 'Đường dây' thành công.'",
            });
        }
    }
}