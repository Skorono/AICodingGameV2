using AICodingGame.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace AICodingGame.DAL.Repositories;

public class StatisticRepository : Repository<Statistic>, IStatisticRepository
{
    public StatisticRepository(DbContext context) : base(context)
    {
    }
}