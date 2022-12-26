using RoleDatas.DBModels;
using Microsoft.EntityFrameworkCore;

namespace RoleServices;
public class ThanhCaiServices : IThanhCaiServices
{
    private readonly RoleContext _context;

    public ThanhCaiServices(
        RoleContext context)
    {
        _context = context;
    }

    public async Task<List<NvThanhcai>> GetDSThanhCai()
    {
        var rets = new List<NvThanhcai>();
        rets = await _context.NvThanhcais.ToListAsync();
        return rets;
    }

    public async Task<NvThanhcai> GetDetailThanhCai(string MaPMIS)
    {
        var rets = new NvThanhcai();
        rets = await _context.NvThanhcais.Where(it => it.Mapmis == MaPMIS).FirstOrDefaultAsync();
        return rets;
    }

    public async Task AddThanhCai(NvThanhcai item)
    {
        try
        {
            _ = await _context.NvThanhcais.AddAsync(item);
            _ = await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task UpdateThanhCai(NvThanhcai item)
    {
        var ret = await _context.NvThanhcais.Where(it => it.Mapmis == item.Mapmis).FirstOrDefaultAsync();
        if (ret == null)
        {
            throw new KeyNotFoundException($"Không tìm thấy bản ghi với Id = {item.Mapmis}");
        }
        ret.Tenthanhcai = item.Tenthanhcai;
        ret.Madvql = item.Madvql;
        ret.Tencongty = item.Tencongty;
        ret.Truyentaidien = item.Truyentaidien;
        ret.Capda = item.Capda;
        ret.Sohieu = item.Sohieu;
        ret.Sohuu = item.Sohuu;
        ret.Ngaylapdat = item.Ngaylapdat;
        ret.Ngayvh = item.Ngayvh;
        ret.Thuoctram = item.Thuoctram;
        ret.Tentram = item.Tentram;
        ret.Sohieubanve = item.Sohieubanve;
        ret.Sododanhso = item.Sododanhso;
        ret.Cottenhienthi = item.Cottenhienthi;
        ret.Dahienthitrensd = item.Dahienthitrensd;
        ret.Hienthiten = item.Hienthiten;
        ret.Hoatdong = item.Hoatdong;
        ret.Tthientai = item.Tthientai;
        ret.Maudong = item.Maudong;
        ret.Maucat = item.Maucat;
        ret.Ghichu = item.Ghichu;
        _ = await _context.SaveChangesAsync();
    }

    public async Task<List<NvFiledinhkem>> GetFileDinhKem(string MaLoaiThietBi, string MaDT)
    {
        var rets = new List<NvFiledinhkem>();
        rets = await _context.NvFiledinhkems.Where(it => it.Maloaithietbi == MaLoaiThietBi && it.Madt == MaDT).ToListAsync();
        return rets;
    }
}
