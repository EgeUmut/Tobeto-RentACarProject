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

    public async Task<List<GetAllBrandResponse>> GetAll()
    {
        var list = await _brandAsyncRepository.GetAll();
        
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
