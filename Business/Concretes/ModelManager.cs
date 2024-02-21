using AutoMapper;
using Business.Abstracts;
using Business.Requests;
using Business.Responses.Brand;
using Business.Responses.Model;
using DataAccess.Abstracts;
using DataAccess.Concretes.Repositories;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class ModelManager : IModelService
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;

    public ModelManager(IModelRepository modelRepository, IMapper mapper)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
    }

    public CreateModelResponse Add(CreateModelRequest request)
    {
        Model model = _mapper.Map<Model>(request);
        _modelRepository.Add(model);
        CreateModelResponse response = _mapper.Map<CreateModelResponse>(model);
        return response;
    }

    public List<GetAllModelResponse> GetAll()
    {
        var list = _modelRepository.GetAll();
        List<GetAllModelResponse> responseList = _mapper.Map<List<GetAllModelResponse>>(list);
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
            //response.BrandName = item.Brand.Name;
            response.CreatedDate = item.CreatedDate;
            response.UpdatedDate = item.UpdatedDate;
            return response;
        }
        return response;
    }

    public async Task<CreateModelResponse> AddAsync(CreateModelRequest request)
    {
        Model model = _mapper.Map<Model>(request);
        await _modelRepository.AddAsync(model);
        CreateModelResponse response = _mapper.Map<CreateModelResponse>(model);
        return response;
    }

    public async Task<List<GetAllModelResponse>> GetAllAsync()
    {
        var list = _modelRepository.GetAll();
        List<GetAllModelResponse> responseList = _mapper.Map<List<GetAllModelResponse>>(list);
        return responseList;
    }
}
