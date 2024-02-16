using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class Model:BaseEntity<int>
{
    public Model()
    {
        Cars = new HashSet<Car>();
    }

    public Model(int ıd, int brandId, string name)
    {
        Id = ıd;
        BrandId = brandId;
        Name = name;
    }

    public int? BrandId { get; set; }
    public string Name { get; set; }
    public Brand? Brand { get; set; }
    public virtual ICollection<Car>? Cars { get; set; }
}
