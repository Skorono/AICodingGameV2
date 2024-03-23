using Microsoft.EntityFrameworkCore;

namespace AICodingGame.DAL.Repositories;

public abstract class Repository<TEntity>: IRepository<TEntity> where TEntity: class
{
    protected DbContext _context;
    protected DbSet<TEntity> _dbSet;

    public Repository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public virtual void Add(TEntity entity)
    {
        _dbSet.Add(entity!);
        _context.SaveChanges();
    }

    public virtual TEntity? GetById(int id) => _dbSet.Find(id);

    public virtual IEnumerable<TEntity>? Get() => _dbSet.AsNoTracking().ToList();

    public virtual IEnumerable<TEntity>? Get(Func<TEntity, bool> predicate) => Get()?.Where(predicate).ToList();

    public virtual void Remove(TEntity entity)
    {
        _dbSet.Remove(entity);
        _context.SaveChanges();
    }

    public virtual void Update(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
    }
}