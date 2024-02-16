using Business.Abstracts.Sync;
using Business.Responses;
using DataAccess.Abstracts.Sync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes.Sync;

internal class CarManager : ICarService
{
    private readonly ICarRepository _carRepository;

    public CarManager(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public GetByIdCarResponse GetById(int id)
    {
        var item = _carRepository.Get(p => p.Id == id);
        GetByIdCarResponse response = new GetByIdCarResponse();
        if (item != null)
        {
            response.Id = item.Id;
            response.ModelYear = item.ModelYear;
            response.DailyPrice = item.DailyPrice;
            response.State = item.State;
            response.Plate = item.Plate;
            response.CreatedDate = item.CreatedDate;
            response.UpdatedDate = item.UpdatedDate;
            return response;
        }
        return response;
    }
}
