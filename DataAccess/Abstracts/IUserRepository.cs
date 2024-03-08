using Core.DataAccess;
using Core.Utilities.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts;

public interface IUserRepository:IRepositoryBase<User, Guid>,IAsyncRepositoryBase<User,Guid>
{
}
