﻿using Business.Requests;
using Business.Responses;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts.Async;

public interface IAsyncBrandService
{
    //Async Methods
    Task<CreateBrandResponse> AddAsync(CreateBrandRequest request);
    Task<List<GetAllBrandResponse>> GetAll();
}
