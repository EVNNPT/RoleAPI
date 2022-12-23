using RoleDatas.DBModels;

namespace RoleServices;
public interface IDuongDayServices
{
    Task<List<NvDuongday>> GetDSDuongDay();
}
