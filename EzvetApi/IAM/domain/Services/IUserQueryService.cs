
using EzvetApi.IAM.domain.Model.Aggregates;
using EzvetApi.IAM.domain.Model.Queries;

namespace EzvetApi.IAM.domain.Services
{
    public interface IUserQueryService
    {
        /**
         * <summary>
         *     Handle get user by id query
         * </summary>
         * <param name="query">The get user by id query</param>
         * <returns>The user if found, null otherwise</returns>
         */
        Task<User?> Handle(GetUserByIdQuery query);
    }
}