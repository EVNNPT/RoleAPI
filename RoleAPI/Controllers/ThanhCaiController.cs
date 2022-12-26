using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoleDatas.DBModels;
using RoleServices;

namespace RoleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ThanhCaiController : ControllerBase
    {
        private readonly ILogger<ThanhCaiController> _logger;
        private readonly RoleContext _context;
        private readonly IThanhCaiServices _thanhCaiServices;

        public ThanhCaiController(ILogger<ThanhCaiController> logger, RoleContext context, IThanhCaiServices thanhCaiServices)
        {
            _logger = logger;
            _context = context;
            _thanhCaiServices = thanhCaiServices;
        }

        [AllowAnonymous]
        [HttpGet("get-ds-tc")]
        public async Task<IActionResult> GetDSThanhCai()
        {
            var rets = await _thanhCaiServices.GetDSThanhCai();
            return Ok(rets);
        }

        [AllowAnonymous]
        [HttpGet("get-detail-tc")]
        public async Task<IActionResult> GetDetailThanhCai(string MaPMIS)
        {
            var ret = await _thanhCaiServices.GetDetailThanhCai(MaPMIS);
            return Ok(ret);
        }

        [AllowAnonymous]
        [HttpPost("add-tc")]
        public async Task<ActionResult> AddThanhCai(NvThanhcai item)
        {
            try
            {
                await _thanhCaiServices.AddThanhCai(item);
                return Ok(new
                {
                    fail = false,
                    message = "Thêm mới thông tin 'Thanh cái' thành công.",
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
        [HttpPost("update-tc")]
        public async Task<ActionResult> UpdateThanhCai(NvThanhcai item)
        {
            try
            {
                await _thanhCaiServices.UpdateThanhCai(item);
                return Ok(new
                {
                    fail = false,
                    message = "Cập nhật thông tin 'Thanh cái' thành công.",
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
        [HttpGet("get-file-dinh-kem-tc")]
        public async Task<IActionResult> GetFileDinhKem(string MaLoaiThietBi, string MaDT)
        {
            var ret = await _thanhCaiServices.GetFileDinhKem(MaLoaiThietBi, MaDT);
            return Ok(ret);
        }
    }
}