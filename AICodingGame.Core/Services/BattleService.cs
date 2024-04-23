using AICodingGame.DAL.Models;
using AICodingGame.DAL.Repositories;

namespace AICodingGame.Core.Services;

public class BattleService : Service<IBattleRepository, Battle>
{
    public BattleService(IBattleRepository repository) : base(repository)
    {
    }

    public IEnumerable<BattleMember>? GetMembers(int battleId)
    {
        return Repository.GetMembers(battleId);
    }
}