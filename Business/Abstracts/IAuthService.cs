using Core.Utilities.Results;
using Core.Utilities.Security.Dtos;
using Core.Utilities.Security.Entities;
using Core.Utilities.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

public interface IAuthService
{
    Task<IDataResult<AccessToken>> Login(UserForLoginDto userForLoginDto);
    //Task<IDataResult<User>> Logout();
    Task<IDataResult<AccessToken>> CreateAccessToken(User user);
    Task<IDataResult<AccessToken>> Register(UserForRegisterDto userForRegisterDto);
}
