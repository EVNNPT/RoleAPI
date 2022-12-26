using RoleDatas.DBModels;

namespace RoleServices;
public interface IThanhCaiServices
{
    Task<List<NvThanhcai>> GetDSThanhCai();
    Task<NvThanhcai> GetDetailThanhCai(string MaPMIS);
    Task AddThanhCai(NvThanhcai item);
    Task UpdateThanhCai(NvThanhcai item);
    Task<List<NvFiledinhkem>> GetFileDinhKem(string MaLoaiThietBi, string MaDT);
}