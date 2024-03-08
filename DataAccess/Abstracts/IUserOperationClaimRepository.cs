using Core.DataAccess;
using Core.Utilities.Security.Entities;

namespace DataAccess.Abstracts;

public interface IUserOperationClaimRepository : IRepositoryBase<UserOperationClaim, int>, IAsyncRepositoryBase<UserOperationClaim, int>
{
}
