using Business.Abstracts.Sync;
using Business.Responses;
using DataAccess.Abstracts.Sync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes.Sync;

public class ModelManager : IModelService
{
    private readonly IModelRepository _modelRepository;

    public ModelManager(IModelRepository modelRepository)
    {
        _modelRepository = modelRepository;
    }

    public GetByIdModelResponse GetById(int id)
    {
        var item = _modelRepository.Get(p => p.Id == id);
        GetByIdModelResponse response = new GetByIdModelResponse();
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
