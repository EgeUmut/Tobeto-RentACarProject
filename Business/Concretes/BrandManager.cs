using AutoMapper;
using Azure;
using Business.Abstracts;
using Business.Requests;
using Business.Responses.Brand;
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

    public BrandManager(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public CreateBrandResponse Add(CreateBrandRequest request)
    {
        Brand brand = _mapper.Map<Brand>(request);
        _brandRepository.Add(brand);

        CreateBrandResponse response = _mapper.Map<CreateBrandResponse>(brand);
        return response;
    }

    public List<GetAllBrandResponse> GetAll()
    {
        var list = _brandRepository.GetAll(p => p.DeleteStatus != true);
        List<GetAllBrandResponse> responseList = _mapper.Map<List<GetAllBrandResponse>>(list);

        return responseList;
    }

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
        Brand brand = _mapper.Map<Brand>(request);
        await _brandRepository.AddAsync(brand);
        CreateBrandResponse response = _mapper.Map<CreateBrandResponse>(brand);

        return new SuccessDataResult<CreateBrandResponse>(response, "Added Succesfully");
    }

    public async Task<IDataResult<List<GetAllBrandResponse>>> GetAllAsync()
    {
        var list = await _brandRepository.GetAllAsync(p => p.DeleteStatus != true);
        List<GetAllBrandResponse> responseList = _mapper.Map<List<GetAllBrandResponse>>(list);

        return new SuccessDataResult<List<GetAllBrandResponse>>(responseList, "listed Succesfully");
    }

    public async Task<IResult> DeleteAsync(int request)
    {
        var item = await _brandRepository.GetAsync(p => p.Id == request);
        if (item != null)
        {
            await _brandRepository.DeleteAsync(item);
            return new SuccessResult("Successfully Deleted");
        }
        return new ErrorResult("Object could not be found");
    }

    public async Task<IResult> SoftDeleteAsync(int request)
    {
        var item = await _brandRepository.GetAsync(p => p.Id == request);
        if (item != null)
        {
            await _brandRepository.SoftDeleteAsync(item);
            return new SuccessResult("Successfully Soft Deleted");
        }
        return new ErrorResult("Object could not be found");
    }
}
