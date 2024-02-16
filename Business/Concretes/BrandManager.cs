using Business.Abstracts;
using Business.Requests;
using Business.Responses;
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
    private readonly IBrandAsyncRepository _brandRepository;

    public BrandManager(IBrandAsyncRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task<CreateBrandResponse> AddAsync(CreateBrandRequest request)
    {
        Brand brand = new Brand();
        brand.Name = request.Name;
        await _brandRepository.Add(brand);

        CreateBrandResponse response = new CreateBrandResponse();
        response.Name = brand.Name;
        response.CreatedDate = brand.CreatedDate;
        return response;
    }

    public async Task<List<Brand>> GetAll()
    {
        return await _brandRepository.GetAll();
    }
}
