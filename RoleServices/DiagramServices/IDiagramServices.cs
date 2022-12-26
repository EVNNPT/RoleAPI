using RoleDatas.DBModels;
using Microsoft.EntityFrameworkCore;
using RoleDataModel.Models;

namespace RoleServices.DiagramServices;
public interface IDiagramServices
{
    Task<DiagramModel> GetDiagram(string id);
}