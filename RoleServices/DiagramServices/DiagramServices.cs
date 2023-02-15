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
        ret.Labels = await GetLabels(id);
        return ret;
    }

    private async Task<List<CreateOrUpdateFeature>> GetRoles(string diagramId)
    {
        var rets = new List<CreateOrUpdateFeature>();
        var nVRoles = await _context.NvRoles.AsNoTracking()
        .ToListAsync();
        foreach (var role in nVRoles)
        {
            if (!string.IsNullOrEmpty(role.Jsongeo))
                rets.Add(JsonConvert.DeserializeObject<CreateOrUpdateFeature>(role.Jsongeo!));
        }
        return rets;
    }

    private async Task<List<CreateOrUpdateFeature>> GetThanhCais(string diagramId)
    {
        var rets = new List<CreateOrUpdateFeature>();
        var nvThanhcais = await _context.NvThanhcais.AsNoTracking()
        .ToListAsync();
        foreach (var thanhCai in nvThanhcais)
        {
            if (!string.IsNullOrEmpty(thanhCai.Jsongeo))
                rets.Add(JsonConvert.DeserializeObject<CreateOrUpdateFeature>(thanhCai.Jsongeo));
        }
        return rets;
    }

    private async Task<List<CreateOrUpdateFeature>> GetMayBienAps(string diagramId)
    {
        var rets = new List<CreateOrUpdateFeature>();
        var nvMaybienaps = await _context.NvMaybienaps.AsNoTracking()
        .ToListAsync();
        foreach (var mayBienAp in nvMaybienaps)
        {
            if (!string.IsNullOrEmpty(mayBienAp.Jsongeo))
                rets.Add(JsonConvert.DeserializeObject<CreateOrUpdateFeature>(mayBienAp.Jsongeo));
        }
        return rets;
    }

    private async Task<List<CreateOrUpdateFeature>> GetDuongDays(string diagramId)
    {
        var rets = new List<CreateOrUpdateFeature>();
        var nvDuongdays = await _context.NvDuongdays.AsNoTracking()
        .ToListAsync();
        foreach (var duongDay in nvDuongdays)
        {
            if (!string.IsNullOrEmpty(duongDay.Jsongeo))
                rets.Add(JsonConvert.DeserializeObject<CreateOrUpdateFeature>(duongDay.Jsongeo));
        }
        return rets;
    }

    private async Task<List<CreateOrUpdateFeature>> GetLabels(string diagramId)
    {
        var rets = new List<CreateOrUpdateFeature>();
        var nvTexts = await _context.NvTexts.AsNoTracking()
        .ToListAsync();
        foreach (var text in nvTexts)
        {
            if (!string.IsNullOrEmpty(text.Jsongeo))
                rets.Add(JsonConvert.DeserializeObject<CreateOrUpdateFeature>(text.Jsongeo));
        }
        return rets;
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
                if (nVRole.Tthientai == "Đóng")
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

    public async Task<string> AddOrUpdateFeature(CreateOrUpdateFeature createOrUpdateFeature)
    {
        switch (createOrUpdateFeature.featureType)
        {
            case FeatureType.DuongDay:
                return await AddOrUpdateDuongDay(createOrUpdateFeature);
            case FeatureType.Role:
                return await AddOrUpdateRole(createOrUpdateFeature);
            case FeatureType.MayBienAp:
                return await AddOrUpdateMayBienAp(createOrUpdateFeature);
            case FeatureType.ThanhCai:
                return await AddOrUpdateThanhCai(createOrUpdateFeature);
            case FeatureType.Label:
                return await AddOrUpdateLabel(createOrUpdateFeature);
            default:
                return "";
        }
    }

    private async Task<string> AddOrUpdateRole(CreateOrUpdateFeature createOrUpdateFeature)
    {
        NvRole role;
        if (string.IsNullOrEmpty(createOrUpdateFeature.id))
        {
            // Thêm mới
            role = new NvRole();
            role.Mapmis = Guid.NewGuid().ToString();
            createOrUpdateFeature.id = role.Mapmis;
            role.Tthientai = "Đóng";
            role.Maudong = "#ff0000";
            role.Maucat = "#0000ff";
            role.Jsongeo = JsonConvert.SerializeObject(createOrUpdateFeature, Formatting.Indented);
            await _context.NvRoles.AddAsync(role);
        }
        else
        {
            // Cập nhật
            role = await _context.NvRoles.Where(r => r.Mapmis == createOrUpdateFeature.id).FirstAsync();
            role.Jsongeo = JsonConvert.SerializeObject(createOrUpdateFeature, Formatting.Indented);
        }
        await _context.SaveChangesAsync();
        return role.Mapmis;
    }

    private async Task<string> AddOrUpdateMayBienAp(CreateOrUpdateFeature createOrUpdateFeature)
    {
        NvMaybienap mayBienAp;
        if (string.IsNullOrEmpty(createOrUpdateFeature.id))
        {
            // Thêm mới
            mayBienAp = new NvMaybienap();
            mayBienAp.Mapmis = Guid.NewGuid().ToString();
            createOrUpdateFeature.id = mayBienAp.Mapmis;
            mayBienAp.Tthientai = "Đóng";
            mayBienAp.Maudong = "#ff0000";
            mayBienAp.Maucat = "#0000ff";
            mayBienAp.Jsongeo = JsonConvert.SerializeObject(createOrUpdateFeature, Formatting.Indented);
            await _context.NvMaybienaps.AddAsync(mayBienAp);
        }
        else
        {
            // Cập nhật
            mayBienAp = await _context.NvMaybienaps.Where(r => r.Mapmis == createOrUpdateFeature.id).FirstAsync();
            mayBienAp.Jsongeo = JsonConvert.SerializeObject(createOrUpdateFeature, Formatting.Indented);
        }
        await _context.SaveChangesAsync();
        return mayBienAp.Mapmis;
    }

    private async Task<string> AddOrUpdateThanhCai(CreateOrUpdateFeature createOrUpdateFeature)
    {
        NvThanhcai thanhCai;
        if (string.IsNullOrEmpty(createOrUpdateFeature.id))
        {
            // Thêm mới
            thanhCai = new NvThanhcai();
            thanhCai.Mapmis = Guid.NewGuid().ToString();
            createOrUpdateFeature.id = thanhCai.Mapmis;
            thanhCai.Tthientai = "Đóng";
            thanhCai.Maudong = "#ff0000";
            thanhCai.Maucat = "#0000ff";
            thanhCai.Jsongeo = JsonConvert.SerializeObject(createOrUpdateFeature, Formatting.Indented);
            await _context.NvThanhcais.AddAsync(thanhCai);
        }
        else
        {
            // Cập nhật
            thanhCai = await _context.NvThanhcais.Where(r => r.Mapmis == createOrUpdateFeature.id).FirstAsync();
            thanhCai.Jsongeo = JsonConvert.SerializeObject(createOrUpdateFeature, Formatting.Indented);
        }
        await _context.SaveChangesAsync();
        return thanhCai.Mapmis;
    }

    private async Task<string> AddOrUpdateDuongDay(CreateOrUpdateFeature createOrUpdateFeature)
    {
        NvDuongday duongDay;
        if (string.IsNullOrEmpty(createOrUpdateFeature.id))
        {
            // Thêm mới
            duongDay = new NvDuongday();
            duongDay.Mapmis = Guid.NewGuid().ToString();
            createOrUpdateFeature.id = duongDay.Mapmis;
            duongDay.Tthientai = "Đóng";
            duongDay.Maudong = "#ff0000";
            duongDay.Maucat = "#0000ff";
            duongDay.Jsongeo = JsonConvert.SerializeObject(createOrUpdateFeature, Formatting.Indented);
            await _context.NvDuongdays.AddAsync(duongDay);
        }
        else
        {
            // Cập nhật
            duongDay = await _context.NvDuongdays.Where(r => r.Mapmis == createOrUpdateFeature.id).FirstAsync();
            duongDay.Jsongeo = JsonConvert.SerializeObject(createOrUpdateFeature, Formatting.Indented);
        }
        await _context.SaveChangesAsync();
        return duongDay.Mapmis;
    }

    private async Task<string> AddOrUpdateLabel(CreateOrUpdateFeature createOrUpdateFeature)
    {
        NvText text;
        if (string.IsNullOrEmpty(createOrUpdateFeature.id))
        {
            // Thêm mới
            text = new NvText();
            text.Ma = Guid.NewGuid().ToString();
            createOrUpdateFeature.id = text.Ma;
            text.Jsongeo = JsonConvert.SerializeObject(createOrUpdateFeature, Formatting.Indented);
            await _context.NvTexts.AddAsync(text);
        }
        else
        {
            // Cập nhật
            text = await _context.NvTexts.Where(r => r.Ma == createOrUpdateFeature.id).FirstAsync();
            text.Jsongeo = JsonConvert.SerializeObject(createOrUpdateFeature, Formatting.Indented);
        }
        await _context.SaveChangesAsync();
        return text.Ma;
    }


    public async Task<string> DeleteFeature(CreateOrUpdateFeature createOrUpdateFeature)
    {
        switch (createOrUpdateFeature.featureType)
        {
            case FeatureType.DuongDay:
                var duongDay = _context.NvDuongdays.Where(it => it.Mapmis == createOrUpdateFeature.id!).FirstOrDefault();
                _context.NvDuongdays.Remove(duongDay!);
                break;
            case FeatureType.Role:
                var role = _context.NvRoles.Where(it => it.Mapmis == createOrUpdateFeature.id!).FirstOrDefault();
                _context.NvRoles.Remove(role!);
                break;
            case FeatureType.MayBienAp:
                var mayBienAp = _context.NvMaybienaps.Where(it => it.Mapmis == createOrUpdateFeature.id!).FirstOrDefault();
                _context.NvMaybienaps.Remove(mayBienAp!);
                break;
            case FeatureType.ThanhCai:
                var thanhCai = _context.NvThanhcais.Where(it => it.Mapmis == createOrUpdateFeature.id!).FirstOrDefault();
                _context.NvThanhcais.Remove(thanhCai!);
                break;
            case FeatureType.Label:
                var label = _context.NvTexts.Where(it => it.Ma == createOrUpdateFeature.id!).FirstOrDefault();
                _context.NvTexts.Remove(label!);
                break;
            default:
                return "";
        }
        await _context.SaveChangesAsync();
        return "";
    }
}
