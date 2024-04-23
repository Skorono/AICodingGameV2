using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AICodingGame.DAL.Models;

[PrimaryKey("Id")]
public class BattleMember
{
    public int Id { get; set; }
    public int BattleId { get; set; }
    public int RobotId { get; set; }

    [ForeignKey("RobotId")] public virtual Robot Robot { get; set; } = new();

    [ForeignKey("BattleId")] public virtual Battle Battle { get; set; } = new();

    public virtual MemberBattleStatistic Statistic { get; set; }
}