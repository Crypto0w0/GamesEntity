using Microsoft.EntityFrameworkCore;
namespace Games;

public class GameDbContext : DbContext
{
    public DbSet<Game> Games { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=localhost;Database=Games;Integrated Security=false;User ID=root;Password=Alex228420;");
    }
}