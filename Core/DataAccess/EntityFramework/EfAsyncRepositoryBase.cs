using Core.Entities;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework;

public class EfAsyncRepositoryBase<TEntity, TEntityId, TContext> : IAsyncRepositoryBase<TEntity, TEntityId>
    where TEntity : BaseEntity<TEntityId>
    where TContext : DbContext
{
    protected readonly TContext _context;

    public EfAsyncRepositoryBase(TContext context)
    {
        _context = context;
    }

    public IQueryable<TEntity> Query() => _context.Set<TEntity>();

    public async Task<TEntity> Add(TEntity entity)
    {
        try
        {
            entity.CreatedDate = DateTime.UtcNow;
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception e)
        {

            throw e;
        }

    }

    public async Task<TEntity> Delete(TEntity entity)
    {
        entity.DeletedDate = DateTime.UtcNow;
        _context.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        IQueryable<TEntity> queryable = Query();
        if (include != null)
            queryable = include(queryable);
        return await queryable.FirstOrDefaultAsync(predicate);
    }

    public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        IQueryable<TEntity> queryable = Query();
        if (include != null)
            queryable = include(queryable);
        if (predicate != null)
            queryable = queryable.Where(predicate);
        return await queryable.ToListAsync();
    }

    public async Task<TEntity> Update(TEntity entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}
