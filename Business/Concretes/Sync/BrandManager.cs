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

public class BrandManager : IBrandService
{
    private readonly IBrandRepository _brandRepository;

    public BrandManager(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public CreateBrandResponse Add(CreateBrandRequest request)
    {
        Brand brand = new Brand();
        brand.Name = request.Name;
        _brandRepository.Add(brand);

        CreateBrandResponse response = new CreateBrandResponse();
        response.Name = brand.Name;
        response.CreatedDate = brand.CreatedDate;
        return response;
    }

    public List<GetAllBrandResponse> GetAll()
    {
        var list = _brandRepository.GetAll();

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

    public GetByIdBrandResponse GetById(int id)
    {
        var item = _brandRepository.Get(p => p.Id == id);
        GetByIdBrandResponse response = new GetByIdBrandResponse();
        if (item != null)
        {
            response.Id = item.Id;
            response.Name = item.Name;
            response.CreatedDate = item.CreatedDate;
            response.UpdatedDate = item.UpdatedDate;
            return response;
        }

        return response;
    }
}
