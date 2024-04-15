using AICodingGame.Core.Services;
using AICodingGame.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace AICodingGame.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RobotController: ControllerBase
{
    private RobotService _service;
    
    public RobotController(RobotService service)
    {
        _service = service;
    }
    
    [HttpGet("getRobotById")]
    public Robot? GetRobotById(int robotId) => _service.GetById(robotId);

    [HttpGet("getRobots")]
    public IEnumerable<Robot>? Get() => _service.Get();

    [HttpGet("getBattlesStatistic")]
    public IEnumerable<MemberBattleStatistic> GetBattlesStatistic(int robotId) =>
        _service.GetById(robotId)?.BattleMembers.Select(m => m.Statistic)!;

    [HttpGet("getRobotStatistic")]
    public Statistic? GetRobotStatistic(int robotId) => GetRobotById(robotId)?.Statistic;
}