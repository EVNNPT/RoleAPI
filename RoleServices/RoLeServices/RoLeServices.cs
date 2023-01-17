using RoleDatas.DBModels;
using Microsoft.EntityFrameworkCore;

namespace RoleServices;
public class RoLeServices : IRoLeServices
{
    private readonly RoleContext _context;

    public RoLeServices(
        RoleContext context)
    {
        _context = context;
    }

    public async Task<List<NvRole>> GetDSRoLe()
    {
        var rets = new List<NvRole>();
        rets = await _context.NvRoles.OrderBy(it => it.Tenrole).ToListAsync();
        return rets;
    }

    public async Task<NvRole> GetDetailRoLe(string MaPMIS)
    {
        var rets = new NvRole();
        rets = await _context.NvRoles.Where(it => it.Mapmis == MaPMIS).FirstOrDefaultAsync();
        return rets;
    }

    public async Task AddRoLe(NvRole item)
    {
        try
        {
            _ = await _context.NvRoles.AddAsync(item);
            _ = await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task UpdateRoLe(NvRole item)
    {
        var ret = await _context.NvRoles.Where(it => it.Mapmis == item.Mapmis).FirstOrDefaultAsync();
        if (ret == null)
        {
            throw new KeyNotFoundException($"Không tìm thấy bản ghi với Id = {item.Mapmis}");
        }
        ret.Madvql = item.Madvql;
        ret.Tencongty = item.Tencongty;
        ret.Truyentaidien = item.Truyentaidien;
        ret.Tenrole = item.Tenrole;
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
        ret.Tbbaove = item.Tbbaove;
        ret.Tubv = item.Tubv;
        ret.Cottenhienthi = item.Cottenhienthi;
        ret.Dahienthitrensd = item.Dahienthitrensd;
        ret.Hienthiten = item.Hienthiten;
        ret.Hoatdong = item.Hoatdong;
        ret.Tthientai = item.Tthientai;
        ret.Maudong = item.Maudong;
        ret.Maucat = item.Maucat;
        ret.Daunoidau = item.Daunoidau;
        ret.Daunoicuoi = item.Daunoicuoi;
        ret.Ghichu = item.Ghichu;

        var getDSDDs = await _context.NvThietbithuocdds.Where(it => it.Matbkhac == item.Mapmis && it.Loaitbkhac == "RoLe").ToListAsync();
        for (var i = 0; i < getDSDDs.Count; i++)
        {
            var getDDs = await _context.NvDuongdays.Where(it => it.Id == getDSDDs[i].Maduongday).ToListAsync();
            for (var k = 0; k < getDDs.Count; k++)
            {
                getDDs[k].Tthientai = item.Tthientai;
            }
            var getDSTBs = await _context.NvThietbithuocdds.Where(it => it.Maduongday == getDSDDs[i].Maduongday).ToListAsync();
            for (var j = 0; j < getDSTBs.Count; j++)
            {
                switch (getDSTBs[j].Loaitbkhac)
                {
                    case "ThanhCai":
                        var tc = await _context.NvThanhcais.Where(it => it.Mapmis == getDSTBs[j].Matbkhac).FirstOrDefaultAsync();
                        if (tc != null)
                        {
                            tc.Tthientai = item.Tthientai;
                        }
                        break;
                    case "MayBienAp":
                        var mba = await _context.NvMaybienaps.Where(it => it.Mapmis == getDSTBs[j].Matbkhac).FirstOrDefaultAsync();
                        if (mba != null)
                        {
                            mba.Tthientai = item.Tthientai;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        _ = await _context.SaveChangesAsync();
    }

    public async Task DeleteRoLe(string id)
    {
        try
        {
            var item = await _context.NvRoles.Where(it => it.Mapmis == id).FirstOrDefaultAsync();
            if (item == null)
            {
                throw new KeyNotFoundException($"Không tìm thấy bản ghi với Id = {id}");
            }
            _context.NvRoles.Remove(item);
            _ = await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<List<NvFiledinhkem>> GetFileDinhKem(string MaLoaiThietBi, string MaDT)
    {
        var rets = new List<NvFiledinhkem>();
        rets = await _context.NvFiledinhkems.Where(it => it.Maloaithietbi == MaLoaiThietBi && it.Madt == MaDT).ToListAsync();
        return rets;
    }
}
