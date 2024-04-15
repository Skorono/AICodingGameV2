using AICodingGame.Core.Services;
using AICodingGame.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace AICodingGame.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BattleController: ControllerBase
{
    private BattleService _service;

    public BattleController(BattleService service)
    {
        _service = service;
    }

    [HttpGet("getBattles")]
    public IEnumerable<Battle>? GetBattles() => _service.Get();

    [HttpGet("getBattleMembers")]
    public IEnumerable<BattleMember>? GetBattleMembers(int battleId)
    {
        var res = _service.GetMembers(battleId);
        return res;
    }
}