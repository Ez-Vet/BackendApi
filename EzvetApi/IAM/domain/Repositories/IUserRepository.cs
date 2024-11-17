
using EzvetApi.IAM.domain.Model.Aggregates;
using EzvetApi.Shared.Domain.Repositories;

namespace EzvetApi.IAM.domain.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> FindByEmailAsync(string email);

    }
}