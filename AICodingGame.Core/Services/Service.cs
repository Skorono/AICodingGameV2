using AICodingGame.DAL.Repositories;

namespace AICodingGame.Core.Services;

public abstract class Service<TRepository, TEntity> where TRepository : IRepository<TEntity>
{
    protected TRepository Repository;
    
    public Service(TRepository repository)
    {
        Repository = repository;
    }
    
    public virtual TEntity? GetById(int id) => Repository.GetById(id);
    
    public virtual IEnumerable<TEntity>? Get() => Repository.Get();

    public virtual IEnumerable<TEntity>? Get(Func<TEntity, bool> predicate) => Repository.Get(predicate);
    
    public virtual void Add(TEntity entity) => Repository.Add(entity);

    public virtual void Update(TEntity entity) => Repository.Update(entity);
}