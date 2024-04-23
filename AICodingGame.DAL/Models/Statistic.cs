using Microsoft.EntityFrameworkCore;

namespace AICodingGame.DAL.Models;

[PrimaryKey("RobotId")]
public class Statistic
{
    public int RobotId { get; set; }
    public float WinnerPercent { get; set; }
    public float KillDeathPercent { get; set; }

    public virtual Robot Robot { get; set; } = new();
}