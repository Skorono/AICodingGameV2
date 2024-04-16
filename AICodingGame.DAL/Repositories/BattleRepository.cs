using AICodingGame.DAL.Context;
using AICodingGame.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace AICodingGame.DAL.Repositories;

public class BattleRepository: Repository<Battle>, IBattleRepository
{
    public BattleRepository(GameContext context) : base(context)
    {
    }

    public IEnumerable<BattleMember>? GetMembers(int battleId) =>
        Get()?.FirstOrDefault(b => b.Id == battleId)?.Members;

    public IEnumerable<MemberBattleStatistic>? GetMembersStatistic(int battleId) =>
        new MemberBattleStatistic[2]; /*GetById(battleId)?.Members.Select(m => m.Statistic).ToList();*/
    
    public override IEnumerable<Battle>? Get()
    {
        return _dbSet
            .Include(b => b.Members)
                .ThenInclude(m => m.Statistic)
            .Include(b => b.Members)
                .ThenInclude(m => m.Robot)
            .AsNoTracking()
            .ToList();
    }
}