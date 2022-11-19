using Microsoft.EntityFrameworkCore;

using RodManager.Data;

namespace RodManager.Providers;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }
    
    /// <summary>
    ///     Daje dostęp do użytkowników aplikacji.
    /// </summary>
    public DbSet<User> Users => Set<User>();

    /// <summary>
    ///     Daje dostęp do działek.
    /// </summary>
    public DbSet<Plot> Plots => Set<Plot>();

    /// <summary>
    ///     Daje dostęp do działkowców.
    /// </summary>
    public DbSet<AllotmentFarmer> AllotmentFarmers => Set<AllotmentFarmer>();
}