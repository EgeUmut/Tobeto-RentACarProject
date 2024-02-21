using AutoMapper;
using Business.Abstracts;
using Business.Requests;
using Business.Responses.Car;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

internal class CarManager : ICarService
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public CarManager(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
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

    public async Task<CreateCarResponse> AddAsync(CreateCarRequest request)
    {
        Car car = _mapper.Map<Car>(request);
        await _carRepository.AddAsync(car);

        CreateCarResponse response = _mapper.Map<CreateCarResponse>(car);
        return response;
    }

    public async Task<IDataResult<List<GetAllCarResponse>>> GetAllAsync()
    {
        var list = await _carRepository.GetAllAsync(include:x=>x.Include(p=>p.Model).Include(p=>p.Model.Brand));
        List<GetAllCarResponse> responseList = _mapper.Map<List<GetAllCarResponse>>(list);
        return new SuccessDataResult<List<GetAllCarResponse>>(responseList,"Listed Succesfuly.");
    }
}
