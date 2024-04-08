﻿using AICodingGame.DAL.Models;
using AICodingGame.DAL.Repositories;

namespace AICodingGame.Core.Services;

public class RobotService: Service<IRobotRepository, Robot>
{
    public RobotService(IRobotRepository repository) : base(repository)
    {
    }

    public override void Add(Robot entity)
    {
        base.Add(entity);
    }
}