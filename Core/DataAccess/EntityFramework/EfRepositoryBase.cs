using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework;

public class EfRepositoryBase<TEntity, TEntityId, TContext> : IRepositoryBase<TEntity, TEntityId>,IAsyncRepositoryBase<TEntity,TEntityId>
    where TEntity : BaseEntity<TEntityId>
    where TContext : DbContext
{
    private readonly TContext _context;

    public EfRepositoryBase(TContext context)
    {
        _context = context;
    }

    public IQueryable<TEntity> Query() => _context.Set<TEntity>();

    public TEntity Add(TEntity entity)
    {
        entity.CreatedDate = DateTime.UtcNow;
        _context.Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public TEntity Delete(TEntity entity)
    {
        entity.DeletedDate = DateTime.UtcNow;
        _context.Remove(entity);
        _context.SaveChanges();
        return entity;
    }

    public TEntity SoftDelete(TEntity entity)
    {
        entity.DeletedDate = DateTime.UtcNow;
        entity.DeleteStatus = true;
        _context.Update(entity);
        _context.SaveChanges();
        return entity;
    }

    public TEntity Get(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        //IQueryable<TEntity> queryable = Query().Where(e => e.DeleteStatus != true); // Soft silinmiş verileri hariç tut
        IQueryable<TEntity> queryable = Query();
        if (include != null)
            queryable = include(queryable);
        return queryable.FirstOrDefault(predicate);
    }

    public List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        //IQueryable<TEntity> queryable = Query().Where(e => e.DeleteStatus != true); // Soft silinmiş verileri hariç tut
        IQueryable<TEntity> queryable = Query();
        if (include != null)
            queryable = include(queryable);
        if (predicate != null)
            queryable = queryable.Where(predicate);
        return  queryable.ToList();
    }

    public TEntity Update(TEntity entity)
    {
        _context.Update(entity);
        _context.SaveChanges();
        return entity;
    }

    // ASYNC START


    public async Task<TEntity> AddAsync(TEntity entity)
    {
            entity.CreatedDate = DateTime.UtcNow;
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        entity.DeletedDate = DateTime.UtcNow;
        _context.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> SoftDeleteAsync(TEntity entity)
    {
        entity.DeletedDate = DateTime.UtcNow;
        entity.DeleteStatus = true;
        _context.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        IQueryable<TEntity> queryable = Query();
        if (include != null)
            queryable = include(queryable);
        return await queryable.FirstOrDefaultAsync(predicate);
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        IQueryable<TEntity> queryable = Query();
        if (include != null)
            queryable = include(queryable);
        if (predicate != null)
            queryable = queryable.Where(predicate);
        return await queryable.ToListAsync();
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}
