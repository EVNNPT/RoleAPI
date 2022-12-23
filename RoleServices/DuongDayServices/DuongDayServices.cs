using RoleDatas.DBModels;
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
}
