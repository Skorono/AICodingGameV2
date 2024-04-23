using AICodingGame.DAL.Models;
using AICodingGame.Infrastructure.Services.Models;

namespace AICodingGame.Core.Helpers;

public static class RobotConvertationHelper
{
    public static Robot RobotDtoToModel(this RobotDto robotDto)
    {
        return new Robot()
        {
            Name = robotDto.Name,
            Image = robotDto.Image.StringToByteArray(),
            LastUpdated = DateOnly.FromDateTime(robotDto.LastUpdated),
            BattleMembers = new List<BattleMember>(),
            Statistic = new()
        };
    }
}