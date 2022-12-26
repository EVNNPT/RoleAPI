using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoleDatas.DBModels;
using RoleServices;

namespace RoleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MayBienApController : ControllerBase
    {
        private readonly ILogger<MayBienApController> _logger;
        private readonly RoleContext _context;
        private readonly IMayBienApServices _mayBienApServices;

        public MayBienApController(ILogger<MayBienApController> logger, RoleContext context, IMayBienApServices mayBienApServices)
        {
            _logger = logger;
            _context = context;
            _mayBienApServices = mayBienApServices;
        }

        [AllowAnonymous]
        [HttpGet("get-ds-mba")]
        public async Task<IActionResult> GetDSMayBienAp()
        {
            var rets = await _mayBienApServices.GetDSMayBienAp();
            return Ok(rets);
        }

        [AllowAnonymous]
        [HttpGet("get-detail-mba")]
        public async Task<IActionResult> GetDetailMayBienAp(string MaPMIS)
        {
            var ret = await _mayBienApServices.GetDetailMayBienAp(MaPMIS);
            return Ok(ret);
        }

        [AllowAnonymous]
        [HttpPost("add-mba")]
        public async Task<ActionResult> AddMayBienAp(NvMaybienap item)
        {
            await _mayBienApServices.AddMayBienAp(item);
            return Ok(new
            {
                message = "Thêm mới thông tin 'Máy biến áp' thành công.'",
            });
        }

        [AllowAnonymous]
        [HttpPost("update-mba")]
        public async Task<ActionResult> UpdateMayBienAp(NvMaybienap item)
        {
            await _mayBienApServices.UpdateMayBienAp(item);
            return Ok(new
            {
                message = "Cập nhật thông tin 'Máy biến áp' thành công.'",
            });
        }
    }
}