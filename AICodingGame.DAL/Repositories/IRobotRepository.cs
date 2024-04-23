using AICodingGame.DAL.Models;

namespace AICodingGame.DAL.Repositories;

public interface IRobotRepository : IRepository<Robot>
{
    public Statistic GetStatistic(int id);
}