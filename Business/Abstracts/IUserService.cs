using Core.Utilities.Results;
using Core.Utilities.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

public interface IUserService
{
    Task<IDataResult<User>> GetById(Guid request);
    Task<IDataResult<User>> GetByMail(string request);
}
