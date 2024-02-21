using Business.Requests;
using Business.Responses.Model;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

public interface IModelService
{

    //Sync Methods
    CreateModelResponse Add(CreateModelRequest request);
    List<GetAllModelResponse> GetAll();
    GetByIdModelResponse GetById(int id);

    //Async
    Task<CreateModelResponse> AddAsync(CreateModelRequest request);
    Task<List<GetAllModelResponse>> GetAllAsync();
}
