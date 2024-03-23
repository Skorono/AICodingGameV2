using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AICodingGame.DAL.Models;

[PrimaryKey("BattleId", "MemberId")]
public class MemberBattleStatistic
{
    public int BattleId { get; set; }
    public int MemberId { get; set; }
    
    public float AccuracyPercent { get; set; }
    public int Kills { get; set; }
    public TimeOnly LifeTime { get; set; }

    [ForeignKey("BattleId")]
    public virtual Battle Battle { get; set; } = new();

    [ForeignKey("MemberId")] 
    public virtual BattleMember Member { get; set; } = new();
}