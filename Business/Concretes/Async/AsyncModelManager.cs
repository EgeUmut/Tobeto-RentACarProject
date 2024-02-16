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

public class AsyncModelManager : IAsyncModelService
{
    private readonly IModelAsyncRepository _modelAsyncRepository;

    public AsyncModelManager(IModelAsyncRepository modelAsyncRepository)
    {
        _modelAsyncRepository = modelAsyncRepository;
    }

    public async Task<CreateModelResponse> AddAsync(CreateModelRequest request)
    {
        Model model = new Model();
        model.Name = request.Name;
        await _modelAsyncRepository.Add(model);

        CreateModelResponse response = new CreateModelResponse();
        response.Name = model.Name;
        response.CreatedDate = model.CreatedDate;
        return response;
    }

    public async Task<List<Model>> GetAll()
    {
        return await _modelAsyncRepository.GetAll();
    }
}
