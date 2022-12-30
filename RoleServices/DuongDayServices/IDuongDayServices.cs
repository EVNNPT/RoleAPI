using RoleDataModel.Models;
using RoleDatas.DBModels;

namespace RoleServices;
public interface IDuongDayServices
{
    Task<List<NvDuongday>> GetDSDuongDay();
    Task<NvDuongday> GetDetailDuongDay(string MaPMIS);
    Task AddDuongDay(NvDuongday item);
    Task UpdateDuongDay(NvDuongday item);
    Task DeleteDuongDay(string id);
    Task<List<NvFiledinhkem>> GetFileDinhKem(string MaLoaiThietBi, string MaDT);
    Task<List<DTLienQuanModel>> GetDTLienQuan(string MaDuongDay);
    Task AddDTLienQuan(NvThietbithuocdd item);
    Task DeleteDTLienQuan(NvThietbithuocdd item);
}
