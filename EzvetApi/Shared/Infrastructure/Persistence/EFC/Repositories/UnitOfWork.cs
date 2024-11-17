
using EzvetApi.Shared.Domain.Repositories;
using EzvetApi.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace EzvetApi.Shared.Infrastructure.Persistence.EFC.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}