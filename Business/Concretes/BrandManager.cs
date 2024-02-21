using AutoMapper;
using Business.Abstracts;
using Business.Requests;
using Business.Responses.Brand;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class BrandManager : IBrandService
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public BrandManager(IBrandRepository brandRepository,IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public CreateBrandResponse Add(CreateBrandRequest request)
    {
        Brand brand = _mapper.Map<Brand>(request);
        _brandRepository.Add(brand);

        CreateBrandResponse response = _mapper.Map<CreateBrandResponse>(brand);
        return response;
    }

    public List<GetAllBrandResponse> GetAll()
    {
        var list = _brandRepository.GetAll();

        List<GetAllBrandResponse> responseList = _mapper.Map<List<GetAllBrandResponse>>(list);

        return responseList;
    }

    public GetByIdBrandResponse GetById(int id)
    {
        /*   var item = _brandRepository.Get(p => p.Id == id);
           GetByIdBrandResponse response = new GetByIdBrandResponse();
           if (item != null)
           {
               response.Id = item.Id;
               response.Name = item.Name;
               response.CreatedDate = item.CreatedDate;
               response.UpdatedDate = item.UpdatedDate;
               return response;
           }

           return response;*/

        var item = _brandRepository.Get(p => p.Id == id);
        if (item != null)
        {
            GetByIdBrandResponse response = _mapper.Map<GetByIdBrandResponse>(item);
            return response;
        }
        return null;
    }

    public async Task<CreateBrandResponse> AddAsync(CreateBrandRequest request)
    {
        Brand brand = new Brand();
        brand.Name = request.Name;
        await _brandRepository.AddAsync(brand);

        CreateBrandResponse response = new CreateBrandResponse();
        response.Name = brand.Name;
        response.CreatedDate = brand.CreatedDate;
        return response;
    }

    public async Task<List<GetAllBrandResponse>> GetAllAsync()
    {
        var list = await _brandRepository.GetAllAsync();

        List<GetAllBrandResponse> responseList = new List<GetAllBrandResponse>();

        foreach (var item in list)
        {
            GetAllBrandResponse response = new GetAllBrandResponse();
            response.Id = item.Id;
            response.Name = item.Name;
            response.CreatedDate = item.CreatedDate;
            response.UpdatedDate = item.UpdatedDate;
            responseList.Add(response);
        }

        return responseList;
    }
}
