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
            try
            {
                await _duongDayServices.AddDuongDay(item);
                return Ok(new
                {
                    fail = false,
                    message = "Thêm mới thông tin 'Đường dây' thành công.",
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
        [HttpPost("update-dd")]
        public async Task<ActionResult> UpdateDuongDay(NvDuongday item)
        {
            try
            {
                await _duongDayServices.UpdateDuongDay(item);
                return Ok(new
                {
                    fail = false,
                    message = "Cập nhật thông tin 'Đường dây' thành công.",
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
        [HttpGet("get-file-dinh-kem-dd")]
        public async Task<IActionResult> GetFileDinhKem(string MaLoaiThietBi, string MaDT)
        {
            var ret = await _duongDayServices.GetFileDinhKem(MaLoaiThietBi, MaDT);
            return Ok(ret);
        }

        [AllowAnonymous]
        [HttpGet("get-dt-lien-quan")]
        public async Task<IActionResult> GetDTLienQuan(string MaDuongDay)
        {
            var ret = await _duongDayServices.GetDTLienQuan(MaDuongDay);
            return Ok(ret);
        }

        [AllowAnonymous]
        [HttpPost("add-dt-lien-quan")]
        public async Task<IActionResult> AddDTLienQuan(NvThietbithuocdd item)
        {
            try
            {
                await _duongDayServices.AddDTLienQuan(item);
                return Ok(new
                {
                    fail = false,
                    message = "Thêm mới đối tượng liên quan thành công.",
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
        [HttpPost("delete-dt-lien-quan")]
        public async Task<IActionResult> DeleteDTLienQuan(NvThietbithuocdd item)
        {
            try
            {
                await _duongDayServices.DeleteDTLienQuan(item);
                return Ok(new
                {
                    fail = false,
                    message = "Xóa đối tượng liên quan thành công.",
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
    }
}