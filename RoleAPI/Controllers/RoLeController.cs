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
            try
            {
                await _roLeServices.AddRoLe(item);
                return Ok(new
                {
                    fail = false,
                    message = "Thêm mới thông tin 'Rơ le' thành công.",
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    fail = true,
                    message = ex.Message,
                });
            }
        }

        [AllowAnonymous]
        [HttpPost("update-rl")]
        public async Task<ActionResult> UpdateRoLe(NvRole item)
        {
            try
            {
                await _roLeServices.UpdateRoLe(item);
                return Ok(new
                {
                    fail = false,
                    message = "Cập nhật thông tin 'Rơ le' thành công.",
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    fail = true,
                    message = ex.Message,
                });
            }
        }

        [AllowAnonymous]
        [HttpPost("delete-rl")]
        public async Task<ActionResult> DeleteRoLe(NvRole item)
        {
            try
            {
                await _roLeServices.DeleteRoLe(item);
                return Ok(new
                {
                    fail = false,
                    message = "Xóa thông tin 'Rơ le' thành công.",
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    fail = true,
                    message = ex.Message,
                });
            }
        }

        [AllowAnonymous]
        [HttpGet("get-file-dinh-kem-rl")]
        public async Task<IActionResult> GetFileDinhKem(string MaLoaiThietBi, string MaDT)
        {
            var ret = await _roLeServices.GetFileDinhKem(MaLoaiThietBi, MaDT);
            return Ok(ret);
        }
    }
}