using System.Net.Sockets;
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
    
    [HttpGet("getById")]
    public async Task<Robot?> GetRobotById(int robotId) => 
        await Task.Run(() => _service.GetById(robotId));

    [HttpGet("get")]
    public async Task<IEnumerable<Robot>?> Get() =>
        await Task.Run(() => _service.Get());

    [HttpGet("getBattleStatistic")]
    public async Task<IEnumerable<MemberBattleStatistic>> GetBattlesStatistic(int robotId) =>
        await Task.Run(() => _service.GetById(robotId)?.BattleMembers.Select(m => m.Statistic)!);

    [HttpGet("getStatistic")]
    public async Task<Statistic?> GetRobotStatistic(int robotId)
    {
        var robot = await GetRobotById(robotId);
        return robot?.Statistic;
    }

    [HttpPost("add")]
    public async void Add(Robot robot) =>
        await Task.Run(() => _service.Add(robot));

    [HttpPost("update")]
    public async void Update(Robot robot) =>
        await Task.Run(() => _service.Update(robot));

    [HttpDelete("delete")]
    public async void Delete(Robot robot) =>
        await Task.Run(() => _service.Remove(robot));
}