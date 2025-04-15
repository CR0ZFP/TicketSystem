using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TicketSystem.Entitites.Entities;

namespace TicketSystem.Data
{
    public class TicketSystemContext : IdentityDbContext
    {
        public DbSet<Problem> Problems { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        public TicketSystemContext(DbContextOptions<TicketSystemContext> opt): base(opt)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
