using AutoMapper;
using Business.Requests;
using Business.Responses.Car;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.Cars;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Car, CreateCarRequest>().ReverseMap();
        CreateMap<Car, CreateCarResponse>().ReverseMap();
        CreateMap<Car, GetAllCarResponse>().ReverseMap();
    }
}
