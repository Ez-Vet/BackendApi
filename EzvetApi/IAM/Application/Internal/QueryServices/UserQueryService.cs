using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EzvetApi.IAM.domain.Model.Aggregates;
using EzvetApi.IAM.domain.Model.Queries;
using EzvetApi.IAM.domain.Repositories;
using EzvetApi.IAM.domain.Services;

namespace EzvetApi.IAM.Application.Internal.QueryServices
{
    public class UserQueryService(IUserRepository userRepository) : IUserQueryService
    {
        /**
         * <summary>
         *     Handle get user by id query
         * </summary>
         * <param name="query">The query object containing the user id to search</param>
         * <returns>The user</returns>
         */
        public async Task<User?> Handle(GetUserByIdQuery query)
        {
            return await userRepository.FindByIdAsync(query.Id);
        }
    }
}