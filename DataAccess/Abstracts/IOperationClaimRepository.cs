using Core.DataAccess;
using Core.Utilities.Security.Entities;

namespace DataAccess.Abstracts;

public interface IOperationClaimRepository : IRepositoryBase<OperationClaim, int>, IAsyncRepositoryBase<OperationClaim, int>
{
}
