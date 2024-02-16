using Business.Abstracts.Async;
using Business.Abstracts.Sync;
using Business.Requests;
using Business.Responses;
using DataAccess.Abstracts.Async;
using DataAccess.Abstracts.Sync;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes.Async;

public class AsyncBrandManager : IAsyncBrandService
{
    private readonly IBrandAsyncRepository _brandAsyncRepository;

    public AsyncBrandManager(IBrandAsyncRepository brandAsyncRepository)
    {
        _brandAsyncRepository = brandAsyncRepository;
    }

    public async Task<CreateBrandResponse> AddAsync(CreateBrandRequest request)
    {
        Brand brand = new Brand();
        brand.Name = request.Name;
        await _brandAsyncRepository.Add(brand);

        CreateBrandResponse response = new CreateBrandResponse();
        response.Name = brand.Name;
        response.CreatedDate = brand.CreatedDate;
        return response;
    }

    public async Task<List<Brand>> GetAll()
    {
        return await _brandAsyncRepository.GetAll();
    }


}
