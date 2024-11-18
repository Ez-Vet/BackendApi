
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using EzvetApi.IAM.domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace EzvetApi.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddCreatedUpdatedInterceptor();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //TODO agregar tablas    
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(u => u.Name).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Password).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Email).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Speciality).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Phone).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.DNI).IsRequired();



            modelBuilder.UseSnakeCaseNamingConvention();
        }

    }
}