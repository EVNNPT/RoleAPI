using RoleDatas.DBModels;

namespace RoleServices;
public interface IDuongDayServices
{
    Task<List<NvDuongday>> GetDSDuongDay();
    Task<NvDuongday> GetDetailDuongDay(string MaPMIS);
    Task AddDuongDay(NvDuongday item);
    Task UpdateDuongDay(NvDuongday item);
}
