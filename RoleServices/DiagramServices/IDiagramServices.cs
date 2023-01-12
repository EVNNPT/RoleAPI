using RoleDatas.DBModels;
using Microsoft.EntityFrameworkCore;
using RoleDataModel.Models;

namespace RoleServices.DiagramServices;
public interface IDiagramServices
{
    Task<DiagramModel> GetDiagram(string id);
    Task<string> AddOrUpdateFeature(CreateOrUpdateFeature createOrUpdateFeature);
    Task<string> DeleteFeature(CreateOrUpdateFeature createOrUpdateFeature);
}