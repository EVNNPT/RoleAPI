﻿using RoleDatas.DBModels;
using Microsoft.EntityFrameworkCore;

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
        rets = await _context.NvDuongdays.ToListAsync();
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
        _ = await _context.SaveChangesAsync();
    }
}