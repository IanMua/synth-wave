using Microsoft.AspNetCore.Mvc;
using SynthWave.Data.Repositories;
using SynthWave.Models.Entities;

namespace SynthWave.Controllers;

[Route("config")]
[ApiController]
public class ConfigController : ControllerBase
{
    private readonly IAppRepository _appRepository;

    public ConfigController(IAppRepository appRepository)
    {
        _appRepository = appRepository;
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<App>>> GetAllApp()
    {
        return await _appRepository.GetAll();
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateApp(App app)
    {
        int count = await _appRepository.CreateApp(app);
        return count > 0 ? Ok() : BadRequest();
    }
}