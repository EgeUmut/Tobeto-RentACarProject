using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Requests;
using Business.Responses.Brand;
using Business.Responses.Model;
using Entities.Concretes;

namespace Business.Profiles.Brands;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Brand, CreateBrandRequest>().ReverseMap();
        CreateMap<Brand, CreateBrandResponse>().ReverseMap();
        CreateMap<Brand, GetAllBrandResponse>().ReverseMap();
        CreateMap<Brand,GetByIdBrandResponse>().ReverseMap();

    }
}
