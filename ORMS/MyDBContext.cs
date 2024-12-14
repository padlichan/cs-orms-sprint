using Microsoft.EntityFrameworkCore;
namespace ORMS;

internal class MyDBContext : DbContext
{
    public DbSet<Toy> Toys { get; set; }
    public DbSet<Dog> Dogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Utils.CONNECTION_STRING);
    }
}
