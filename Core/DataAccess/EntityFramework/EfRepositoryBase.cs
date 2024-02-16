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

public class EfRepositoryBase<TEntity, TEntityId, TContext> : IRepositoryBase<TEntity, TEntityId>
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

    public TEntity Get(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        IQueryable<TEntity> queryable = Query();
        if (include != null)
            queryable = include(queryable);
        return queryable.FirstOrDefault(predicate);
    }

    public List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
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
}
