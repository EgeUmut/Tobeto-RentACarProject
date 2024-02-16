﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts.Sync;
using DataAccess.Concretes.EntityFramework.Context;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.Repositories.Sync;

public class CarRepository : EfRepositoryBase<Car, int, BaseDbContext>, ICarRepository
{
    public CarRepository(BaseDbContext context) : base(context)
    {
    }
}
