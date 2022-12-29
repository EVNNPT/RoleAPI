namespace RoleDataModel.Models;

public class CreateOrUpdateFeature
{
    public string? id { get; set; }
    public LatLng? centerPoint { get; set; }
    public FeatureType featureType { get; set; }
    public int? rotate { get; set; }
    public object getObject
    {
        get
        {
            var obj = new
            {
                properties = new
                {
                    centerPoint = new double[2] { this.centerPoint!.lat, this.centerPoint!.lng },
                    featureType = (int)this.featureType,
                    rotate = this.rotate,
                    id = id,
                }
            };
            return obj;
        }
    }
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
    public double lat { get; set; }
    public double lng { get; set; }
}