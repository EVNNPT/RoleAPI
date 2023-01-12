namespace RoleDataModel.Models;

public class Options
{
    public double? chieuDai { get; set; }
    public double? chieuRong { get; set; }
    public double? gocXoay { get; set; }
    public double? weight { get; set; }
    public string? color { get; set; }
    public string? lineCap { get; set; }
    public string? lineJoin { get; set; }
}

public class CreateOrUpdateFeature
{
    public string? id { get; set; }
    public FeatureType featureType { get; set; }
    public LatLng? centerPoint { get; set; }
    public List<LatLng>? latLngs { get; set; }
    public Options? options { get; set; }
}

public enum FeatureType
{
    Role = 0,
    ThanhCai = 1,
    MayBienAp = 2,
    DuongDay = 3
}

public class LatLng
{
    public double? lat { get; set; }
    public double? lng { get; set; }
}