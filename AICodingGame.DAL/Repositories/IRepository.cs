namespace AICodingGame.DAL.Repositories;

public interface IRepository<TEntity>
{
    public void Add(TEntity entity);
    public TEntity? GetById(int id);
    public IEnumerable<TEntity>? Get();
    public IEnumerable<TEntity>? Get(Func<TEntity, bool> predicate);
    public void Remove(TEntity entity);
    public void Update(TEntity entity);
}