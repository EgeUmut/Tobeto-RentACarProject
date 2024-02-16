using Business.Abstracts.Sync;
using Business.Responses;
using DataAccess.Abstracts.Sync;
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
