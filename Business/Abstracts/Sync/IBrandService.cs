using Business.Requests;
using Business.Responses;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts.Sync;

public interface IBrandService
{
    //Sync Methods
    CreateBrandResponse Add(CreateBrandRequest request);
    List<GetAllBrandResponse> GetAll();
    GetByIdBrandResponse GetById(int id);
}
