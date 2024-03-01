using AutoMapper;
using Azure;
using Business.Abstracts;
using Business.Constants;
using Business.Requests;
using Business.Responses.Brand;
using Business.Rules;
using Core.Exceptios.Types;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
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
    private readonly BrandBusinessRules _brandBusinessRules;

    public BrandManager(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
        _brandBusinessRules = brandBusinessRules;
    }

    //Sync
    public CreateBrandResponse Add(CreateBrandRequest request)
    {
        Brand brand = _mapper.Map<Brand>(request);
        _brandRepository.Add(brand);

        CreateBrandResponse response = _mapper.Map<CreateBrandResponse>(brand);
        return response;
    }

    //Sync
    public List<GetAllBrandResponse> GetAll()
    {
        var list = _brandRepository.GetAll(p => p.DeleteStatus != true);
        List<GetAllBrandResponse> responseList = _mapper.Map<List<GetAllBrandResponse>>(list);

        return responseList;
    }

    //Sync
    public GetByIdBrandResponse GetById(int id)
    {
        var item = _brandRepository.Get(p => p.Id == id && p.DeleteStatus != true);
        if (item != null)
        {
            GetByIdBrandResponse response = _mapper.Map<GetByIdBrandResponse>(item);
            return response;
        }
        return null;
    }

    public async Task<IDataResult<CreateBrandResponse>> AddAsync(CreateBrandRequest request)
    {
        await _brandBusinessRules.CheckIfBrandNameNotExist(request.Name);

        Brand brand = _mapper.Map<Brand>(request);
        await _brandRepository.AddAsync(brand);
        CreateBrandResponse response = _mapper.Map<CreateBrandResponse>(brand);

        return new SuccessDataResult<CreateBrandResponse>(response, BrandMessages.BrandAdded);
    }

    public async Task<IDataResult<List<GetAllBrandResponse>>> GetAllAsync()
    {
        var list = await _brandRepository.GetAllAsync(p => p.DeleteStatus != true);
        List<GetAllBrandResponse> responseList = _mapper.Map<List<GetAllBrandResponse>>(list);

        return new SuccessDataResult<List<GetAllBrandResponse>>(responseList, "listed Succesfully");
    }

    public async Task<IResult> DeleteAsync(int request)
    {
        await _brandBusinessRules.CheckIfIdNotExist(request);
        var item = await _brandRepository.GetAsync(p => p.Id == request);

        await _brandRepository.DeleteAsync(item);
        return new SuccessResult("Successfully Deleted");
    }

    public async Task<IResult> SoftDeleteAsync(int request)
    {
        await _brandBusinessRules.CheckIfIdNotExist(request);
        var item = await _brandRepository.GetAsync(p => p.Id == request);

        await _brandRepository.SoftDeleteAsync(item);
        return new SuccessResult("Successfully Soft Deleted");
    }

    public async Task<GetByIdBrandResponse> GetByIdAsync(int request)
    {
        await _brandBusinessRules.CheckIfIdNotExist(request);
        var item = await _brandRepository.GetAsync(p => p.Id == request);
        GetByIdBrandResponse response = _mapper.Map<GetByIdBrandResponse>(item);
        return response;
    }
}
