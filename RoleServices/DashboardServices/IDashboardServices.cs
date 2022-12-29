using RoleDataModel.Models;
using RoleDatas.DBModels;

namespace RoleServices;
public interface IDashboardServices
{
    Task<List<SoLuongTBModel>> GetSoLuongTB();
    Task<List<SLTBDongCatModel>> GetSLTBDongCat();
}
