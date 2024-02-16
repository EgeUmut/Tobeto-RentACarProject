using Business.Abstracts.Async;
using Business.Abstracts.Sync;
using Business.Requests;
using Business.Responses;
using DataAccess.Abstracts.Async;
using DataAccess.Abstracts.Sync;
using DataAccess.Concretes.Repositories.Async;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes.Async;

public class AsyncCarManager : IAsyncCarService
{
    private readonly ICarAsyncRepository _carAsyncRepository;

    public AsyncCarManager(ICarAsyncRepository carAsyncRepository)
    {
        _carAsyncRepository = carAsyncRepository;
    }

    public async Task<CreateCarResponse> AddAsync(CreateCarRequest request)
    {
        Car car = new Car();
        car.ModelYear = request.ModelYear;
        car.DailyPrice = request.DailyPrice;
        car.State = request.State;
        car.Plate = request.Plate;
        await _carAsyncRepository.Add(car);

        CreateCarResponse response = new CreateCarResponse();
        response.ModelYear = car.ModelYear;
        response.DailyPrice = car.DailyPrice;
        response.State = car.State;
        response.Plate = car.Plate;
        response.CreatedDate = car.CreatedDate;
        return response;
    }

    public async Task<List<Car>> GetAll()
    {
        return await _carAsyncRepository.GetAll();
    }
}
