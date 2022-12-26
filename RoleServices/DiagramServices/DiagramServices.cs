using RoleDatas.DBModels;
using Microsoft.EntityFrameworkCore;
using RoleDataModel.Models;
using Newtonsoft.Json;

namespace RoleServices.DiagramServices;

public class DiagramServices : IDiagramServices
{
    private readonly RoleContext _context;

    public DiagramServices(RoleContext context)
    {
        _context = context;
    }

    public async Task<DiagramModel> GetDiagram(string id)
    {
        var ret = new DiagramModel();
        ret.Roles = await GetRoles(id);
        ret.MayBienAps = await GetMayBienAps(id);
        ret.ThanhCais = await GetThanhCais(id);
        ret.DuongDays = await GetDuongDays(id);
        return ret;
    }

    private async Task<List<GeoJson>> GetDuongDays(string diagramId)
    {
        var ret = new List<GeoJson>();
        var nVDuongDays = await _context.NvDuongdays.AsNoTracking()
        .ToListAsync();
        DuongDayUpdateGeoJson(ret, nVDuongDays);
        return ret;
    }

    private void DuongDayUpdateGeoJson(List<GeoJson> geoJsons, List<NvDuongday> nVDuongDays)
    {
        foreach (var nVDuongDay in nVDuongDays)
        {
            if (!string.IsNullOrEmpty(nVDuongDay.Jsongeo))
            {
                var geoJson = JsonConvert.DeserializeObject<GeoJson>(nVDuongDay.Jsongeo)!;
                geoJson.geometry!.coordinates = JsonConvert.DeserializeObject<List<List<double>>>(geoJson!.geometry!.coordinates!.ToString()!);
                // geoJson.properties = new Properties();
                // Set Properties:
                // Color theo trạng thái hoạt động
                if (nVDuongDay.Hoatdong == "Y")
                {
                    geoJson.properties!.color = nVDuongDay.Maudong;
                }
                else
                {
                    geoJson.properties!.color = nVDuongDay.Maucat;
                }
                // Device Type Name
                geoJson.properties!.deviceTypeName = "duongDay";
                // Id
                geoJson.properties!.id = nVDuongDay.Mapmis;
                geoJsons.Add(geoJson);
            }
        }
    }

    private async Task<List<GeoJson>> GetMayBienAps(string diagramId)
    {
        var ret = new List<GeoJson>();
        var nVMayBienAps = await _context.NvMaybienaps.AsNoTracking()
        .ToListAsync();
        MayBienApUpdateGeoJson(ret, nVMayBienAps);
        return ret;
    }

    private void MayBienApUpdateGeoJson(List<GeoJson> geoJsons, List<NvMaybienap> nVMayBienAps)
    {
        foreach (var nVMayBienAp in nVMayBienAps)
        {
            if (!string.IsNullOrEmpty(nVMayBienAp.Jsongeo))
            {
                var geoJson = JsonConvert.DeserializeObject<GeoJson>(nVMayBienAp.Jsongeo)!;
                // geoJson.properties = new Properties();
                // Set Properties:
                // Color theo trạng thái hoạt động
                if (nVMayBienAp.Hoatdong == "Y")
                {
                    geoJson.properties!.color = nVMayBienAp.Maudong;
                }
                else
                {
                    geoJson.properties!.color = nVMayBienAp.Maucat;
                }
                // Device Type Name
                geoJson.properties!.deviceTypeName = "mayBienAp";
                // Id
                geoJson.properties!.id = nVMayBienAp.Mapmis;
                geoJsons.Add(geoJson);
            }
        }
    }

    private async Task<List<GeoJson>> GetThanhCais(string diagramId)
    {
        var ret = new List<GeoJson>();
        var nVThanhCais = await _context.NvThanhcais.AsNoTracking()
        .ToListAsync();
        ThanhCaiUpdateGeoJson(ret, nVThanhCais);
        return ret;
    }

    private void ThanhCaiUpdateGeoJson(List<GeoJson> geoJsons, List<NvThanhcai> nVThanhCais)
    {
        foreach (var nVThanhCai in nVThanhCais)
        {
            if (!string.IsNullOrEmpty(nVThanhCai.Jsongeo))
            {
                var geoJson = JsonConvert.DeserializeObject<GeoJson>(nVThanhCai.Jsongeo)!;
                // geoJson.properties = new Properties();
                // Set Properties:
                // Color theo trạng thái hoạt động
                if (nVThanhCai.Hoatdong == "Y")
                {
                    geoJson.properties!.color = nVThanhCai.Maudong;
                }
                else
                {
                    geoJson.properties!.color = nVThanhCai.Maucat;
                }
                // Device Type Name
                geoJson.properties!.deviceTypeName = "thanhCai";
                // Id
                geoJson.properties!.id = nVThanhCai.Mapmis;
                geoJsons.Add(geoJson);
            }
        }
    }

    private async Task<List<GeoJson>> GetRoles(string diagramId)
    {
        var ret = new List<GeoJson>();
        var nVRoles = await _context.NvRoles.AsNoTracking()
        .ToListAsync();
        RoleUpdateGeoJson(ret, nVRoles);
        return ret;
    }

    private void RoleUpdateGeoJson(List<GeoJson> geoJsons, List<NvRole> nVRoles)
    {
        foreach (var nVRole in nVRoles)
        {
            if (!string.IsNullOrEmpty(nVRole.Jsongeo))
            {
                var geoJson = JsonConvert.DeserializeObject<GeoJson>(nVRole.Jsongeo)!;
                // geoJson.properties = new Properties();
                // Set Properties:
                // Color theo trạng thái hoạt động
                if (nVRole.Hoatdong == "Y")
                {
                    geoJson.properties!.color = nVRole.Maudong;
                }
                else
                {
                    geoJson.properties!.color = nVRole.Maucat;
                }
                // Device Type Name
                geoJson.properties!.deviceTypeName = "role";
                // Id
                geoJson.properties!.id = nVRole.Mapmis;
                geoJsons.Add(geoJson);
            }
        }
    }

}
