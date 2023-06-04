using Gotrays.Service.Domain.Users.Aggregates;
using Masa.BuildingBlocks.Ddd.Domain.Repositories;
using System.Linq.Expressions;

namespace Gotrays.Service.Domain.Users.Repositories;

public interface IUserRepository : IRepository<User, Guid>
{
    Task<bool> ExistAsync(Expression<Func<User, bool>> predicate);
}