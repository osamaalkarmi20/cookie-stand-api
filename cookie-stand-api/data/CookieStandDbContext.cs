using cookie_stand_api.model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace cookie_stand_api.data
{
    public class CookieStandDbContext : DbContext
    {
        public CookieStandDbContext(DbContextOptions<CookieStandDbContext> options)
            : base(options)
        {
        }

        public DbSet<CookieStand> CookieStands { get; set; }
        public DbSet<oneHourSales> oneHourSales { get; set; }

    }
}
