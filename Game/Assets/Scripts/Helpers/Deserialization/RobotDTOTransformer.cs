using System.Collections.Generic;
using System.Linq;
using AICodingGame.Infrastructure.Services.Models;
using Newtonsoft.Json.Linq;

namespace AICodingGame.Helpers.Deserialization
{
    public static class RobotDTOTransformer
    {
        public static List<RobotDto> JsonToRobotDTO(this string robotJson)
        {
            JArray node = JArray.Parse(robotJson);
            return node.Select(token => token.ToObject<RobotDto>()).ToList();
        }

        public static string RobotDTOToRobot(this RobotDto robot)
        {
            return null;
        }
    }
}