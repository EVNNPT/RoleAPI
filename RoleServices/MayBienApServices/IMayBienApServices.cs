using RoleDatas.DBModels;

namespace RoleServices;
public interface IMayBienApServices
{
    Task<List<NvMaybienap>> GetDSMayBienAp();
    Task<NvMaybienap> GetDetailMayBienAp(string MaPMIS);
    Task AddMayBienAp(NvMaybienap item);
    Task UpdateMayBienAp(NvMaybienap item);
    Task DeleteMayBienAp(NvMaybienap item);
    Task<List<NvFiledinhkem>> GetFileDinhKem(string MaLoaiThietBi, string MaDT);
}
