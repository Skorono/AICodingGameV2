using System.Runtime.Serialization;
using AICodingGame.Core.Helpers;
using AICodingGame.Core.Services;
using AICodingGame.DAL.Models;
using AICodingGame.Infrastructure.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace AICodingGame.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RobotController : ControllerBase
{
    private readonly RobotService _service;
    private readonly ILogger<RobotController> _logger;

    public RobotController(RobotService service, ILogger<RobotController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet("getById")]
    public async Task<Robot?> GetRobotById(int robotId)
    {
        return await Task.Run(() => _service.GetById(robotId));
    }

    [HttpGet("get")]
    public async Task<IEnumerable<Robot>?> Get()
    {
        return await Task.Run(() => _service.Get());
    }

    [HttpGet("getBattleStatistic")]
    public async Task<IEnumerable<MemberBattleStatistic>> GetBattlesStatistic(int robotId)
    {
        return await Task.Run(() => _service.GetById(robotId)?.BattleMembers.Select(m => m.Statistic)!);
    }

    [HttpGet("getStatistic")]
    public async Task<Statistic?> GetRobotStatistic(int robotId)
    {
        var robot = await GetRobotById(robotId);
        return robot?.Statistic;
    }

    [HttpPost("add")]
    public async void Add(RobotDto robotDto)
    {
        Robot robot = robotDto.RobotDtoToModel();
        _logger.LogInformation($"adding robot {JsonSerializer.Serialize(robotDto)}");
        await Task.Run(() => _service.Add(robot));
    }

    [HttpPost("update")]
    public async void Update(RobotDto robot)
    {
        _logger.LogInformation($"updating robot {robot.ToString()}");
        await Task.Run(() => _service.Update(robot.RobotDtoToModel()));
    }

    [HttpDelete("delete")]
    public async void Delete(RobotDto robot)
    {
        _logger.LogInformation($"deleting robot {robot.ToString()}");
        await Task.Run(() => _service.Remove(robot.RobotDtoToModel()));
    }
}