using System.Linq.Expressions;
using Gotrays.Service.Domain.Users.Aggregates;
using Masa.BuildingBlocks.Ddd.Domain.Repositories;

namespace Gotrays.Service.Domain.Users.Repositories;

public interface IUserRepository : IRepository<User, Guid>
{
    Task<bool> ExistAsync(Expression<Func<User, bool>> predicate);
}