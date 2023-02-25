using DI.Models;
using Microsoft.EntityFrameworkCore;

namespace DI.Contexts
{
    public class TargetContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public TargetContext(DbContextOptions<TargetContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder) =>
            builder.Entity<Product>().OwnsOne(p => p.Price);
    }
}
