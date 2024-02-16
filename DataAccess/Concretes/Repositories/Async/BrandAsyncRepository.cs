using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts.Async;
using DataAccess.Concretes.EntityFramework.Context;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.Repositories.Async;

public class BrandAsyncRepository : EfAsyncRepositoryBase<Brand, int, BaseDbContext>, IBrandAsyncRepository
{
    public BrandAsyncRepository(BaseDbContext context) : base(context)
    {
    }
}
