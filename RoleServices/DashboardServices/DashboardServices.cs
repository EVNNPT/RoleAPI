using RoleDatas.DBModels;
using Microsoft.EntityFrameworkCore;
using RoleDataModel.Models;

namespace RoleServices;
public class DashboardServices : IDashboardServices
{
    private readonly RoleContext _context;

    public DashboardServices(
        RoleContext context)
    {
        _context = context;
    }

    public async Task<List<SoLuongTBModel>> GetSoLuongTB()
    {
        var rets = new List<SoLuongTBModel>();
        var sldd = _context.NvDuongdays.Select(it => it.Idmap).Distinct().Count();
        var slrl = _context.NvRoles.Count();
        var slmba = _context.NvMaybienaps.Count();
        var sltc = _context.NvThanhcais.Count();
        rets.Add(new SoLuongTBModel()
        {
            Loaitb = "Đường dây",
            Soluong = sldd,
        });
        rets.Add(new SoLuongTBModel()
        {
            Loaitb = "Rơ le",
            Soluong = slrl,
        });
        rets.Add(new SoLuongTBModel()
        {
            Loaitb = "Máy biến áp",
            Soluong = slmba,
        });
        rets.Add(new SoLuongTBModel()
        {
            Loaitb = "Thanh cái",
            Soluong = sltc,
        });
        return rets;
    }

    public async Task<List<SLTBDongCatModel>> GetSLTBDongCat()
    {
        var rets = new List<SLTBDongCatModel>();
        var slddd = _context.NvDuongdays.Where(it => it.Tthientai == "Đóng").Select(it => it.Idmap).Distinct().Count();
        var slddc = _context.NvDuongdays.Where(it => it.Tthientai == "Cắt").Select(it => it.Idmap).Distinct().Count();
        var slrld = _context.NvRoles.Where(it => it.Tthientai == "Đóng").Count();
        var slrlc = _context.NvRoles.Where(it => it.Tthientai == "Cắt").Count();
        var slmbad = _context.NvMaybienaps.Where(it => it.Tthientai == "Đóng").Count();
        var slmbac = _context.NvMaybienaps.Where(it => it.Tthientai == "Cắt").Count();
        var sltcd = _context.NvThanhcais.Where(it => it.Tthientai == "Đóng").Count();
        var sltcc = _context.NvThanhcais.Where(it => it.Tthientai == "Cắt").Count();
        rets.Add(new SLTBDongCatModel()
        {
            Loaitb = "Đường dây",
            Soluongdong = slddd,
            Soluongcat = slddc
        });
        rets.Add(new SLTBDongCatModel()
        {
            Loaitb = "Rơ le",
            Soluongdong = slrld,
            Soluongcat = slrlc
        });
        rets.Add(new SLTBDongCatModel()
        {
            Loaitb = "Máy biến áp",
            Soluongdong = slmbad,
            Soluongcat = slmbac
        });
        rets.Add(new SLTBDongCatModel()
        {
            Loaitb = "Thanh cái",
            Soluongdong = sltcd,
            Soluongcat = sltcc
        });
        return rets;
    }
}
