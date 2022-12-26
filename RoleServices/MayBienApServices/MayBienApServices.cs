using RoleDatas.DBModels;
using Microsoft.EntityFrameworkCore;

namespace RoleServices;
public class MayBienApServices : IMayBienApServices
{
    private readonly RoleContext _context;

    public MayBienApServices(
        RoleContext context)
    {
        _context = context;
    }

    public async Task<List<NvMaybienap>> GetDSMayBienAp()
    {
        var rets = new List<NvMaybienap>();
        rets = await _context.NvMaybienaps.ToListAsync();
        return rets;
    }

    public async Task<NvMaybienap> GetDetailMayBienAp(string MaPMIS)
    {
        var rets = new NvMaybienap();
        rets = await _context.NvMaybienaps.Where(it => it.Mapmis == MaPMIS).FirstOrDefaultAsync();
        return rets;
    }

    public async Task AddMayBienAp(NvMaybienap item)
    {
        try
        {
            _ = await _context.NvMaybienaps.AddAsync(item);
            _ = await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task UpdateMayBienAp(NvMaybienap item)
    {
        var ret = await _context.NvMaybienaps.Where(it => it.Mapmis == item.Mapmis).FirstOrDefaultAsync();
        if (ret == null)
        {
            throw new KeyNotFoundException($"Không tìm thấy bản ghi với Id = {item.Mapmis}");
        }
        ret.Madvql = item.Madvql;
        ret.Tencongty = item.Tencongty;
        ret.Truyentaidien = item.Truyentaidien;
        ret.Tenmba = item.Tenmba;
        ret.Sohieu = item.Sohieu;
        ret.Sohuu = item.Sohuu;
        ret.Ngaylapdat = item.Ngaylapdat;
        ret.Ngayvh = item.Ngayvh;
        ret.Thuoctram = item.Thuoctram;
        ret.Tentram = item.Tentram;
        ret.Hangsx = item.Hangsx;
        ret.Soserial = item.Soserial;
        ret.Sohieubanve = item.Sohieubanve;
        ret.Sododanhso = item.Sododanhso;
        ret.Mach = item.Mach;
        ret.Cottenhienthi = item.Cottenhienthi;
        ret.Dahienthitrensd = item.Dahienthitrensd;
        ret.Hienthiten = item.Hienthiten;
        ret.Hoatdong = item.Hoatdong;
        ret.Tthientai = item.Tthientai;
        ret.Maudong = item.Maudong;
        ret.Maucat = item.Maucat;
        ret.Daunoi = item.Daunoi;
        ret.Ghichu = item.Ghichu;
        _ = await _context.SaveChangesAsync();
    }
}
