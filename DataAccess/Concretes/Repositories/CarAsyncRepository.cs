using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Context;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.Repositories;

public class CarAsyncRepository : EfAsyncRepositoryBase<Car, int, BaseDbContext>, ICarAsyncRepository
{
    public CarAsyncRepository(BaseDbContext context) : base(context)
    {
    }
}
