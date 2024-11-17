using EzvetApi.IAM.domain.Model.Aggregates;
using EzvetApi.IAM.domain.Repositories;
using EzvetApi.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EzvetApi.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EzvetApi.IAM.Infrastructure.Repositories
{
    public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository
    {
        public async Task<User?> FindByEmailAsync(string email)
        {
            return await context.Set<User>().FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}