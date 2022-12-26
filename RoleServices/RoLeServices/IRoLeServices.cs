using RoleDatas.DBModels;

namespace RoleServices;
public interface IRoLeServices
{
    Task<List<NvRole>> GetDSRoLe();
    Task<NvRole> GetDetailRoLe(string MaPMIS);
    Task AddRoLe(NvRole item);
    Task UpdateRoLe(NvRole item);
    Task<List<NvFiledinhkem>> GetFileDinhKem(string MaLoaiThietBi, string MaDT);
}