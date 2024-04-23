using System;
using System.Collections.Generic;

namespace AICodingGame.Infrastructure.Services.Models
{   
    [Serializable]
    public class BattleDTO
    {
        public int Id { get; set; }
        public DateTime StartedDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public IEnumerable<RobotDto> Members { get; set; } = null;
    }
}