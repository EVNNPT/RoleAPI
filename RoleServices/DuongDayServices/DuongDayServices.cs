using RoleDatas.DBModels;
using Microsoft.EntityFrameworkCore;
using RoleDataModel.Models;
using Newtonsoft.Json;

namespace RoleServices;
public class DuongDayServices : IDuongDayServices
{
    private readonly RoleContext _context;

    public DuongDayServices(
        RoleContext context)
    {
        _context = context;
    }

    public async Task<List<NvDuongday>> GetDSDuongDay()
    {
        var rets = new List<NvDuongday>();
        rets = await _context.NvDuongdays.OrderBy(it => it.Tenduongday).ToListAsync();
        return rets;
    }

    public async Task<NvDuongday> GetDetailDuongDay(string MaPMIS)
    {
        var rets = new NvDuongday();
        rets = await _context.NvDuongdays.Where(it => it.Mapmis == MaPMIS).FirstOrDefaultAsync();
        return rets;
    }

    public async Task AddDuongDay(NvDuongday item)
    {
        try
        {
            _ = await _context.NvDuongdays.AddAsync(item);
            _ = await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task UpdateDuongDay(NvDuongday item)
    {
        var ret = await _context.NvDuongdays.Where(it => it.Mapmis == item.Mapmis).FirstOrDefaultAsync();
        if (ret == null)
        {
            throw new KeyNotFoundException($"Không tìm thấy bản ghi với Id = {item.Mapmis}");
        }
        ret.Tenduongday = item.Tenduongday;
        ret.Madvql = item.Madvql;
        ret.Tencongty = item.Tencongty;
        ret.Truyentaidien = item.Truyentaidien;
        ret.Capda = item.Capda;
        ret.Sohieu = item.Sohieu;
        ret.Sohuu = item.Sohuu;
        ret.Ngaylapdat = item.Ngaylapdat;
        ret.Ngayvh = item.Ngayvh;
        ret.Tutram = item.Tutram;
        ret.Tentutram = item.Tentutram;
        ret.Dentram = item.Dentram;
        ret.Tendentram = item.Tendentram;
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
        ret.Daunoidau = item.Daunoidau;
        ret.Daunoicuoi = item.Daunoicuoi;
        ret.Ghichu = item.Ghichu;
        ret.Id = item.Id;

        if (item.Tthientai == "Đóng" && !string.IsNullOrEmpty(ret.Jsongeo))
        {
            var json = JsonConvert.DeserializeObject<CreateOrUpdateFeature>(ret.Jsongeo!);
            json.options.color = ret.Maudong;
            ret.Jsongeo = JsonConvert.SerializeObject(json, Formatting.Indented);
        }
        else if (item.Tthientai == "Cắt" && !string.IsNullOrEmpty(ret.Jsongeo))
        {
            var json = JsonConvert.DeserializeObject<CreateOrUpdateFeature>(ret.Jsongeo!);
            json.options.color = ret.Maucat;
            ret.Jsongeo = JsonConvert.SerializeObject(json, Formatting.Indented);
        }

        _ = await _context.SaveChangesAsync();
    }

    public async Task DeleteDuongDay(string id)
    {
        try
        {
            var item = await _context.NvDuongdays.Where(it => it.Mapmis == id).FirstOrDefaultAsync();
            if (item == null)
            {
                throw new KeyNotFoundException($"Không tìm thấy bản ghi với Id = {id}");
            }
            _context.NvDuongdays.Remove(item);
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

    public async Task<List<DTLienQuanModel>> GetDTLienQuan(string MaDuongDay)
    {
        var rets = new List<DTLienQuanModel>();
        var query1 = from a in _context.NvThietbithuocdds
                     join b in _context.NvMaybienaps
                     on a.Matbkhac equals b.Mapmis
                     where a.Maduongday == MaDuongDay && a.Loaitbkhac == "MayBienAp"
                     select new DTLienQuanModel
                     {
                         Maduongday = a.Maduongday,
                         Loaitbkhac = "MayBienAp",
                         Matbkhac = b.Mapmis,
                         Tenthietbi = b.Tenmba
                     };
        var results1 = await query1.ToListAsync();
        var query2 = from a in _context.NvThietbithuocdds
                     join b in _context.NvRoles
                     on a.Matbkhac equals b.Mapmis
                     where a.Maduongday == MaDuongDay && a.Loaitbkhac == "RoLe"
                     select new DTLienQuanModel
                     {
                         Maduongday = a.Maduongday,
                         Loaitbkhac = "RoLe",
                         Matbkhac = b.Mapmis,
                         Tenthietbi = b.Tenrole
                     };
        var results2 = await query2.ToListAsync();
        var query3 = from a in _context.NvThietbithuocdds
                     join b in _context.NvThanhcais
                     on a.Matbkhac equals b.Mapmis
                     where a.Maduongday == MaDuongDay && a.Loaitbkhac == "ThanhCai"
                     select new DTLienQuanModel
                     {
                         Maduongday = a.Maduongday,
                         Loaitbkhac = "ThanhCai",
                         Matbkhac = b.Mapmis,
                         Tenthietbi = b.Tenthanhcai
                     };
        var results3 = await query3.ToListAsync();
        foreach (var item in results1)
        {
            rets.Add(item);
        }
        foreach (var item in results2)
        {
            rets.Add(item);
        }
        foreach (var item in results3)
        {
            rets.Add(item);
        }
        return rets;
    }

    public async Task AddDTLienQuan(NvThietbithuocdd item)
    {
        try
        {
            _ = await _context.NvThietbithuocdds.AddAsync(item);
            _ = await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task DeleteDTLienQuan(NvThietbithuocdd item)
    {
        try
        {
            _context.NvThietbithuocdds.Remove(item);
            _ = await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
