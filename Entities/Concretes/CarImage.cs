using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class CarImage:BaseEntity<int>
{
    public CarImage(int id, int carId, string ımagePath)
    {
        Id = id;
        CarId = carId;
        ImagePath = ımagePath;
    }

    public CarImage()
    {
        
    }

    public int CarId { get; set; }
    public string ImagePath { get; set; }
    public Car Car { get; set; }

}
