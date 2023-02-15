namespace RoleDataModel.Models;

public class DiagramModel
{
    public DiagramModel()
    {
        Roles = new List<CreateOrUpdateFeature>();
        ThanhCais = new List<CreateOrUpdateFeature>();
        MayBienAps = new List<CreateOrUpdateFeature>();
        DuongDays = new List<CreateOrUpdateFeature>();
        Labels = new List<CreateOrUpdateFeature>();
    }
    public List<CreateOrUpdateFeature>? Roles { get; set; }
    public List<CreateOrUpdateFeature>? ThanhCais { get; set; }
    public List<CreateOrUpdateFeature>? MayBienAps { get; set; }
    public List<CreateOrUpdateFeature>? DuongDays { get; set; }
    public List<CreateOrUpdateFeature>? Labels { get; set; }
}