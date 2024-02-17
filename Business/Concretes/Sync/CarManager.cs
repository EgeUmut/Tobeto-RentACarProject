using Business.Abstracts.Sync;
using Business.Requests;
using Business.Responses;
using DataAccess.Abstracts.Sync;
using Entities.Concretes;
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

    public CreateCarResponse Add(CreateCarRequest request)
    {
        Car car = new Car();
        car.ModelYear = request.ModelYear;
        car.DailyPrice = request.DailyPrice;
        car.State = request.State;
        car.Plate = request.Plate;
        _carRepository.Add(car);

        CreateCarResponse response = new CreateCarResponse();
        response.ModelYear = car.ModelYear;
        response.DailyPrice = car.DailyPrice;
        response.State = car.State;
        response.Plate = car.Plate;
        response.CreatedDate = car.CreatedDate;
        return response;
    }

    public List<GetAllCarResponse> GetAll()
    {
        var list = _carRepository.GetAll();
        
        List<GetAllCarResponse> responseList = new List<GetAllCarResponse>();

        foreach (var item in list)
        {
            GetAllCarResponse response = new GetAllCarResponse();
            response.Id = item.Id;
            response.ModelYear = item.ModelYear;
            response.DailyPrice = item.DailyPrice;
            response.State = item.State;
            response.Plate = item.Plate;
            response.CreatedDate = item.CreatedDate;
            response.UpdatedDate = item.UpdatedDate;
            responseList.Add(response);
        }

        return responseList;
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
