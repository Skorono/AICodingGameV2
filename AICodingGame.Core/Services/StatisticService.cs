using AICodingGame.DAL.Models;
using AICodingGame.DAL.Repositories;

namespace AICodingGame.Core.Services;

public class StatisticService : Service<StatisticRepository, Statistic>
{
    public StatisticService(StatisticRepository repository) : base(repository)
    {
    }
}