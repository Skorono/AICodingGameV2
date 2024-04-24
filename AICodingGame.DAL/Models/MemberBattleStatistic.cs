using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AICodingGame.DAL.Models;

[PrimaryKey("MemberId")]
public class MemberBattleStatistic
{
    public int MemberId { get; set; }
    public float AccuracyPercent { get; set; }
    public int Kills { get; set; }
    public TimeOnly LifeTime { get; set; }
    
    [ForeignKey("MemberId")] public virtual BattleMember Member { get; set; } = new();
}