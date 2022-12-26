using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoleDataModel.Models;
using RoleServices;
using RoleServices.DiagramServices;

namespace RoleAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class DiagramController : ControllerBase
{
    private readonly ILogger<DiagramController> _logger;
    private readonly IDiagramServices _diagramServices;

    public DiagramController(ILogger<DiagramController> logger, IDiagramServices diagramServices)
    {
        _logger = logger;
        _diagramServices = diagramServices;
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetDiagram(string id)
    {
        var ret = await _diagramServices.GetDiagram(id);
        return Ok(ret);
    }
}