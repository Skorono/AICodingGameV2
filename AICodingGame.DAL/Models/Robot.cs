﻿namespace AICodingGame.DAL.Models;

public class Robot
{
    public Robot()
    {
        BattleMembers = new HashSet<BattleMember>();
    }
    
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string ProjectPath { get; set; } = null!;
    
    public virtual Statistic Statistic { get; set; }
    public virtual ICollection<BattleMember> BattleMembers { get; set; }
}