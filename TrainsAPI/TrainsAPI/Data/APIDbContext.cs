using Microsoft.EntityFrameworkCore;
using TrainsAPI.Models;

namespace TrainsAPI.Data
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Train> Trens { get; set; }
    }
}
