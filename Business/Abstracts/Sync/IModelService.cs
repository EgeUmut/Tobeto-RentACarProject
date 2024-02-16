using Business.Requests;
using Business.Responses;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts.Sync;

public interface IModelService
{

    //Sync Methods
    GetByIdModelResponse GetById(int id);
}
