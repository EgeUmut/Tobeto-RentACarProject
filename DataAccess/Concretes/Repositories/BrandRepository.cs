using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Context;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.Repositories;

public class BrandRepository : IBrandRepository
{
    private readonly BaseDbContext _context;

    public BrandRepository(BaseDbContext context)
    {
        _context = context;
    }

    public void Add(Brand brand)
    {
        _context.Add(brand);
        _context.SaveChanges();
    }

    public List<Brand> GetAll()
    {
        var list = _context.Brands.ToList();
        return list;
    }
}
