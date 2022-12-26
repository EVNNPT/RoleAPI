namespace RoleDataModel.Models;

public class GeoJson
{
    public Geometry? geometry { get; set; }
    public Properties? properties { get; set; }
    public string? type { get; set; }
}

public class Properties
{
    public List<double>? centerPoint { get; set; }
    public string? id { get; set; }
    public string? color { get; set; }
    public string? deviceTypeName { get; set; }
    public string? rotate { get; set; }
}

public class Geometry
{
    public string? type { get; set; }
    public object? coordinates { get; set; }
}

public class Point
{
    public double x { get; set; }
    public double y { get; set; }
}