using Business.Abstracts;
using Core.Utilities.Results;
using Core.Utilities.Security.Entities;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class UserManager : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserManager(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IDataResult<User>> GetById(Guid request)
    {
        var user = await _userRepository.GetAsync(p => p.Id == request);
        return new SuccessDataResult<User>(user);
    }

    public async Task<IDataResult<User>> GetByMail(string request)
    {
        var user = await _userRepository.GetAsync(p => p.Email == request);
        return new SuccessDataResult<User>(user);
    }
}
