﻿namespace AICodingGame.DAL.Models;

public class Battle
{
    public Battle()
    {
        Members = new HashSet<BattleMember>();
    }

    public int Id { get; set; }
    public DateTime StartDateTime { get; set; }

    public DateTime? EndDateTime { get; set; }
    //public int? WinnerId { get; set; }

    //[ForeignKey("WinnerId")]
    //public BattleMember BattleMember { get; set; } = new();
    public virtual ICollection<BattleMember> Members { get; set; }
    public virtual BattleStatus Status { get; set; }
}