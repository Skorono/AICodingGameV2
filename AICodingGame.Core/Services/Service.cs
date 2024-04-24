using AICodingGame.DAL.Repositories;

namespace AICodingGame.Core.Services;

public abstract class Service<TRepository, TEntity> where TRepository : IRepository<TEntity>
{
    protected TRepository Repository;

    public Service(TRepository repository)
    {
        Repository = repository;
    }

    public virtual TEntity? GetById(int id)
    {
        return Repository.GetById(id);
    }

    public virtual IEnumerable<TEntity>? Get()
    {
        return Repository.Get();
    }

    public virtual IEnumerable<TEntity>? Get(Func<TEntity, bool> predicate)
    {
        return Repository.Get(predicate);
    }

    public virtual async void Add(TEntity entity)
    {
        try
        {
            Repository.Add(entity);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public virtual void Update(TEntity entity)
    {
        Repository.Update(entity);
    }

    public virtual void Remove(TEntity entity)
    {
        Repository.Remove(entity);
    }
}