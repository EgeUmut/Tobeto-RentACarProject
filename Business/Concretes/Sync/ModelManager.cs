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

public class ModelManager : IModelService
{
    private readonly IModelRepository _modelRepository;

    public ModelManager(IModelRepository modelRepository)
    {
        _modelRepository = modelRepository;
    }

    public CreateModelResponse Add(CreateModelRequest request)
    {
        Model model = new Model();
        model.Name = request.Name;
        _modelRepository.Add(model);

        CreateModelResponse response = new CreateModelResponse();
        response.Name = model.Name;
        response.CreatedDate = model.CreatedDate;
        return response;
    }

    public List<GetAllModelResponse> GetAll()
    {
        var list = _modelRepository.GetAll();

        List<GetAllModelResponse> responseList = new List<GetAllModelResponse>();

        foreach (var item in list)
        {
            GetAllModelResponse response = new GetAllModelResponse();
            response.Id = item.Id;
            response.Name = item.Name;
            response.CreatedDate = item.CreatedDate;
            response.UpdatedDate = item.UpdatedDate;
            responseList.Add(response);
        }

        return responseList;
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
