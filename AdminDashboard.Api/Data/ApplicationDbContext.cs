using AdminDashboard.Api.Data;
using AdminDashboard.Api.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdminDashboard.APi.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApiUser>
    {
        public virtual DbSet<JOB>  Jobs { get; set; }
        public virtual DbSet<Countires>   Countires { get; set; }
        public virtual DbSet<LuCategory>    LuCategories { get; set; }
        public virtual DbSet<LuSubCategory>  LuSubCategories { get; set; }
        public virtual DbSet<LuSector>   LuSectors { get; set; }
        public virtual DbSet<LuRegion>    LuRegions { get; set; }
        public virtual DbSet<LuSubRegion>     LuSubRegions { get; set; }
        public virtual DbSet<Address>      Addresses { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<IdentityRole>().HasData(
            //    new IdentityRole
            //    {
            //        Name = "User",
            //        NormalizedName = "User",
            //        Id = "22c284fd36984e4dadac7f60862a004b"
            //    },
            //      new IdentityRole
            //      {
            //          Name = "Manager",
            //          NormalizedName = "Manager",
            //          Id = "2d58a9b9-6cca-4d06-84bd-933e9860af90"
            //      },
            //      new IdentityRole
            //      {
            //          Name = "Admin",
            //          NormalizedName = "Admin",
            //          Id = "e8a0a19a-a67a-4ea8-90cf-3af3f8c06713"
            //      }
            //    );
            //modelBuilder.Entity<ApiUser>().HasData(
            //   new ApiUser
            //   {
            //       Id = "8826203b-3fde-4836-b5f8-0fa00528526f"
            //   },
            //     new ApiUser
            //     {
            //         Id = "dbff6447-20ee-462d-9730-64863d8cf1c4"
            //     }
            //   );
        }
        #endregion
    }
}