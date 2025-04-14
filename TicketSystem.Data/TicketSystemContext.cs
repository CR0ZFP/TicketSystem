using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TicketSystem.Entitites;

namespace TicketSystem.Data
{
    public class TicketSystemContext : IdentityDbContext
    {
        public DbSet<Problem> Problems { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        public TicketSystemContext(DbContextOptions<TicketSystemContext> opt): base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
