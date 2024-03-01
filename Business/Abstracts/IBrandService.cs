using Business.Requests;
using Business.Responses.Brand;
using Core.Utilities.Results;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

public interface IBrandService
{
    //Sync Methods
    CreateBrandResponse Add(CreateBrandRequest request);
    List<GetAllBrandResponse> GetAll();
    GetByIdBrandResponse GetById(int id);

    //ASYNC
    Task<IDataResult<CreateBrandResponse>> AddAsync(CreateBrandRequest request);
    Task<IDataResult<List<GetAllBrandResponse>>> GetAllAsync();
    Task<GetByIdBrandResponse> GetByIdAsync(int request);
    Task<IResult> DeleteAsync(int request);
    Task<IResult> SoftDeleteAsync(int request);
}
