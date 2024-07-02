using Core.Entities.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repository.Data
{
    public class IdentityContext: IdentityDbContext<AppUser>
    {
        public IdentityContext()
        {
            
        }

        public IdentityContext(DbContextOptions<IdentityContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserAddress>()
                .ToTable("Addresses");
        }

    }
}