using Business.Requests;
using Business.Responses;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts.Async;

public interface IAsyncCarService
{
    //Async Methods
    Task<CreateCarResponse> AddAsync(CreateCarRequest request);
    Task<List<Car>> GetAll();
}
