using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_dotnetcore_web_api.Models;
using demo_dotnetcore_web_api.src.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace demo_dotnetcore_web_api.src.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {

        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            List<IdentityRole> roles = [
                new IdentityRole{
                    Id = "Admin",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                },
                 new IdentityRole{
                    Id = "User",
                    Name = "User",
                    NormalizedName = "USER",
                },
            ];
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}