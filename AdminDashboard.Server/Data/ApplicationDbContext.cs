using AdminDashboard.Server.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdminDashboard.Server.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<UserProfile> userProfiles { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}