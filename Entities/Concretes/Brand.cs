using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class Brand:BaseEntity<int>
{
    public Brand()
    {
        Models = new HashSet<Model>();
    }

    public Brand(int ıd, string name)
    {
        Id = ıd;
        Name = name;
    }


    public string Name { get; set; }
    public ICollection<Model>? Models { get; set; }
}
