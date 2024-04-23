using AICodingGame.DAL.Models;

namespace AICodingGame.DAL.Repositories;

public interface IBattleRepository : IRepository<Battle>
{
    public IEnumerable<BattleMember>? GetMembers(int battleId);

    public IEnumerable<MemberBattleStatistic>? GetMembersStatistic(int battleId);
}