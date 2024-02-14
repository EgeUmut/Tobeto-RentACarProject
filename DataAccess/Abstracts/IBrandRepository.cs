using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts;

public interface IBrandRepository
{
    public List<Brand> GetAll();
    public void Add(Brand brand);
}
