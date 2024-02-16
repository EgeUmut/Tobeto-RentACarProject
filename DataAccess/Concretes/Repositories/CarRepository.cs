using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.Repositories;

public class CarRepository : ICarRepository
{
    public Task<Car> Add(Car entity)
    {
        throw new NotImplementedException();
    }

    public Task<Car> Delete(Car entity)
    {
        throw new NotImplementedException();
    }

    public Task<Car> Get(Expression<Func<Car, bool>> predicate = null, Func<IQueryable<Car>, IIncludableQueryable<Car, object>>? incule = null)
    {
        throw new NotImplementedException();
    }

    public Task<List<Car>> GetAll(Expression<Func<Car, bool>> predicate = null, Func<IQueryable<Car>, IIncludableQueryable<Car, object>>? incule = null)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Car> Query()
    {
        throw new NotImplementedException();
    }

    public Task<Car> Update(Car entity)
    {
        throw new NotImplementedException();
    }
}
