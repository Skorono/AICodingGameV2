using AICodingGame.DAL.Context;
using AICodingGame.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace AICodingGame.DAL.Repositories;

public class RobotRepository: Repository<Robot>, IRobotRepository
{
    public RobotRepository(GameContext context) : base(context)
    {
    }

    public Statistic GetStatistic(int id) => new Statistic(); /*GetById(id)?.Statistic!;*/

    public override IEnumerable<Robot>? Get()
    {
        return _dbSet
            .Include(r => r.Statistic)
            .Include(r => r.BattleMembers)
                .ThenInclude(m => m.Statistic)
            .AsNoTracking()
            .ToList();
    }
}