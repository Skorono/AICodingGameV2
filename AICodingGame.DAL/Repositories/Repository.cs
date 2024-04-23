using Microsoft.EntityFrameworkCore;

namespace AICodingGame.DAL.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected DbContext _context;
    protected DbSet<TEntity> _dbSet;

    public Repository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public async void Add(TEntity entity)
    {
        _dbSet.Add(entity!);
        await _context.SaveChangesAsync();
    }

    public virtual TEntity? GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public virtual IEnumerable<TEntity>? Get()
    {
        return _dbSet.AsNoTracking().ToList();
    }

    public virtual IEnumerable<TEntity>? Get(Func<TEntity, bool> predicate)
    {
        return Get()?.Where(predicate).ToList();
    }

    public virtual void Remove(TEntity entity)
    {
        _dbSet.Remove(entity);
        _context.SaveChanges();
    }

    public virtual async void Update(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}