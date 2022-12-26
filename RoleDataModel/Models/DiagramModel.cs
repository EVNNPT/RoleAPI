namespace RoleDataModel.Models;

public class DiagramModel
{
    public DiagramModel()
    {
        Roles = new List<GeoJson>();
        ThanhCais = new List<GeoJson>();
        MayBienAps = new List<GeoJson>();
        DuongDays = new List<GeoJson>();
    }
    public List<GeoJson>? Roles { get; set; }
    public List<GeoJson>? ThanhCais { get; set; }
    public List<GeoJson>? MayBienAps { get; set; }
    public List<GeoJson>? DuongDays { get; set; }
}