using AICodingGame.Core.Services;
using AICodingGame.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace AICodingGame.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BattleController : ControllerBase
{
    private readonly BattleService _service;

    public BattleController(BattleService service)
    {
        _service = service;
    }

    [HttpGet("get")]
    public async Task<IEnumerable<Battle>?> Get()
    {
        return await Task.Run(() => _service.Get());
    }

    [HttpGet("getMembers")]
    public async Task<IEnumerable<BattleMember>?> GetMembers(int battleId)
    {
        return await Task.Run(() => _service.GetMembers(battleId));
    }

    [HttpPost("add")]
    public async void Add(Battle battle)
    {
        await Task.Run(() => _service.Add(battle));
    }

    [HttpPost("update")]
    public async void Update(Battle battle)
    {
        await Task.Run(() => _service.Update(battle));
    }

    [HttpDelete("delete")]
    public async void Delete(Battle battle)
    {
        await Task.Run(() => _service.Remove(battle));
    }
}