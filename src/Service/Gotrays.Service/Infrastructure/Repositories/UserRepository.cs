using Gotrays.Service.Domain.Users.Aggregates;
using Gotrays.Service.Domain.Users.Repositories;
using Gotrays.Service.Infrastructure.EntityFrameworkCore;
using Masa.BuildingBlocks.Data.UoW;
using Masa.Contrib.Ddd.Domain.Repository.EFCore;
using System.Linq.Expressions;

namespace Gotrays.Service.Infrastructure.Repositories;

public class UserRepository : Repository<GotraysDbContext, User, Guid>, IUserRepository
{
    public UserRepository(GotraysDbContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
    {
    }

    public Task<bool> ExistAsync(Expression<Func<User, bool>> predicate)
    {
        return Context.Users.AnyAsync(predicate);
    }
}